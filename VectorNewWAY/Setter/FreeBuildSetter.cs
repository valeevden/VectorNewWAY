using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Setter
{
    public class FreeBuildSetter: ISetter
    {
        public void Set(AFigure figure)
        {
            figure.AnglesNumber++;
            figure.PointsList.Add(new PointF(0,0));
        }
}
}
