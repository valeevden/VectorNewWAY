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
            figure = null;

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
                    figure = checkFigure;
                    _movingFigure = checkFigure;
                    _singletone.FigureList.Remove(figure);
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

        public AFigure MouseMove(Pen pen, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public AFigure MouseUp(Pen pen, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
