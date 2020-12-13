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
    public class IsoscelesTriangleIFigure : AFigure
    {
        GraphicsPath FullPath;
        public IsoscelesTriangleIFigure(Pen pen) : base(pen)
        {
            //Painter = new PolygonIPainter();
            Reaction = new NoReactionIReaction();
            PointsList = new List<PointF> { new PointF(0, 0) };
            Painter = new PathIPainter();
            Started = false;
            AnglesNumber = 1;
            IsFilled = false;
            RotateMatrix = new Matrix();
            SizeX = 0;
            SizeY = 0;
            FullPath = new GraphicsPath();
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
           
            Path = new GraphicsPath();
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Path.AddLine(PointsList[i], PointsList[i + 1]);
            }
            Path.CloseFigure();
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);

            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointF[] pointsArray = new PointF[3];

            pointsArray[0] = startP;
            pointsArray[1] = endP;
            pointsArray[2] = new PointF((SecondPoint.X - (SecondPoint.X - startP.X) * 2), SecondPoint.Y);

            PointsList = new List<PointF> { };
            PointsList = pointsArray.ToList();
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

            Path.AddLine(PointsList[0], PointsList[1]);
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
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

        public override void Scale(PointF point)
        {

        }

        public override void Rotate(float rotateAngle)
        {
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            RotateMatrix.RotateAt(rotateAngle, Center);
            Path.Transform(RotateMatrix);
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
