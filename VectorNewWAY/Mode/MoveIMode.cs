using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorNewWAY.Fabrics;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;

namespace VectorNewWAY.Mode
{
    public class MoveIMode : IMode
    {
        SingletonData _singletone;
        AFigure _movingFigure;
        PointF _startPoint;

        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            _movingFigure = null;
            foreach (AFigure checkFigure in _singletone.FigureList)
            {
                //if (checkFigure.IsPeak(e.Location))
                //{
                //    _figure = checkFigure;
                //    movingFigure = checkFigure;
                //    figuresList.Remove(_figure);
                //    pictureBox1.Image = canvas.Clear();
                //    DrawAll();
                //    startPoint = checkFigure.touchPoint;
                //    mode = "PEAK";
                //    break;
                //}
                if (checkFigure.IsEdge(e.Location) || (checkFigure.IsArea(e.Location) && checkFigure.IsFilled))
                {
                    _movingFigure = checkFigure;
                    _singletone.FigureList.Remove(checkFigure);
                    _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                    foreach (AFigure figureINList in _singletone.FigureList)
                    {
                        _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(figureINList.Color, figureINList.Width));
                        _singletone.Canvas.Save();
                    }
                    _startPoint = checkFigure.TouchPoint;
                    break;
                }
            }
        }

        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            if (_movingFigure != null)
            {
                PointF delta = new PointF(e.X - _startPoint.X, e.Y - _startPoint.Y);
                _startPoint = e.Location;

                _movingFigure.Move(delta);
                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_movingFigure, new Pen(_movingFigure.Color, _movingFigure.Width));

                GC.Collect();
            }
            
        }

        public void MouseUp(Pen pen, MouseEventArgs e)
        {
            if (_movingFigure != null)
            {
                _singletone.FigureList.Add(_movingFigure);
                _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                foreach (AFigure figureINList in _singletone.FigureList)
                {
                    _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(_movingFigure.Color, _movingFigure.Width));
                }
                    _singletone.Canvas.Save();
            }

        }
    }
}
