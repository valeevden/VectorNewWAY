using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Saver;
using VectorNewWAY.MouseDownSetter;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.Figures
{
    public abstract class AFreeBuild: AFigure
    {
        public AFreeBuild(Pen pen):base(pen)
        {
            Saver = new InActiveISaver();
            Setter = new FreeBuildSetter();
            State = new FinishedIFigureState();
        }
    }
}
