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
    public class FigureNDIFigure : AFigure
    {
        public FigureNDIFigure(Pen pen) : base(pen)
        {
            //Painter = new PolygonIPainter();
            Reaction = new FreeFigureIRightClickReaction(this);
            PointsList = new List<PointF> { new PointF(0, 0) };
            Painter = new PathIPainter();
            Started = false;
            AnglesNumber = 1;
            IsFilled = false;
            RotateMatrix = new Matrix();
            SizeX = 0;
            SizeY = 0;
            Filler = new PathFiller();
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            //отрисовывается весь путь во время маус мува
            //последняя линяя двигается
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
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            //PointsList = new List<PointF>();
            PointsList[AnglesNumber - 2] = startP;
            PointsList[AnglesNumber - 1] = endP;
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
