using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorNewWAY.Painters;
using VectorNewWAY.RightClickReaction;
using VectorNewWAY.Fillers;

namespace VectorNewWAY.Figures
{
    class NAngleAFigure: AOneMoveFigure
    {
        public NAngleAFigure(int numberFromNumeric, Pen pen): base(pen)
        {
            AnglesNumber = numberFromNumeric;
            Painter = new PathIPainter();
            Filler = new PathFiller();
        }

        public override GraphicsPath GetPath() 
        {
            MakePathFromLine();
            Path.CloseFigure();
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
        }

        public override PointF SetCenter()
        {
            Center = new PointF(0, 0);
            for (int i = 0; i < AnglesNumber; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            return Center;
        }
    }
}
