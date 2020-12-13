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
    public class ScaleIMode : IMode
    {
        SingletonData _singletone;
        AFigure _scaleFigure;
        PointF _startPoint;
        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            _scaleFigure = null;
            foreach (AFigure checkFigure in _singletone.FigureList)
            {
                if (checkFigure.IsEdge(e.Location) || (checkFigure.IsArea(e.Location) && checkFigure.IsFilled))
                {
                    _scaleFigure = checkFigure;
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
            if (_scaleFigure != null)
            {
                PointF delta = new PointF(e.X - _startPoint.X, e.Y - _startPoint.Y);
                _startPoint = e.Location;

                _scaleFigure.Scale(delta);
                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_scaleFigure, new Pen(_scaleFigure.Color, _scaleFigure.Width));

                GC.Collect();
            }
        }

        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            if (_scaleFigure != null)
            {
                _singletone.FigureList.Add(_scaleFigure);
                _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                foreach (AFigure figureINList in _singletone.FigureList)
                {
                    _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(_scaleFigure.Color, _scaleFigure.Width));
                }
                _singletone.Canvas.Save();
            }
        }
    }
}
