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
using VectorNewWAY.FigureFinalizer;

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
            if ((_figure is AFreeBuild) && (_mouseMove == false))
            {
                _figure.AnglesNumber++;
                _figure.PointsList.Add(_figure.TmpPoint);
            }
            
            _figure.Update(_startPoint, e.Location);
            _mouseMove = true;
            _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, pen);
            _figure.SecondPoint = e.Location;
            
            if (_figure is BrushIFigure) _startPoint = e.Location;

            GC.Collect();
        }
        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            _mouseMove = false;

            _figure.ApplyFinalizer();

            if (e.Button == MouseButtons.Right && _figure is AFreeBuild)
            {
                _figure.Finalizer = new ActiveIFinalizer();
                _figure.ApplyFinalizer();
            }
        }
    }
}
