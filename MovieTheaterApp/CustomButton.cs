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
    public class CustomButton : Button
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }
        public Color hoverColor1 { get; set; }
        public Color hoverColor2 { get; set; }
        public Color clickColor1 { get; set; }
        public Color clickColor2 { get; set; }
        public Color borderColor { get; set; }
        public float angle { get; set; }
        public int radius { get; set; }
        public int borderSize { get; set; }

        private Color backColor1;
        private Color backColor2;

        public CustomButton()
        {
            backColor1 = color1;
            backColor2 = color2;
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            backColor1 = hoverColor1;
            backColor2 = hoverColor2;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            backColor1 = color1;
            backColor2 = color2;
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            backColor1 = color1;
            backColor2 = color2;
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            backColor1 = color1;
            backColor2 = color2;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            backColor1 = clickColor1;
            backColor2 = clickColor2;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            backColor1 = hoverColor1;
            backColor2 = hoverColor2;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            paintButton(pevent);
        }
        private void paintButton(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            LinearGradientBrush brush1 = new LinearGradientBrush(this.ClientRectangle, this.backColor1, this.backColor2, this.angle);
            g.FillEllipse(brush1, borderSize / 2, borderSize / 2, Height - borderSize,
                Height - borderSize);
            g.FillEllipse(brush1, (Width - Height) + borderSize / 2, borderSize / 2,
                Height - borderSize, Height - borderSize);
            g.FillRectangle(brush1, Height / 2 + borderSize / 2, borderSize / 2,
                Width - Height - borderSize, Height - borderSize);
            brush1.Dispose();

            Brush brush2 = new SolidBrush(ForeColor);
            SizeF stringSize = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, brush2, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);
            brush2.Dispose();
        }
    }
}
