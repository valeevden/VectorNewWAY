using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using VectorNewWAY.Fillers;
using VectorNewWAY.Reaction;
using VectorNewWAY.Painters;
//using PaintForSchool.RightClickReaction;


namespace VectorNewWAY.Figures
{
    public abstract class AFigure
    {
        public EdgeMod Edge;
        public PointF StartPoint { get; set; }//точка mouseDown
        public PointF SecondPoint { get; set; }//точка mouseUp
        public PointF TmpPoint { get; set; }
        public PointF TouchPoint { get; set; }//точка касания при перемещении, вращении или заливке фигуры
        public PointF[] PointsArray { get; set; }//массив точек фигуры
        public Matrix RotateMatrix { get; set; }
        public List<PointF> PointsList { get; set; }//лист точек - та же информация что и в массиве точек
        public GraphicsPath Path { get; set; }//точки кисти
        public IPainter Painter { get; set; }//пейнтер фигуры
        public Color Color { get; set; }//цвет фигуры
        public int Width { get; set; } // Толщина pen
        public IFiller Filler { get; set; }//Заливальщик фигуры
        public IReaction Reaction { get; set; }//Реакция по "" фигуры
        public int AnglesNumber { get; set; }//количество углов
        public float RotateAngle { get; set; }//Угол поворота
        public PointF Center { get; set; }
        public float SizeX { get; set; } // Размер мастшаба по Х 
        public float SizeY { get; set; } // Размер мастшаба по Y

        public bool Started { get; set; }
        public bool IsFilled { get; set; }//залито/не залито
        public int MovingPeakIndex;

        public AFigure(Pen pen)
        {
            PointsList = new List<PointF>() { new PointF(0, 0)};
            Color = pen.Color;
            Width = (int)pen.Width;
            SizeX = 0;
            SizeY = 0;
            Started = false;
            IsFilled = false;
            RotateMatrix = new Matrix();
            Center = new PointF(0, 0);
            Edge = new EdgeMod();
        }
        public virtual GraphicsPath GetPath() 
        {
            MakePathFromLine();
            Path.Transform(RotateMatrix);
            return Path;
        }

        public virtual PointF SetCenter()
        {
            Center = new PointF(0, 0);
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            return Center;
        }

        public virtual bool IsEdge(PointF touchPoint)
        {
            Pen penForEdge = new Pen(Color, Width);

            if (Path.IsOutlineVisible(touchPoint, penForEdge)) 
            {
                TouchPoint = touchPoint;
                return  true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool IsArea(PointF touchPoint)
        {
            if (Path.IsVisible(touchPoint)) 
            {
                TouchPoint = touchPoint;
                return true;
            }
            else
            {
                return false;
            }
        }


        public virtual void Update(PointF startPoint, PointF endPoint)
        {

        }

        public virtual void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
        }

        public virtual void Rotate(float RotateAngle)
        {
            {
                Center = SetCenter();
                RotateMatrix.RotateAt(RotateAngle, Center);
                Path.Transform(RotateMatrix);
            }
        }

        public virtual void Scale(PointF point)
        {
            RectangleF rectangle = MakeRectangleFromPointsList();
            SizeX = SizeX - point.X / 2 * rectangle.Width * 0.008f;
            SizeY = SizeY - point.X / 2 * rectangle.Height * 0.008f;
        }
        

        public bool IsPeak(PointF pointFromForm)
        {
            foreach (PointF target in PointsList)
            {
                if (
                    (target.X - 10 < pointFromForm.X) && (target.X + 10 > pointFromForm.X)
                    &&
                    (target.Y - 10 < pointFromForm.Y) && (target.Y + 10 > pointFromForm.Y)
                    )
                {
                    TouchPoint = pointFromForm;
                    return true;
                }
            }
            return false;
        }

        public void AddPeak()
        {
            if (Edge.EdgeNumber == 1)
            {
                PointsList.Add(TouchPoint);
            }
            else
            {
                PointsList.Insert(Edge.EdgeNumber - 1, TouchPoint);

            }
            AnglesNumber++;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected GraphicsPath MakePathFromLine()
        {
            Path = new GraphicsPath();
            Path.StartFigure();
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Path.AddLine(PointsList[i], PointsList[i + 1]);
            }
            return Path;
        }

        public virtual RectangleF MakeRectangleFromPointsList()
        {
            float width = PointsList[1].X - PointsList[0].X;
            float height = PointsList[1].Y - PointsList[0].Y;
            RectangleF rectangle = new RectangleF(PointsList[0].X, PointsList[0].Y, width, height);
            return rectangle;
        }
    }
}
