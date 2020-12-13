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
    public class SquareFigure : AFigure
    {
        public SquareFigure(Pen pen) : base(pen)
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

        //private squareF MakeSquareFromPointsList()
        //{
        //    float width = PointsList[1].X - PointsList[0].X;
        //    float height = PointsList[1].Y - PointsList[0].Y;
        //    squareF square = new squareF(PointsList[0].X, PointsList[0].Y, width, height);
        //    return square;
        //}  

        public override bool IsEdge(PointF eLocation)
        {
            Path = new GraphicsPath();
            SquareF square = MakesquareFromPointsList();
            square.Inflate(SizeX, SizeY);
            Path.AddSquare(square);
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
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Path.AddRectangle(rectangle);
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
        public override void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            Path.AddRectangle(rectangle);
            Path.Transform(RotateMatrix);

        }

        public override void Rotate(float rotateAngle)
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            Path.AddRectangle(rectangle);
            RotateMatrix.RotateAt(rotateAngle, Center);
            Path.Transform(RotateMatrix);
        }

        public override void Scale(PointF point)
        {
            RectangleF rectangle = MakeRectangleFromPointsList();

            SizeX = SizeX - point.X / 2 * rectangle.Width * 0.008f;
            SizeY = SizeY - point.X / 2 * rectangle.Height * 0.008f;
        }
        public override GraphicsPath GetPath() //Получаем Path
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();

            rectangle.Inflate(SizeX, SizeY);
            Path.AddRectangle(rectangle);
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            Path.Transform(ScaleMatrix);
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override bool Equals(object obj)
        {
            SquareFigure square = (SquareFigure)obj;
            if (!Color.Equals(square.Color) || Width != square.Width || !PointsList.Equals(square.PointsList)
                     || !AnglesNumber.Equals(square.AnglesNumber) || !Filler.Equals(square.Filler) || !Reaction.Equals(square.Reaction)
                     || !Painter.Equals(square.Painter) || !RotateMatrix.Equals(square.RotateMatrix) || !Path.Equals(square.Path))
            {
                return false;
            }
            return true;
        }
    }


}
