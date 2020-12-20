using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.FigureFinalizer;
using VectorNewWAY.MouseDownSetter;

namespace VectorNewWAY.Figures
{
    public abstract class AFreeBuild: AFigure
    {
        public AFreeBuild(Pen pen):base(pen)
        {
            Setter = new FreeBuildSetter();
            Finalizer = new FreeBuildIFinalizer();
        }
    }
}
