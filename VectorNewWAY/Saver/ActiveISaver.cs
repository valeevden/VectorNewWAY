using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.Saver
{
    public class ActiveISaver : ISaver
    {
        public void SaveFigure(AFigure figure)
        {
            figure.State.SaveFigure(figure);
        }
    }
}
