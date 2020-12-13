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
//using PaintForSchool.RightClickReaction;

namespace VectorNewWAY.Figures
{
    public class CircleFigure : AFigure
    {
        public CircleFigure(Pen pen) : base (pen)
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

        private RectangleF MakeRectangleFromPointsList()
        {
            float width = 2 * (PointsList[1].X - PointsList[0].X);
            float height = 2 * (PointsList[1].Y - PointsList[0].Y);
            RectangleF rectangle = new RectangleF(PointsList[0].X, PointsList[0].Y, width, height);
            return rectangle;
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();

            rectangle.Inflate(SizeX, SizeY);
            Path.AddEllipse(rectangle);
           // Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            //Path.Transform(ScaleMatrix);
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            float radius = endP.X - startP.X;
            PointF startRectangleHere = new PointF(StartPoint.X, SecondPoint.Y + radius);

            PointsList = new List<PointF>();
            PointsList.Add(startRectangleHere);
            PointsList.Add(StartPoint);
            PointsList.Add(SecondPoint);
        }


    }
}
