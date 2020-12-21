using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.Mode.Modifier
{
    public interface IModifier
    {
        void Modify(AFigure figure, PointF delta);
    }
}
