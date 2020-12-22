using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class EllipseIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
           return new EllipseFigure(pen);
        }
    }
}
