using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class IsoscelesTriangleIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new IsoscelesTriangleIFigure(pen);
        }
    }
}
