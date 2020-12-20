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
using VectorNewWAY.Reaction;

namespace VectorNewWAY.Mode
{
    public class PaintIMode : IMode
    {
        AFigure _figure;
        PointF _startPoint;
        bool _mouseMove = false;
        SingletonData _singletone;

        public PaintIMode()
        {
           
        }

        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            
            _singletone = SingletonData.GetData();

            if (fabric is LineNDIFabric
                        || fabric is FigureNDIFabric
                        || fabric is Triangle3DIFabric)
            {
                //если фигура начинается то записать первую стартПоинт
                if (_figure == null)
                {
                    _figure = fabric.CreateFigure(p);
                    _startPoint = e.Location;
                    _figure.TmpPoint = e.Location;
                    
                }
                else
                {
                    _figure.TmpPoint = e.Location;
                    _startPoint = _figure.SecondPoint;
                }
            }
            else
            {
                _startPoint = e.Location;
                _figure = fabric.CreateFigure(p);
                _figure.Set();
            }
        }
        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            if ((_figure.Reaction is FreeLineIRightClickReaction 
                || _figure.Reaction is FreeFigureIRightClickReaction 
                || _figure.Reaction is Triangle3DIRightClickReaction) && (_mouseMove == false))
            {
                _figure.AnglesNumber++;
                _figure.PointsList.Add(_figure.TmpPoint); //точка добавляется в лист в начале движения мыши
            }
            _figure.Update(_startPoint, e.Location);
            _mouseMove = true; //после записи точки запись заканчивается
            _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, pen);
            _figure.SecondPoint = e.Location;
            if (_figure is BrushIFigure) _startPoint = e.Location;

            GC.Collect();
        }
        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            _mouseMove = false;

            ((AOneMoveFigure)_figure).FinalizeFigure();

            if (e.Button == MouseButtons.Right && _figure != null)
            {
                if (_figure.Reaction is FreeLineIRightClickReaction 
                    || _figure.Reaction is FreeFigureIRightClickReaction)
                {
                    _figure.Reaction.Do();
                    SingletonData _fL = SingletonData.GetData();
                    _fL.FigureList.Add(_figure);
                    
                    _figure = null;
                }
                else
                {
                    _figure.Reaction.Do();
                }
            }
        }
    }
}
