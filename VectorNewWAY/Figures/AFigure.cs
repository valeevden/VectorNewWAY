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
        public List<PointF> PointsList { get; set; }//лист точек - та же информация что и в массиве точек
        public GraphicsPath Path { get; set; }//точки кисти
        //public IRightClickReaction Reaction { get; set; }
        public IPainter Painter { get; set; }//пейнтер фигуры
        //public IFiller Filler { get; }//способ заливки фигуры (либо polygon либо ellipse)
        public Color Color { get; set; }//цвет фигуры
        public IFiller Filler { get; set; }//Заливальщик фигуры
        public IReaction Reaction { get; set; }//Реакция по "" фигуры
        public int Width { get; set; } // Толщина pen
        public int AnglesNumber { get; set; }//количество углов
        public int RotateAngle { get; set; }//Угол поворота

        //public EdgeModifying edgeModifying { get; set; }
        public bool Started { get; set; }
        public bool IsFilled { get; set; }//залито/не залито
        public int MovingPeakIndex;

        public bool IsEdge(Point touchPoint)//метод определяет попали или не попали в грань
        {
            return false;
        }

        public bool IsArea(Point touchPoint)//метод определяет попали или не попали в грань - ЕЩЁ НЕ ДОПИСАН
        {
            return false;
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

        public void Move(Point delta)
        {

        }
        public void Rotate(Point point)
        {

        }
        public void Zoom(Point point, Point eLocation)
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

    }
}
