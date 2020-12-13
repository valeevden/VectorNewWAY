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
    public class FillIMode : IMode
    {
        SingletonData _singletone;
        AFigure _fillFigure;
        PointF _startPoint;
        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            _fillFigure = null;
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
                if (checkFigure.IsEdge(e.Location) || (checkFigure.IsArea(e.Location)))
                {
                    _fillFigure = checkFigure;
                    _fillFigure.IsFilled = true;
                    _singletone.FigureList.Remove(checkFigure);
                    _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                    foreach (AFigure figureINList in _singletone.FigureList)
                    {
                        _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(figureINList.Color, figureINList.Width));
                        _singletone.Canvas.Save();
                    }
                    _fillFigure.Color = p.Color;
                    _singletone.Canvas.DrawIt(_fillFigure, p);
                    _startPoint = checkFigure.TouchPoint;
                    break;
                }
            }
        }

        
        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            
        }

        

        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            _singletone.FigureList.Add(_fillFigure);
            _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
            foreach (AFigure figureINList in _singletone.FigureList)
            {
                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(figureINList.Color, figureINList.Width));
            }
            _singletone.Canvas.Save();
        }
    }
}
