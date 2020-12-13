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
    public class Line2DIFigure : AFigure
    {
        public Line2DIFigure(Pen pen)
        {
            //Painter = new PolygonIPainter();
            Reaction = new NoReactionIReaction();
            Painter = new PathIPainter();
            Started = false;
            Color = pen.Color;
            Width = (int)pen.Width;
            AnglesNumber = 1;
            IsFilled = false;
            ScaleMatrix = new Matrix();
            RotateMatrix = new Matrix();
            SizeX = 0;
            SizeY = 0;
            PointsList = new List<PointF> { };
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            Path = new GraphicsPath();
            
            Path.AddLine(PointsList[0], PointsList[1]);
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            List<PointF> currentList = new List<PointF> { startP, endP };
            PointsList.Add(startP);
            PointsList.Add(endP);
            PointsList[AnglesNumber - 2] = currentList[0];
            PointsList[AnglesNumber - 1] = currentList[1];
        }

        

        public override bool IsEdge(PointF eLocation)
        {
            Path = new GraphicsPath();
            
            
            Path.AddLine(PointsList[0], PointsList[1]);
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
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

            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
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
