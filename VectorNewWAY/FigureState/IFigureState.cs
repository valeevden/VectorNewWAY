using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.FigureState
{
    public interface IFigureState
    {
        void Set(PointF e, AFigure figure);
        void SaveFigure(AFigure figure);
    }
}
