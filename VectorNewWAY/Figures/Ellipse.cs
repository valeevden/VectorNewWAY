﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;//для Brush

namespace VectorNewWAY.Figures
{
    /*
    public class Ellipse : AFigure
    {
        public Ellipse(Pen pen)
        {
            Painter = new EllipseIPainter();
            Reaction = new NoReactionIReaction();
            Filler = new EllipseFiller();
            Started = false;
            Color = pen.Color;
            Width = (int)pen.Width;
            _anglesNumber = 0;
            IsFilled = false;
        }

        public Point[] GetPoints()
        {
            pointsArray = pointsList.ToArray();
            return pointsArray;
        }
        public void Update(Point startP, Point endP)
        {
            Point[] pointsArray = new Point[2];
            pointsArray[0] = startP;
            startPoint = startP;
            pointsArray[1] = endP;
            secondPoint = endP;

            pointsList = pointsArray.ToList();
        }

        public void Set(Point point)
        {
            secondPoint = point;
        }

        public bool IsEdge(Point eLocation)
        {
            RectangleF rectangleForGP = MakeRectangleFromPointsList(pointsList); //Создаем ректангл из листа
            GraphicsPath EllipseGP = new GraphicsPath(); // Создаем новый график пас
            EllipseGP.AddEllipse(rectangleForGP); // Добавляем в график пас новую область видимости

            Array[] PathArray = new Array[] { EllipseGP.PathPoints };

            Pen penGP = new Pen(Color, Width);

            if (EllipseGP.IsOutlineVisible(eLocation, penGP)) // Если точка входит в область видимости 
            {
                touchPoint = eLocation;
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Rotate(Point point)
        {
            RectangleFigure rectangleForGP = MakeRectangleFromPointsList(pointsList); //Создаем ректангл из листа
            GraphicsPath EllipseGP = new GraphicsPath(); // Создаем новый график пас
            EllipseGP.AddEllipse(rectangleForGP); // Добавляем в график пас новую область видимости
            EllipseGP.Flatten();

            //Array[] pathArray = new Array[] { EllipseGP.PathPoints };
            //List<Point> pointListR = MakePointsForExtrenalRectangle(pointsList);
            //Matrix rectMatrix = new Matrix();
            //Matrix rectMatrix = new Matrix(rectangleForGP, EllipseGP.PathPoints);
            //rectMatrix.Rotate(30);
            RectangleF boundRectangle;
            boundRectangle = (EllipseGP.GetBounds());
            pointsArray[0] = new Point((int)boundRectangle.X, (int)boundRectangle.Y);
            pointsArray[1] = new Point((int)boundRectangle.Width + pointsArray[0].X, (int)boundRectangle.Height + pointsArray[0].Y);




            double delta;
            if (point.Y < 0)
            {
                delta = 0.017;//если вверх, то поворачиваем на один градус влево каждый MouseMove
            }
            else
            {
                delta = -0.017;//если вниз, то поворачиваем на один градус влево каждый MouseMove
            }

            delta *= 1.5;//регулировка скорость вращения

            List<Point> pointListR = MakePointsForExtrenalRectangle(pointsList);

            float[] startAngle = new float[2];
            Point center = pointsArray[0];

            for (int i = 0; i < 2; i++)
            {
                float radius = (float)Math.Sqrt(Math.Pow(pointsArray[i].X - center.X, 2) + Math.Pow(pointsArray[i].Y - center.Y, 2));

                //только поняв в какой четверти находит противолежщий катет можно
                //правильно интерпретировать результат, т. к. например арксинусы для
                //углов 10, 170, 190 и 350 градусов будет одинаковыми
                if (pointsArray[i].Y < center.Y)
                {
                    if (pointsArray[i].X < center.X)
                    {
                        startAngle[i] = (float)Math.PI - (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
                    }
                    else
                    {
                        startAngle[i] = (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
                    }
                }
                else
                {
                    if (pointsArray[i].X < center.X)
                    {
                        startAngle[i] = (float)Math.PI + (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
                    }
                    else
                    {
                        startAngle[i] = (float)Math.PI * 2 - (float)Math.Asin((Math.Abs(pointsArray[i].Y - center.Y)) / radius);
                    }
                }
            }

            //поворот точек на delta радиан Против часовой
            for (int i = 0; i < 2; i++)
            {
                //может не надо радиус заново искать?
                float radius = (float)Math.Sqrt(Math.Pow(pointsArray[i].X - center.X, 2) + Math.Pow(pointsArray[i].Y - center.Y, 2));

                float rotatedX = center.X + radius * (float)Math.Cos(startAngle[i] + delta);

                float rotatedY = center.Y + radius * (-1 * ((float)Math.Sin(startAngle[i] + delta)));//-1*Sin для инверсии Y

                pointListR[i] = new Point((int)Math.Round(rotatedX, 0), (int)Math.Round(rotatedY, 0));
                pointsList[i] = new Point(pointListR[i].X, pointListR[i].Y);
            }

            //pointsList[0] = spointListR[1];
            //pointsList[1] = pointListR[1];

            ////return;

        }

        public void Zoom(Point point, Point eLocation)
        {
            startPoint = this.pointsList[1];
            this.Update(pointsList[1], eLocation);
        }


        public void Move(Point delta)
        {
            for (int i = 0; i < pointsList.Count; i++)
            {
                pointsList[i] = new Point(pointsList[i].X + delta.X, pointsList[i].Y + delta.Y);
            }
        }

        public bool IsArea(Point eLocation)
        {
            RectangleF rectangleForGP = MakeRectangleFromPointsList(pointsList); //Создаем ректангл из листа
            GraphicsPath EllipseGP = new GraphicsPath(); // Создаем новый график пас
            EllipseGP.AddEllipse(rectangleForGP); // Добавляем в график пас новую область видимости

            Array[] PathArray = new Array[] { EllipseGP.PathPoints };

            if (EllipseGP.IsVisible(eLocation)) // Если точка входит в область видимости 
            {
                touchPoint = eLocation;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Приватный метод, который принимает на вход массив поинтов и выплевывает ректангл
        private RectangleFigure MakeRectangleFromPointsList(List<Point> point)
        {
            int x = point[0].X;
            int y = point[0].Y;
            int width = point[1].X - point[0].X;
            int height = point[1].Y - point[0].Y;
            RectangleFigure rectangle = new RectangleFigure(x, y, width, height);
            return rectangle;

        }

        private List<Point> MakePointsForExtrenalRectangle(List<Point> point)
        {
            List<Point> pointsListR = new List<Point> { new Point(), new Point(), new Point(), new Point() };
            pointsListR[0] = startPoint;
            pointsListR[1] = new Point(startPoint.X, secondPoint.Y);
            pointsListR[2] = secondPoint;
            pointsListR[3] = new Point(secondPoint.X, startPoint.Y);
            return pointsListR;
        }

        public bool IsPeak(Point peak)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            EllipseFigure ellipse = (EllipseFigure)obj;
            if (!Color.Equals(ellipse.Color) || Width != ellipse.Width || !pointsList.Equals(ellipse.pointsList) || !pointsArray.Equals(ellipse.pointsArray)
                    || !_anglesNumber.Equals(ellipse._anglesNumber) || !Filler.Equals(ellipse.Filler) || !Reaction.Equals(ellipse.Reaction)
                    || !Painter.Equals(ellipse.Painter))
            {
                return false;
            }
            return true;
        }
    }
    */
}