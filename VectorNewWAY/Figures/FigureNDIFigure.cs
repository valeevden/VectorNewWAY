using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using VectorNewWAY.Painters;
using VectorNewWAY.Fillers;
using VectorNewWAY.Reaction;

namespace VectorNewWAY.Figures
{
    public class FigureNDIFigure : AFigure
    {
        public FigureNDIFigure(Pen pen) : base(pen)
        {
            Reaction = new FreeFigureIRightClickReaction(this);
            Painter = new PathIPainter();
            Filler = new PathFiller();
            AnglesNumber = 1;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointsList[AnglesNumber - 2] = startP;
            PointsList[AnglesNumber - 1] = endP;
        }
       
    }
}
