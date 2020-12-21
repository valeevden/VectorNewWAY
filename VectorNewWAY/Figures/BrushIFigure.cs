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
using VectorNewWAY.RightClickReaction;

namespace VectorNewWAY.Figures
{
    public class BrushIFigure : AOneMoveFigure
    {
        public BrushIFigure (Pen pen): base (pen)
        {
            RightClickReaction = new NoReactionIReaction(this);
            Painter = new PathIPainter();
            Filler = new LineIFiller();
            AnglesNumber = 1;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointsList.Add(endP); 
            PointsList[AnglesNumber - 1] = startP;
            PointsList[AnglesNumber] = endP;
            AnglesNumber++;
        }
    }
}
