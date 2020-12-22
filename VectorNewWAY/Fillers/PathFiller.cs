using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorNewWAY.Fillers
{
    public class PathFiller : IFiller
    {
        public void FillFigure(Pen pen, Graphics graphics, GraphicsPath Path)
        {
            graphics.FillPath(new SolidBrush(pen.Color), Path);
        }
    }
}
