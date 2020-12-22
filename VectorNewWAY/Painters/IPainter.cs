using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorNewWAY.Painters
{
    public interface IPainter
    {
        void DrawFigure(Pen pen, Graphics graphics, GraphicsPath path);
    }
}
