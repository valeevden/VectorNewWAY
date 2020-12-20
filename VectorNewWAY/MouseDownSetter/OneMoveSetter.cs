using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using VectorNewWAY.Figures;

namespace VectorNewWAY.MouseDownSetter
{
    public class OneMoveSetter: IMouseDownSetter
    {
        
        public void Set(PointF e, AFigure figure)
        {
            figure.State.Set(e, figure);
        }
    }
}
