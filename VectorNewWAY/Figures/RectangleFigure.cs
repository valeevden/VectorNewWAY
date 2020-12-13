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
   public class RectangleFigure : AFigure
    {
        public RectangleFigure(Pen pen) : base(pen)
        {
            Painter = new PathIPainter();
            Reaction = new NoReactionIReaction();
            Filler = new PathFiller();
            Started = false;
            AnglesNumber = 0;
            IsFilled = false;
            ScaleMatrix = new Matrix();
            RotateMatrix = new Matrix();
            SizeX = 0;
            SizeY = 0;
        }
    }
   
}
