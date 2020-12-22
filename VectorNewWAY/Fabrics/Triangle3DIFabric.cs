using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class Triangle3DIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new Triangle3DFigure(pen);
        }
    }
}
