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
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            RectangleF rectangle = MakeRectangleFromPointsList();
            Path = new GraphicsPath();
            Path.AddEllipse(rectangle);
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



        //public void Rotate(Point point)
        //{
        //    RectangleFigure rectangleForGP = MakeRectangleFromPointsList(pointsList); //Создаем ректангл из листа
        //    GraphicsPath EllipseGP = new GraphicsPath(); // Создаем новый график пас
        //    EllipseGP.AddEllipse(rectangleForGP); // Добавляем в график пас новую область видимости
        //    EllipseGP.Flatten();

        //    //Array[] pathArray = new Array[] { EllipseGP.PathPoints };
        //    //List<Point> pointListR = MakePointsForExtrenalRectangle(pointsList);
        //    //Matrix rectMatrix = new Matrix();
        //    //Matrix rectMatrix = new Matrix(rectangleForGP, EllipseGP.PathPoints);
        //    //rectMatrix.Rotate(30);
        //    RectangleF boundRectangle;
        //    boundRectangle = (EllipseGP.GetBounds());
        //    pointsArray[0] = new Point((int)boundRectangle.X, (int)boundRectangle.Y);
        //    pointsArray[1] = new Point((int)boundRectangle.Width + pointsArray[0].X, (int)boundRectangle.Height + pointsArray[0].Y);




        //    double delta;
        //    if (point.Y < 0)
        //    {
        //        delta = 0.017;//если вверх, то поворачиваем на один градус влево каждый MouseMove
        //    }
        //    else
        //    {
        //        delta = -0.017;//если вниз, то поворачиваем на один градус влево каждый MouseMove
        //    }

        //    delta *= 1.5;//регулировка скорость вращения

        //    List<Point> pointListR = MakePointsForExtrenalRectangle(pointsList);

        //    float[] startAngle = new float[2];
        //    Point center = pointsArray[0];

        //    for (int i = 0; i < 2; i++)
        //    {
        //        float radius = (float)Math.Sqrt(Math.Pow(pointsArray[i].X - center.X, 2) + Math.Pow(pointsArray[i].Y - center.Y, 2));

        //        //только поняв в какой четверти находит противолежщий катет можно
        //        //правильно интерпретировать результат, т. к. например арксинусы для
        //        //углов 10, 170, 190 и 350 градусов будет одинаковыми
        //        if (pointsArray[i].Y < center.Y)
        //        {
        //            if (pointsArray[i].X < center.X)
        //            {
        //                startAngle[i] = (float)Math.PI - (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
        //            }
        //            else
        //            {
        //                startAngle[i] = (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
        //            }
        //        }
        //        else
        //        {
        //            if (pointsArray[i].X < center.X)
        //            {
        //                startAngle[i] = (float)Math.PI + (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
        //            }
        //            else
        //            {
        //                startAngle[i] = (float)Math.PI * 2 - (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
        //            }
        //        }
        //    }

        //    //поворот точек на delta радиан Против часовой
        //    for (int i = 0; i < 2; i++)
        //    {
        //        //может не надо радиус заново искать?
        //        float radius = (float)Math.Sqrt(Math.Pow(pointsArray[i].X - center.X, 2) + Math.Pow(pointsArray[i].Y - center.Y, 2));

        //        float rotatedX = center.X + radius * (float)Math.Cos(startAngle[i] + delta);

        //        float rotatedY = center.Y + radius * (-1 * ((float)Math.Sin(startAngle[i] + delta)));//-1*Sin для инверсии Y

        //        pointListR[i] = new Point((int)Math.Round(rotatedX, 0), (int)Math.Round(rotatedY, 0));
        //        pointsList[i] = new Point(pointListR[i].X, pointListR[i].Y);
        //    }

        //    //pointsList[0] = spointListR[1];
        //    //pointsList[1] = pointListR[1];

        //    ////return;

        //}

        //public void Zoom(Point point, Point eLocation)
        //{
        //    startPoint = this.pointsList[1];
        //    this.Update(pointsList[1], eLocation);
        //}


        public override void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
        }
       
    }
}