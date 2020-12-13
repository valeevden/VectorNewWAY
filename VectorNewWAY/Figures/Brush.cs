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
    public class Brush : AFigure
    {
        public Brush (Pen pen): base (pen)
        {
            Reaction = new NoReactionIReaction();
            Painter = new PathIPainter();
            AnglesNumber = 0;
            RotateMatrix = new Matrix();
            PointsList = new List<PointF>() { new PointF(0, 0), new PointF(0, 0) };
        }
    }
}
