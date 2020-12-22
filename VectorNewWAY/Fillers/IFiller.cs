using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorNewWAY.Fillers
{
    public interface IFiller
    {
        void FillFigure(Pen pen, Graphics graphics, GraphicsPath Path);
    }
}
