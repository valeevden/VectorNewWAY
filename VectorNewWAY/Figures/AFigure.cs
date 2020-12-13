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
//using PaintForSchool.RightClickReaction;


namespace VectorNewWAY.Figures
{
    public abstract class AFigure 
    {
        public PointF StartPoint { get; set; }//точка mouseDown
        public PointF SecondPoint { get; set; }//точка mouseUp
        public PointF TmpPoint { get; set; }
        public PointF TouchPoint { get; set; }//точка касания при перемещении, вращении или заливке фигуры
        public PointF[] PointsArray { get; set; }//массив точек фигуры
        public Matrix RotateMatrix { get; set; }
        public List<PointF> PointsList { get; set; }//лист точек - та же информация что и в массиве точек
        public GraphicsPath Path { get; set; }//точки кисти
        public IPainter Painter { get; set; }//пейнтер фигуры
        //public IFiller Filler { get; }//способ заливки фигуры (либо polygon либо ellipse)
        public Color Color { get; set; }//цвет фигуры
        public IFiller Filler { get; set; }//Заливальщик фигуры
        public IReaction Reaction { get; set; }//Реакция по "" фигуры
        public int Width { get; set; } // Толщина pen
        public int AnglesNumber { get; set; }//количество углов
        public float RotateAngle { get; set; }//Угол поворота
        public PointF Center { get; set; }
        public float SizeX { get; set; } // Размер мастшаба по Х 
        public float SizeY { get; set; } // Размер мастшаба по Y

        //public EdgeModifying edgeModifying { get; set; }
        public bool Started { get; set; }
        public bool IsFilled { get; set; }//залито/не залито
        public int MovingPeakIndex;
        
        public  AFigure (Pen pen)
        {
            Color = pen.Color;
            Width = (int)pen.Width;
            SizeX = 0;
            SizeY = 0;
            Started = false;
            IsFilled = false;
        }

        public virtual bool IsEdge(PointF touchPoint)//метод определяет попали или не попали в грань
        {
            Pen penGP = new Pen(Color, Width);
            if (Path.IsOutlineVisible(touchPoint, penGP)) // Если точка входит в область видимости 
            {
                TouchPoint = touchPoint;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool IsArea(PointF touchPoint)//метод определяет попали или не попали в грань - ЕЩЁ НЕ ДОПИСАН
        {
            if (Path.IsVisible(touchPoint)) // Если точка входит в область видимости 
            {
                TouchPoint = touchPoint;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual GraphicsPath GetPath() //Получаем Path
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(1,1), new Point(20,20));
            return gp;
        } 
        
        public virtual void Update(PointF startPoint, PointF endPoint)
        {

        }//получение точек для промежуточной прорисовки

        public virtual void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
        }
        public virtual void Rotate(float RotateAngle)
        {

        }
        public virtual void Scale(PointF point)
        {
           
        }
        //public void MovePeak(Point peakDelta)
        //{
        //    if (edgeModifying.edgeNumber == 1)
        //    {
        //        pointsList[_anglesNumber - 1] = new Point(pointsList[_anglesNumber - 1].X + peakDelta.X,
        //            pointsList[_anglesNumber - 1].Y + peakDelta.Y);
        //    }
        //    else
        //    {

        //        pointsList[edgeModifying.edgeNumber - 1] =
        //        new Point(
        //        pointsList[edgeModifying.edgeNumber - 1].X + peakDelta.X,
        //        pointsList[edgeModifying.edgeNumber - 1].Y + peakDelta.Y);
        //    }
        //}
        //public void AddPeak()
        //{
        //    if (edgeModifying.edgeNumber == 1)
        //    {
        //        pointsList.Add(touchPoint);
        //    }
        //    else
        //    {
        //        pointsList.Insert(edgeModifying.edgeNumber - 1, touchPoint);

        //    }
        //    _anglesNumber++;
        //}
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }
}
