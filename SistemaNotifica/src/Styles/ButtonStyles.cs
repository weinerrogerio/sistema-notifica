using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaNotifica.src.Controls;

namespace SistemaNotifica.src.Styles
{
    public static class ButtonStyles
    {
        // Estilo Padrão (como na imagem)
        public static void ApplyDefaultStyle(RoundedButton button)
        {
            button.ButtonBackColor = Color.FromArgb(52, 58, 64);
            button.HoverColor = Color.FromArgb(70, 80, 90);
            button.PressedColor = Color.FromArgb(40, 50, 60);
            button.ButtonTextColor = Color.White;
            button.BorderRadius = 8;
            button.BorderWidth = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Estilo Primário (Azul)
        public static void ApplyPrimaryStyle(RoundedButton button)
        {
            button.ButtonBackColor = Color.FromArgb(0, 123, 255);
            button.HoverColor = Color.FromArgb(0, 105, 217);
            button.PressedColor = Color.FromArgb(0, 86, 179);
            button.ButtonTextColor = Color.White;
            button.BorderRadius = 6;
            button.BorderWidth = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Estilo Sucesso (Verde)
        public static void ApplySuccessStyle(RoundedButton button)
        {
            button.ButtonBackColor = Color.FromArgb(40, 167, 69);
            button.HoverColor = Color.FromArgb(34, 142, 58);
            button.PressedColor = Color.FromArgb(28, 117, 48);
            button.ButtonTextColor = Color.White;
            button.BorderRadius = 6;
            button.BorderWidth = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Estilo Perigo (Vermelho)
        public static void ApplyDangerStyle(RoundedButton button)
        {
            button.ButtonBackColor = Color.FromArgb(220, 53, 69);
            button.HoverColor = Color.FromArgb(200, 35, 51);
            button.PressedColor = Color.FromArgb(176, 19, 35);
            button.ButtonTextColor = Color.White;
            button.BorderRadius = 6;
            button.BorderWidth = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Estilo Aviso (Amarelo)
        public static void ApplyWarningStyle(RoundedButton button)
        {
            button.ButtonBackColor = Color.FromArgb(255, 193, 7);
            button.HoverColor = Color.FromArgb(227, 172, 0);
            button.PressedColor = Color.FromArgb(191, 144, 0);
            button.ButtonTextColor = Color.FromArgb(33, 37, 41);
            button.BorderRadius = 6;
            button.BorderWidth = 0;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Estilo Outline (Com borda)
        public static void ApplyOutlineStyle(RoundedButton button, Color borderColor)
        {
            button.ButtonBackColor = Color.Transparent;
            button.HoverColor = Color.FromArgb(30, borderColor);
            button.PressedColor = Color.FromArgb(50, borderColor);
            button.ButtonTextColor = borderColor;
            button.BorderColor = borderColor;
            button.BorderRadius = 6;
            button.BorderWidth = 2;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Estilo Personalizado
        public static void ApplyCustomStyle(RoundedButton button,
            Color backgroundColor,
            Color textColor,
            int borderRadius = 6,
            Color? hoverColor = null,
            Color? pressedColor = null)
        {
            button.ButtonBackColor = backgroundColor;
            button.ButtonTextColor = textColor;
            button.BorderRadius = borderRadius;
            button.BorderWidth = 0;

            // Se não especificadas, gerar cores hover e pressed automaticamente
            button.HoverColor = hoverColor ?? DarkenColor(backgroundColor, 20);
            button.PressedColor = pressedColor ?? DarkenColor(backgroundColor, 40);

            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Função auxiliar para escurecer cores
        private static Color DarkenColor(Color color, int amount)
        {
            int r = Math.Max(0, color.R - amount);
            int g = Math.Max(0, color.G - amount);
            int b = Math.Max(0, color.B - amount);
            return Color.FromArgb(color.A, r, g, b);
        }

        // Função auxiliar para clarear cores
        public static Color LightenColor(Color color, int amount)
        {
            int r = Math.Min(255, color.R + amount);
            int g = Math.Min(255, color.G + amount);
            int b = Math.Min(255, color.B + amount);
            return Color.FromArgb(color.A, r, g, b);
        }
    }
}
