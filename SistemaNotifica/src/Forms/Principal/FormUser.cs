using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SistemaNotifica.src.Forms.Principal
{
    public partial class FormUser : Form
    {
        #region Constantes e Variáveis
        private const string API_BASE_URL = "http://localhost:3000";
        private const string API_USER_ENDPOINT = "/user";

        private bool _editando = false;
        private readonly HttpClient _httpClient;
        #endregion

        #region Construtor e Inicialização
        public FormUser()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            InicializarForm();
        }

        private void InicializarForm()
        {
            ConfigurarHttpClient();
            ConfigurarControles();
            ResetarTelaUsuario();
            this.Load += FormUser_Load;

            // Token hardcoded apenas para desenvolvimento - REMOVER em produção
            Sessao.Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjEsIm5hbWUiOiJhZG1pbiIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTc1MDQ0NDM1MCwiZXhwIjoxNzUwNDczMTUwLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjMwMDAiLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjMwMDAifQ.SXKCjOHbN_RXbdEJxgzFcFir2IR7BSZ-6a6lCvSIP_k";
        }

        private void ConfigurarHttpClient()
        {
            if (_httpClient.DefaultRequestHeaders.Authorization == null ||
                _httpClient.DefaultRequestHeaders.Authorization.Parameter != Sessao.Token)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Sessao.Token);
            }
        }

        private void ConfigurarControles()
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            btnDelet.Visible = false;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
        }

        private async void FormUser_Load(object sender, EventArgs e)
        {
            await CarregarUsuariosDaApiAsync();
        }
        #endregion

        #region Gerenciamento de Estado da Tela
        private void ResetarTelaUsuario()
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            LimparFormulario();
            ConfigurarEstadoInicial();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void LimparFormulario()
        {
            comboBox1.SelectedIndex = -1;
            LimparCampos();
            BloquearCampos();
        }

        private void ConfigurarEstadoInicial()
        {
            btnDelet.Visible = false;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;

            comboBox1.Enabled = true;
            btnCadUser.Enabled = true;
            btnEditarUser.Enabled = true;

            _editando = false;
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void BloquearCampos()
        {
            foreach (var tb in new[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 })
                tb.ReadOnly = true;
        }

        private void DesbloquearCampos()
        {
            foreach (var tb in new[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 })
                tb.ReadOnly = false;
        }

        private void MostrarBotoesEdicao()
        {
            btnSalvar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void OcultarBotoesEdicao()
        {
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            btnDelet.Visible = false;
        }
        #endregion

        #region Integração com API
        private async Task<bool> CarregarUsuariosDaApiAsync()
        {
            try
            {
                ConfigurarHttpClient();

                var response = await _httpClient.GetAsync($"{API_BASE_URL}{API_USER_ENDPOINT}");
                var json = await response.Content.ReadAsStringAsync();

                if (!await TratarRespostaAutenticacao(response, json))
                    return false;

                if (response.IsSuccessStatusCode)
                {
                    var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                    Usuarios.ListaUsuarios = usuarios ?? new List<Usuario>();

                    checkBox1_CheckedChanged(null, null); // aplica o filtro
                    return true;
                }

                else
                {
                    ExibirErro("Erro ao carregar usuários do servidor.");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                ExibirErro($"Erro de conexão com a API: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro inesperado: {ex.Message}");
                return false;
            }

            checkBox1_CheckedChanged(null, null);

        }

        private void AtualizarListaUsuarios(List<Usuario> usuarios)
        {
            Usuarios.ListaUsuarios = usuarios ?? new List<Usuario>();

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            comboBox1.DataSource = null;

            if (Usuarios.ListaUsuarios.Any())
            {
                comboBox1.DataSource = Usuarios.ListaUsuarios;
                comboBox1.DisplayMember = "Nome";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private bool UsuarioJaExiste(string nome, string email)
        {
            return Usuarios.ListaUsuarios.Any(u =>
                u.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase) ||
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<bool> EnviarUsuarioParaApiAsync(Usuario usuario, bool isEdicao = false, int idUsuario = 0)
        {
            try
            {
                ConfigurarHttpClient();

                string url = isEdicao
                    ? $"{API_BASE_URL}{API_USER_ENDPOINT}/{idUsuario}"
                    : $"{API_BASE_URL}{API_USER_ENDPOINT}";

                var usuarioCriacao = new UsuarioCriacaoDto
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Contato = usuario.Contato,
                    Endereco = usuario.Endereco,
                    Password = usuario.Senha
                };

                var json = JsonConvert.SerializeObject(usuarioCriacao, Formatting.Indented);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                if (isEdicao)
                    response = await _httpClient.PutAsync(url, content);
                else
                    response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                    return true;

                string respostaErro = await response.Content.ReadAsStringAsync();
                ExibirErro($"Erro na API (Status: {response.StatusCode}):\n\n{respostaErro}");
                return false;
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao enviar dados para a API:\n{ex.Message}");
                return false;
            }
        }

        private async Task<bool> DeletarUsuarioNaApi(int usuarioId)
        {
            try
            {
                ConfigurarHttpClient();

                var response = await _httpClient.DeleteAsync($"{API_BASE_URL}{API_USER_ENDPOINT}/{usuarioId}");
                var resultado = await response.Content.ReadAsStringAsync();

                if (!await TratarRespostaAutenticacao(response, resultado))
                    return false;

                if (!response.IsSuccessStatusCode)
                {
                    ExibirErro($"Erro ao deletar usuário (Status: {response.StatusCode}): {resultado}");
                    return false;
                }

                return true;
            }
            catch (HttpRequestException ex)
            {
                ExibirErro($"Erro de conexão com a API: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro inesperado: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> TratarRespostaAutenticacao(HttpResponseMessage response, string conteudo)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                try
                {
                    var erro = JsonConvert.DeserializeObject<ErroApi>(conteudo);
                    if (erro?.error == "jwt expired")
                    {
                        ExibirAviso("Sua sessão expirou. Faça login novamente.", "Sessão Expirada");
                        return false;
                    }
                }
                catch
                {
                    ExibirErro("Erro de autenticação. Faça login novamente.");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Validações
        private bool ValidarCamposObrigatorios()
        {
            var campos = new Dictionary<string, string>
            {
                ["Nome"] = textBox1.Text,
                ["Contato"] = textBox2.Text,
                ["Email"] = textBox3.Text,
                ["Endereço"] = textBox4.Text
            };

            var camposVazios = campos.Where(c => string.IsNullOrWhiteSpace(c.Value)).ToList();

            if (camposVazios.Any())
            {
                var nomesCampos = string.Join(", ", camposVazios.Select(c => c.Key));
                ExibirAviso($"Preencha os campos obrigatórios: {nomesCampos}", "Campo(s) obrigatório(s)");
                return false;
            }

            if (!_editando && string.IsNullOrWhiteSpace(textBox6.Text))
            {
                ExibirAviso("Senha é obrigatória para novo usuário.", "Senha Obrigatória");
                return false;
            }

            return true;
        }
        #endregion

        #region Eventos dos Botões
        private void btnCadUser_Click(object sender, EventArgs e)
        {
            _editando = false;
            LimparCampos();
            DesbloquearCampos();
            comboBox1.Enabled = false;

            btnSalvar.Visible = true;
            btnCancelar.Visible = true;

            btnCadUser.Enabled = false;
            btnEditarUser.Enabled = false;
            btnDelet.Visible = false;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObrigatorios())
                return;

            var usuario = new Usuario
            {
                Nome = textBox1.Text,
                Contato = textBox2.Text.Trim(),
                Email = textBox3.Text,
                Endereco = textBox4.Text,
                Senha = string.IsNullOrWhiteSpace(textBox6.Text) ? null : textBox6.Text
            };

            if (_editando)
            {
                // Atualiza usuário existente
                if (comboBox1.SelectedItem is Usuario selecionado)
                {
                    usuario.Id = selecionado.Id;
                    var sucesso = await EnviarUsuarioParaApiAsync(usuario, isEdicao: true, idUsuario: usuario.Id);
                    if (sucesso)
                    {
                        ExibirMensagem("Usuário atualizado com sucesso!");
                        await CarregarUsuariosDaApiAsync();
                        ResetarTelaUsuario();
                    }
                }
                else
                {
                    ExibirErro("Nenhum usuário selecionado para editar.");
                }
            }
            else
            {
                // Verifica duplicidade
                if (UsuarioJaExiste(usuario.Nome, usuario.Email))
                {
                    ExibirAviso("Usuário com este nome ou email já existe.", "Duplicidade");
                    return;
                }

                var sucesso = await EnviarUsuarioParaApiAsync(usuario);
                if (sucesso)
                {
                    ExibirMensagem("Usuário cadastrado com sucesso!");
                    await CarregarUsuariosDaApiAsync();
                    ResetarTelaUsuario();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ResetarTelaUsuario();
        }

        private async void btnDelet_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Usuario selecionado)
            {
                var confirm = MessageBox.Show($"Deseja realmente deletar o usuário '{selecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var sucesso = await DeletarUsuarioNaApi(selecionado.Id);
                    if (sucesso)
                    {
                        ExibirMensagem("Usuário deletado com sucesso!");
                        await CarregarUsuariosDaApiAsync();
                        ResetarTelaUsuario();
                    }
                }
            }
            else
            {
                ExibirAviso("Nenhum usuário selecionado para deletar.", "Aviso");
            }
        }

        private void btnEditarUser_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Usuario selecionado)
            {
                _editando = true;

                PreencherCamposComUsuario(selecionado);

                DesbloquearCampos();
                comboBox1.Enabled = false;

                btnSalvar.Visible = true;
                btnCancelar.Visible = true;
                btnDelet.Visible = true;

                btnCadUser.Enabled = false;
                btnEditarUser.Enabled = false;
            }
            else
            {
                ExibirAviso("Selecione um usuário para editar.", "Aviso");
            }
        }
        #endregion

        #region Manipulação dos Controles
        private void PreencherCamposComUsuario(Usuario usuario)
        {
            textBox1.Text = usuario.Nome;
            textBox2.Text = usuario.Contato;
            textBox3.Text = usuario.Email;
            textBox4.Text = usuario.Endereco;

            // Senha não é carregada por segurança
            textBox6.Text = string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_editando)
            {
                if (comboBox1.SelectedItem is Usuario usuario)
                {
                    PreencherCamposComUsuario(usuario);
                    BloquearCampos();

                    btnDelet.Visible = false;
                    btnSalvar.Visible = false;
                    btnCancelar.Visible = false;
                }
                else
                {
                    LimparCampos();
                    BloquearCampos();
                }
            }
        }
        #endregion

        #region Utilitários de Interface
        private void ExibirErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ExibirAviso(string mensagem, string titulo = "Aviso")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Classes Auxiliares
        private static class Sessao
        {
            public static string Token { get; set; }
        }

        private static class Usuarios
        {
            public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();

        }

        private class UsuarioCriacaoDto
        {
            [JsonProperty("nome")]
            public string Nome { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("contato")]
            public string Contato { get; set; }

            [JsonProperty("endereco")]
            public string Endereco { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("is_active")]
            public bool IsAtivo { get; set; }
        }



        private class Usuario
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("nome")]
            public string Nome { get; set; }

            [JsonProperty("contato")]
            public string Contato { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("endereco")]
            public string Endereco { get; set; }

            [JsonProperty("senha")]
            public string Senha { get; set; }

            [JsonProperty("is_active")]
            public bool Ativo { get; set; }

        }

        private class ErroApi
        {
            [JsonProperty("error")]
            public string error { get; set; }

            public override string ToString()
            {
                return error;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // desativado
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<Usuario> usuariosFiltrados;

            if (checkBox1.Checked)
            {
                // Mostrar todos (ativos e inativos)
                usuariosFiltrados = Usuarios.ListaUsuarios;
            }
            else
            {
                // Mostrar somente os ativos
                usuariosFiltrados = Usuarios.ListaUsuarios
                    .Where(u => u.Ativo)
                    .ToList();
            }

            // Atualiza o comboBox1
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            comboBox1.DataSource = null;

            if (usuariosFiltrados.Any())
            {
                comboBox1.DataSource = usuariosFiltrados;
                comboBox1.DisplayMember = "Nome";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Limpa os campos
            LimparCampos();
            BloquearCampos();

            // Ajusta botões
            btnDelet.Visible = false;
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;

            comboBox1.Enabled = true;
            btnCadUser.Enabled = true;
            btnEditarUser.Enabled = true;

            _editando = false;
        }



    }
}
