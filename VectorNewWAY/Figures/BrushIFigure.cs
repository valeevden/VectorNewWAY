using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;//для Brush
using VectorNewWAY.Painters;
using VectorNewWAY.Fillers;
using VectorNewWAY.Reaction;

namespace VectorNewWAY.Figures
{
    public class BrushIFigure : AFigure
    {
        public BrushIFigure (Pen pen): base (pen)
        {
            Reaction = new NoReactionIReaction();
            Painter = new PathIPainter();
            Filler = new LineIFiller();
            AnglesNumber = 1;
        }
        public override GraphicsPath GetPath() 
        {
            MakePathFromLine();
            Path.Transform(RotateMatrix);
            return Path;
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
