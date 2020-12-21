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
using VectorNewWAY.Mode.Modifier;

namespace VectorNewWAY.Mode
{
    public abstract class AModifierIMode : IMode
    {
        public IModifier Modifier;
        
        public SingletonData _singletone;
        public AFigure _modifyingFigure;
        public PointF _startPoint;
        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            _modifyingFigure = null;
            foreach (AFigure checkFigure in _singletone.FigureList)
            {
                if (checkFigure.IsEdge(e.Location) || (checkFigure.IsArea(e.Location) && checkFigure.IsFilled))
                {
                    _modifyingFigure = checkFigure;
                    _singletone.FigureList.Remove(checkFigure);
                    _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                    DrawAll();
                    _startPoint = checkFigure.TouchPoint;
                    break;
                }
            }
        }

        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            if (_modifyingFigure != null)
            {
                PointF delta = new PointF(e.X - _startPoint.X, e.Y - _startPoint.Y);

                _startPoint = e.Location;

                Modifier.Modify(_modifyingFigure, delta);

                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_modifyingFigure, new Pen(_modifyingFigure.Color, _modifyingFigure.Width));
                // pictureBox1.Image = canvas.DrawIt(movingFigure, new Pen(movingFigure.Color, movingFigure.Width));

                GC.Collect();
            }
        }

        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            if (_modifyingFigure != null)
            {
                _singletone.FigureList.Add(_modifyingFigure);
                _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                DrawAll();
            }
        }

        private void DrawAll()
        {
            foreach (AFigure figureINList in _singletone.FigureList)
            {
                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(_modifyingFigure.Color, _modifyingFigure.Width));
                _singletone.Canvas.Save();
            }
        }
    }
}
