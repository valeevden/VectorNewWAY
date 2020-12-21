using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Saver;
using VectorNewWAY.FigureState;
using VectorNewWAY.Setter;

namespace VectorNewWAY.Figures
{
    public abstract class AFreeBuild: AFigure
    {
        public AFreeBuild(Pen pen):base(pen)
        {
            Saver = new InActiveISaver();
            Setter = new FreeBuildSetter();
        }
    }
}
