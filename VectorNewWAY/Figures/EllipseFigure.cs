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

    public class EllipseFigure : AFigure
    {
        float dX = 1;
        public EllipseFigure(Pen pen)
        {
            Painter = new PathIPainter();
            Reaction = new NoReactionIReaction();
            Filler = new PathFiller();
            Started = false;
            Color = pen.Color;
            Width = (int)pen.Width;
            AnglesNumber = 0;
            IsFilled = false;
            ScaleMatrix = new Matrix();
            SizeX = 0;
            SizeY = 0;
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
          
            rectangle.Inflate(SizeX, SizeY);
            Path.AddEllipse(rectangle);

            //Path.Transform(ScaleMatrix);
            // Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointsList = new List<PointF>();
            PointsList.Add(startP);
            PointsList.Add(endP);
        }

        private RectangleF MakeRectangleFromPointsList()
        {
            float width = PointsList[1].X - PointsList[0].X;
            float height = PointsList[1].Y - PointsList[0].Y;
            RectangleF rectangle = new RectangleF(PointsList[0].X, PointsList[0].Y, width, height);
            return rectangle;
        }


        public override bool IsEdge(PointF eLocation)
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Path.AddEllipse(rectangle);

            Pen penGP = new Pen(Color, Width);
            if (Path.IsOutlineVisible(eLocation, penGP)) // Если точка входит в область видимости 
            {
                TouchPoint = eLocation;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool IsArea(PointF eLocation)
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Path.AddEllipse(rectangle);

            if (Path.IsVisible(eLocation)) // Если точка входит в область видимости 
            {
                TouchPoint = eLocation;
                return true;
            }
            else
            {
                return false;
            }
        }



        public override void Scale(PointF point)
        {
            RectangleF rectangle = MakeRectangleFromPointsList();
            
            SizeX = SizeX - point.Y/2 * rectangle.Width*0.008f;
            SizeY = SizeY - point.Y/2* rectangle.Height * 0.008f;
        }

        public override void Rotate(int RotateAngle)
        {
            PointF center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            RectangleF rectangle = MakeRectangleFromPointsList();
            PointF[] prgls = new PointF[]
              { new PointF(rectangle.Location.X - rectangle.Width/2, rectangle.Location.Y - rectangle.Height/2),
               new PointF(rectangle.Width*1.5f, rectangle.Location.Y - rectangle.Height/2),
               new PointF(rectangle.Location.X - rectangle.Width/2, rectangle.Height*1.5f) };
            ScaleMatrix = new Matrix(rectangle, prgls);

        }


        public override void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
        }
       
    }
}