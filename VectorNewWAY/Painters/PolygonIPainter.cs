
using System.Drawing;

namespace VectorNewWAY.Painters
{
    public class PolygonIPainter //: IPainter
    {
        public void DrawFigure(Pen pen, Graphics graphics, Point[] points)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.DrawPolygon(pen, points);
        }
    }
}
