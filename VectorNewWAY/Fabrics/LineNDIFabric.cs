using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class LineNDIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new LineNDIFigure(pen);
        }
    }
}
