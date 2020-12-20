using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.MouseDownSetter
{
    class FreeBuildSetter: IMouseDownSetter
    {
        public void Set(PointF e, AFigure figure)
        {
            figure.State.Set(e, figure);
        }
    }
}
