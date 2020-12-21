using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Mode.Modifier
{
    public class MoveIModifier : IModifier
    {
        public void Modify(AFigure figure, PointF delta)
        {
            figure.Move(delta);
        }
    }
}
