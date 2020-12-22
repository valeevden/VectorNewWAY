using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class RectTriangleIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new RectTriangleIFigure(pen);
        }
    }
}
