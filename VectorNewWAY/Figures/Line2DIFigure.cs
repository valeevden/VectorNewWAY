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
    public class Line2DIFigure : AFigure
    {
        public Line2DIFigure(Pen pen): base (pen)
        {
            Reaction = new NoReactionIReaction();
            Painter = new PathIPainter();
            Filler = new LineIFiller();
            AnglesNumber = 2;
        }

        public override GraphicsPath GetPath()
        {
            MakePathFromLine();
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointsList = new List<PointF>() { new PointF(0, 0), new PointF(0, 0) };
            PointsList[0] = startP;
            PointsList[1] = endP;
        }

        public override PointF SetCenter()
        {
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            return Center;
        }

    }
}
