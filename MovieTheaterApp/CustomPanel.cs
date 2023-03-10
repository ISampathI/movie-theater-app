using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace WinFormsApp5
{
    public class CustomPanel : Panel
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public Color borderColor { get; set; }
        public float angle { get; set; }

        public int radius { get; set; }
        public int borderSize { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            paintButton(e);
        }
        private void paintButton(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush brush1 = new SolidBrush(borderColor);

            g.FillEllipse(brush1, 0, 0, Height, Height);
            g.FillEllipse(brush1, Width - Height, 0, Height, Height);
            g.FillRectangle(brush1, Height / 2, 0, Width - Height, Height);

            brush1.Dispose();
            LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, this.color1, this.color2, this.angle);
            if (radius == 0)
            {
                g.FillRectangle(brush2, this.ClientRectangle);
            }
            else
            {
                g.FillEllipse(brush2, borderSize / 2, borderSize / 2, Height - borderSize,
                    Height - borderSize);
                g.FillEllipse(brush2, (Width - Height) + borderSize / 2, borderSize / 2,
                    Height - borderSize, Height - borderSize);
                g.FillRectangle(brush2, Height / 2 + borderSize / 2, borderSize / 2,
                    Width - Height - borderSize, Height - borderSize);
            }
            brush2.Dispose();
        }
    }
}
