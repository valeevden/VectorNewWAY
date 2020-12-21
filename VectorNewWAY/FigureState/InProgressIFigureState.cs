using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.FigureState
{
    public class InProgressIFigureState: IFigureState
    {
        public void Set(PointF eLocation, AFigure figure)
        {
          
        }
        public void FinalizeFigure(AFigure figure)
        {
            figure.State = new FinishedIFigureState();
            figure.ApplySaver();
        }
    }
}
