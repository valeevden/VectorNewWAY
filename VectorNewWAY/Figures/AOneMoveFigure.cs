using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Saver;
using VectorNewWAY.RightClickReaction;
using VectorNewWAY.FigureState;
using VectorNewWAY.Setter;

namespace VectorNewWAY.Figures
{
    public abstract class AOneMoveFigure: AFigure
    {
        public AOneMoveFigure(Pen pen):base(pen)
        {
            Saver = new ActiveISaver();
            RightClickReaction = new NoReactionIReaction(this);
            Setter = new OneMoveSetter();
        }
        public override void Update(PointF startP, PointF endP)
        {
            PointsList[0] = MouseDownPoint;
            PointsList[1] = endP;
        }
    }
}
