using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using VectorNewWAY.Mode;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;
using VectorNewWAY.Fabrics;

namespace VectorNewWAY.Mode
{
    public class PaintIMode : IMode
    {
        AFigure _figure;
        PointF _startPoint;
        bool _mouseMove;
        SingletonData _singletone;

        public PaintIMode()
        {
           
        }

        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            //if (_figure.Reaction is FreeLineIRightClickReaction
            //            || _figure.Reaction is FreeFigureIRightClickReaction
            //            || _figure.Reaction is TriangleIRightClickReaction)
            //{
            //    //если фигура начинается то записать первую стартПоинт
            //    if (_figure.Started == false)
            //    {
            //        _startPoint = _e.Location;
            //        _tmpPoint = _e.Location;
            //        _figure.Started = true;
            //    }
            //    else
            //    {
            //        _tmpPoint = _e.Location;
            //        _startPoint = _figure.secondPoint;
            //    }
            //}
            //else
            //{
                _startPoint = e.Location;
                _figure = fabric.CreateFigure(p);
            //}
        }
        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            //if ((_figure.Reaction is FreeLineIRightClickReaction
            //               || _figure.Reaction is FreeFigureIRightClickReaction
            //               || _figure.Reaction is TriangleIRightClickReaction) && (mouseMove == false))
            //{
            //    _figure._anglesNumber++;
            //    _figure.pointsList.Add(tmpPoint); //точка добавляется в лист в начале движения мыши
            //}
            _figure.Update(_startPoint, e.Location);
            _mouseMove = true; //после записи точки запись заканчивается
            _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, pen);
            _figure.SecondPoint = e.Location;

            GC.Collect();
        }
        public void MouseUp(Pen pen, MouseEventArgs e)
        {
            SingletonData _fL = SingletonData.GetData();
            _fL.FigureList.Add(_figure);
        }
    }
}
