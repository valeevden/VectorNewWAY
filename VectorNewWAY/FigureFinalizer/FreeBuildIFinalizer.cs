using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.FigureFinalizer
{
    public class FreeBuildIFinalizer: IFinalizer
    {
        public void FinalizeFigure(AFigure figure)
        {
            figure.State.FinalizeFigure(figure);
        }
    }
}
