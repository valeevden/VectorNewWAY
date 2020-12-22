using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class RectangleIFabric : IFigureFabric 
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new RectangleFigure(pen);
        }
    }
}
