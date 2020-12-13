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
   public class RectangleFigure : AFigure
    {
        public RectangleFigure(Pen pen) : base(pen)
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
            Path.AddRectangle(rectangle);
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











        public override bool Equals(object obj)
        {
            RectangleFigure rectangle = (RectangleFigure)obj;
            if (!Color.Equals(rectangle.Color) || Width != rectangle.Width || !PointsList.Equals(rectangle.PointsList) || !PointsArray.Equals(rectangle.PointsArray)
                     || !AnglesNumber.Equals(rectangle.AnglesNumber) || !Filler.Equals(rectangle.Filler) || !Reaction.Equals(rectangle.Reaction)
                     || !Painter.Equals(rectangle.Painter)|| ! RotateMatrix.Equals (rectangle.RotateMatrix) || !Path.Equals (rectangle.Path))
            {
                return false;
            }
            return true;
        }
    }
   
}
