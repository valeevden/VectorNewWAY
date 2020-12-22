using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorNewWAY.Painters
{
   public class PathIPainter : IPainter
    {
        public void DrawFigure(Pen pen, Graphics graphics, GraphicsPath Path)
        {
            graphics.DrawPath(pen, Path);
        }
    }
}
