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

    public class EllipseFigure : AFigure
    {

        public EllipseFigure(Pen pen) : base(pen)
        {
            Painter = new PathIPainter();
            Filler = new PathFiller();
            AnglesNumber = 0;
        }

        public override GraphicsPath GetPath() 
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
          
            rectangle.Inflate(SizeX, SizeY);

            Path.AddEllipse(rectangle);
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override PointF SetCenter()
        {
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            return Center;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointsList = new List<PointF>();
            PointsList.Add(startP);
            PointsList.Add(endP);
        }
        
    }
}