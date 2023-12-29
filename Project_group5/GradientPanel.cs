using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    internal class GradientPanel : Panel
    {
        private int borderRadius = 15;
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }
        public float Angle { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            //Gradient
            LinearGradientBrush brush = new
            LinearGradientBrush(this.ClientRectangle, this.ColorTop,
            this.ColorBottom, this.Angle);
            Graphics g = e.Graphics;
            g.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
            //Radius
            RectangleF rectangleF = new Rectangle(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using(GraphicsPath graphicsPath = GetGraphicsPath(rectangleF, borderRadius))
                using(Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else this.Region = new Region(rectangleF);
        }
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value;this.Invalidate();}
        }
        private GraphicsPath GetGraphicsPath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius,radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
    }
}
