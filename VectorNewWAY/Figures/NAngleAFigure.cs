using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorNewWAY.Painters;
using VectorNewWAY.Reaction;
using VectorNewWAY.Fillers;

namespace VectorNewWAY.Figures
{
    class NAngleAFigure: AFigure
    {
        public NAngleAFigure(int numberFromNumeric, Pen pen): base(pen)
        {
            AnglesNumber = numberFromNumeric;
            Painter = new PathIPainter();
            Reaction = new NoReactionIReaction();
            Filler = new PathFiller();
        }
        public override GraphicsPath GetPath() //Получаем Path
        {
            
            Path = new GraphicsPath();
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Path.AddLine(PointsList[i], PointsList[i + 1]);
            }
            Path.CloseFigure();
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));

            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startPoint, PointF endPoint)
        {
            PointsList = new List<PointF>();
            float externalRadius;//радиус описанной окружности
            float fullRoundInRad = (float)Math.PI * 2;//Число Пи умноженное на два

            float sector = fullRoundInRad / AnglesNumber;
            externalRadius = (float)Math.Sqrt(Math.Pow(Math.Abs(endPoint.X - startPoint.X), 2) + Math.Pow(Math.Abs(endPoint.Y - startPoint.Y), 2));

            for (int i = 0; i < AnglesNumber; i++)
            {

                PointsList.Add(new PointF(startPoint.X + (((float)Math.Round(externalRadius, 0)) * (float)Math.Sin(sector * (i + 1))), startPoint.Y + (float)((Math.Round(externalRadius, 0)) * Math.Cos(sector * (i + 1)))));
            }
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
        }
        public override bool IsEdge(PointF eLocation)
        {
            Path = new GraphicsPath();
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Path.AddLine(PointsList[i], PointsList[i + 1]);
            }
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            Path.Transform(RotateMatrix);
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
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Path.AddLine(PointsList[i], PointsList[i + 1]);
            }
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            Path.Transform(RotateMatrix);
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
        public override void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
        }
        public override void Rotate(float rotateAngle)
        {
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count; i++)//у Лилии из PointsList.Count вычиталась 1, наверное для незамкнутого построения
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            RotateMatrix.RotateAt(rotateAngle, Center);
            Path.Transform(RotateMatrix);
        }
    }
}
