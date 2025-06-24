using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaNotifica.src.Controls
{
    public partial class RoundedButton : UserControl
    {
        // Campos privados
        private Color _backgroundColor = Color.FromArgb(52, 58, 64);
        private Color _hoverColor = Color.FromArgb(70, 80, 90);
        private Color _pressedColor = Color.FromArgb(40, 50, 60);
        private Color _textColor = Color.White;
        private Color _borderColor = Color.Transparent;
        private int _borderRadius = 8;
        private int _borderWidth = 0;
        private string _buttonText = "Button";
        private bool _isHovered = false;
        private bool _isPressed = false;

        // Propriedades públicas que aparecerão no Designer
        [Category("Appearance")]
        [Description("Cor de fundo do botão")]
        [DefaultValue(typeof(Color), "52, 58, 64")]
        public Color ButtonBackColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Cor do botão quando o mouse está sobre ele")]
        [DefaultValue(typeof(Color), "70, 80, 90")]
        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Cor do botão quando pressionado")]
        [DefaultValue(typeof(Color), "40, 50, 60")]
        public Color PressedColor
        {
            get => _pressedColor;
            set { _pressedColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Cor do texto do botão")]
        [DefaultValue(typeof(Color), "White")]
        public Color ButtonTextColor
        {
            get => _textColor;
            set { _textColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Cor da borda do botão")]
        [DefaultValue(typeof(Color), "Transparent")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Raio das bordas arredondadas")]
        [DefaultValue(8)]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Largura da borda")]
        [DefaultValue(0)]
        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Texto do botão")]
        [DefaultValue("Button")]
        public string ButtonText
        {
            get => _buttonText;
            set { _buttonText = value ?? ""; Invalidate(); }
        }

        // Evento de clique personalizado
        public new event EventHandler Click;

        // Métodos para serialização das cores (necessário para o Designer)
        public bool ShouldSerializeButtonBackColor()
        {
            return _backgroundColor != Color.FromArgb(52, 58, 64);
        }

        public void ResetButtonBackColor()
        {
            ButtonBackColor = Color.FromArgb(52, 58, 64);
        }

        public bool ShouldSerializeHoverColor()
        {
            return _hoverColor != Color.FromArgb(70, 80, 90);
        }

        public void ResetHoverColor()
        {
            HoverColor = Color.FromArgb(70, 80, 90);
        }

        public bool ShouldSerializePressedColor()
        {
            return _pressedColor != Color.FromArgb(40, 50, 60);
        }

        public void ResetPressedColor()
        {
            PressedColor = Color.FromArgb(40, 50, 60);
        }

        public bool ShouldSerializeButtonTextColor()
        {
            return _textColor != Color.White;
        }

        public void ResetButtonTextColor()
        {
            ButtonTextColor = Color.White;
        }

        public bool ShouldSerializeBorderColor()
        {
            return _borderColor != Color.Transparent;
        }

        public void ResetBorderColor()
        {
            BorderColor = Color.Transparent;
        }

        public RoundedButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            Size = new Size(100, 35);
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Color currentColor = GetCurrentBackColor();

            using (var path = GetRoundedRectangle(rect, _borderRadius))
            {
                // Preencher fundo
                using (var brush = new SolidBrush(currentColor))
                {
                    g.FillPath(brush, path);
                }

                // Desenhar borda se necessário
                if (_borderWidth > 0 && _borderColor != Color.Transparent)
                {
                    using (var pen = new Pen(_borderColor, _borderWidth))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }

            // Desenhar texto
            if (!string.IsNullOrEmpty(_buttonText))
            {
                TextRenderer.DrawText(g, _buttonText, Font, ClientRectangle,
                    _textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private Color GetCurrentBackColor()
        {
            if (_isPressed) return _pressedColor;
            if (_isHovered) return _hoverColor;
            return _backgroundColor;
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();

            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            _isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate();

            if (ClientRectangle.Contains(e.Location))
            {
                Click?.Invoke(this, EventArgs.Empty);
            }

            base.OnMouseUp(e);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);
        }
    }
}