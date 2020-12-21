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
using VectorNewWAY.RightClickReaction;
using VectorNewWAY.Saver;
using VectorNewWAY.FigureState;

namespace VectorNewWAY.Mode
{
    public class PaintIMode : IMode
    {
        AFigure _figure;
        PointF _brushStartPoint;
        bool _mouseMove = false;
        SingletonData _singletone;

        public PaintIMode()
        {
           
        }

        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            
            _singletone = SingletonData.GetData();
            if (_figure == null || _figure.State is FinishedIFigureState)
            {
                _figure = fabric.CreateFigure(p);
            }

            _figure.Set(e.Location);

            if (_figure is BrushIFigure) _brushStartPoint = e.Location;
        }
        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            _figure.Update(_brushStartPoint, e.Location);
            _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, pen);
            
            if (_figure is BrushIFigure) _brushStartPoint = e.Location;

            GC.Collect();
        }
        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            _mouseMove = false;

            _figure.ApplySaver();

            if (e.Button == MouseButtons.Right && _figure is AFreeBuild)
            {
                _figure.RightClickReaction.FinishBuilding();
                _figure.Saver = new ActiveISaver();
                _figure.ApplySaver();
            }
        }
    }
}
