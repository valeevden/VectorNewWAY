using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
