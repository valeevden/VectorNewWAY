using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public interface IFigureFabric
    {
        AFigure CreateFigure(Pen pen);
    }
}
