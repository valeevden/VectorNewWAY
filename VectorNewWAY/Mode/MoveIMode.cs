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
        SingletonObj _singletone;
        AFigure _movingFigure;

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
                    Form1.pictureBox1.Image = canvas.Clear();
                    DrawAll();
                    startPoint = checkFigure.touchPoint;
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
