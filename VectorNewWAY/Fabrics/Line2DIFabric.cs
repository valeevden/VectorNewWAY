using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class Line2DIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new Line2DIFigure(pen);
        }
    }
}
