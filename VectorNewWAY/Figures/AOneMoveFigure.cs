using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.MouseDownSetter;
using VectorNewWAY.FigureFinalizer;
using VectorNewWAY.Reaction;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.Figures
{
    public abstract class AOneMoveFigure: AFigure
    {
        public AOneMoveFigure(Pen pen):base(pen)
        {
            Finalizer = new ActiveIFinalizer();
            Reaction = new NoReactionIReaction(this);
            Setter = new OneMoveSetter();
            State = new FinishedIFigureState();
        }

    }
}
