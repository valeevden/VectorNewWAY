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
        MouseEventArgs _e;
        AFigure _figure;
        Pen _pen;
        Point _startPoint;
        Point _tmpPoint;
        bool _mouseMove;

        public PaintIMode(Pen p, MouseEventArgs e, AFigure figure)
        {
            _pen = p;
            _e = e;
            _figure = figure;
        }

        public void MouseDown()
        {
            
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
                _startPoint = _e.Location;
                _figure = _figure.ReturnItself();
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
            _figure.Update(_startPoint, _e.Location);
            _mouseMove = true; //после записи точки запись заканчивается

            _figure.secondPoint = _e.Location;
            

            GC.Collect();
        }
        public void MouseUp(Pen pen, MouseEventArgs e)
        {
            SingletonFigureList _fL = SingletonFigureList.GetFigureList();
            _fL.FigureList.Add(_figure);
        }
    }
}
