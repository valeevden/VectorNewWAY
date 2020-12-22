using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class CircleIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new CircleFigure(pen);
        }
    }
}
