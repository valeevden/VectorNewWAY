using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class FigureNDIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new FigureNDIFigure(pen);
        }
    }
}
