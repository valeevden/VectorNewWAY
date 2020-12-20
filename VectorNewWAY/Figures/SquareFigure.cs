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
    public class SquareFigure : AOneMoveFigure
    {
        public SquareFigure(Pen pen) : base(pen)
        {
            Painter = new PathIPainter();
            Filler = new PathFiller();
            AnglesNumber = 4;
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Path.AddRectangle(rectangle);
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointsList = new List<PointF>();
            PointsList.Add(startP);
            PointsList.Add(endP);
        }

        public override RectangleF MakeRectangleFromPointsList()
        {
            float a = Math.Abs(PointsList [0].X - PointsList[1].X);
            if (PointsList[0].Y > PointsList[1].Y)
            {
                a = -a;
            }

            PointF[] points = new PointF[4];
            points[0] = PointsList[0];
            points[1] = new PointF(PointsList[0].X, PointsList[0].Y + a);
            points[2] = new PointF(PointsList[1].X, PointsList[0].Y + a);
            points[3] = new PointF(PointsList[1].X, PointsList[0].Y);
            float width = points [2].X - points[0].X;
            float height = points[2].Y - points[0].Y;
            RectangleF rectangle = new RectangleF(points[0].X, points[0].Y, width, height);

            Path = new GraphicsPath();
            Path.AddEllipse(rectangle);
            rectangle = Path.GetBounds();
            Path = new GraphicsPath();
            return rectangle;
        }

        public override PointF SetCenter()
        {
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            return Center;
        }
    }
}
