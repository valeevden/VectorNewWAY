using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    class NAngleIFabric : IFigureFabric
    {
        int anglesNumber;
        public NAngleIFabric(int numberFromNumeric)
        {
            anglesNumber = numberFromNumeric;
        }
        public AFigure CreateFigure(Pen pen)
        {
            return new NAngleAFigure(anglesNumber, pen);
        }
    }
}
