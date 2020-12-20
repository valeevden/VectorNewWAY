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
    public class LineNDIFigure : AFigure
    {
        public LineNDIFigure(Pen pen):base(pen)
        {
            Reaction = new FreeLineIRightClickReaction(this);
            Filler = new LineIFiller();
            Painter = new PathIPainter();
            AnglesNumber = 1;
        }


        public override void Update(PointF startP, PointF endP)
        {
            PointsList[AnglesNumber - 2] = startP;
            PointsList[AnglesNumber - 1] = endP;
        }
       
    }
}
