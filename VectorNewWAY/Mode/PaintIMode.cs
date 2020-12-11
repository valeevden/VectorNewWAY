using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorNewWAY.Mode
{
    public class PaintIMode : IMode
    {
        bool _mouseDown;
        MouseEventArgs e;
        AFigure figure;
        public void MouseDown()
        {
            _mouseDown = true;
            if (figure.Reaction is FreeLineIRightClickReaction
                        || figure.Reaction is FreeFigureIRightClickReaction
                        || figure.Reaction is TriangleIRightClickReaction)
            {
                //если фигура начинается то записать первую стартПоинт
                if (figure.started == false)
                {
                    startPoint = e.Location;
                    tmpPoint = e.Location;
                    figure.started = true;
                }
                else
                {
                    tmpPoint = e.Location;
                    startPoint = figure.secondPoint;
                }
            }
            else
            {
                startPoint = e.Location;
                figure = fabrica.CreateFigure(_pen);
            }
        }
        public void MouseMove(MouseEventArgs e)
        {

        }
        public void MouseUp(MouseEventArgs e)
        {

        }
    }
}
