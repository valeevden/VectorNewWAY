using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.FigureFinalizer;
using VectorNewWAY.MouseDownSetter;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.Figures
{
    public abstract class AFreeBuild: AFigure
    {
        public AFreeBuild(Pen pen):base(pen)
        {
            Finalizer = new InActiveIFinalizer();
            Setter = new FreeBuildSetter();
            State = new InProgressIFigureState();
        }
    }
}
