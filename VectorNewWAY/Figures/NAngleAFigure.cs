using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using VectorNewWAY.Painters;

namespace VectorNewWAY.Figures
{
    class NAngleAFigure: AFigure
    {
        public NAngleAFigure(int numberFromNumeric, Pen pen): base(pen)
        {
            AnglesNumber = numberFromNumeric;
            Painter = new PathIPainter();
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
        private RectangleF MakeRectangleFromPointsList()
        {
            float width = PointsList[1].X - PointsList[0].X;
            float height = PointsList[1].Y - PointsList[0].Y;

            RectangleF rectangle = new RectangleF(PointsList[0].X, PointsList[0].Y, width, height);

            Path = new GraphicsPath();
            Path.AddEllipse(rectangle);
            rectangle = Path.GetBounds();
            Path = new GraphicsPath();

            return rectangle;
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

    }
}
