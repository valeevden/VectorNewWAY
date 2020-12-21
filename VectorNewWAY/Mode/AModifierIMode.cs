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
        public PointF _previousPoint;
        public virtual void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            _modifyingFigure = null;
            foreach (AFigure checkFigure in _singletone.FigureList)
            {
                if (checkFigure.IsEdge(e.Location) || (checkFigure.IsArea(e.Location) && checkFigure.IsFilled))
                {
                    _modifyingFigure = checkFigure;
                    _singletone.FigureList.Remove(checkFigure);
                    DrawAll();
                    _previousPoint = checkFigure.TouchPoint;
                    break;
                }
            }
        }

        public virtual void MouseMove(Pen pen, MouseEventArgs e)
        {
            if (_modifyingFigure != null)
            {
                PointF delta = new PointF(e.X - _previousPoint.X, e.Y - _previousPoint.Y);

                _previousPoint = e.Location;

                Modifier.Modify(_modifyingFigure, delta);

                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_modifyingFigure, new Pen(_modifyingFigure.Color, _modifyingFigure.Width));

                GC.Collect();
            }
        }

        public virtual void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            if (_modifyingFigure != null)
            {
                _singletone.FigureList.Add(_modifyingFigure);
                
                DrawAll();
            }
        }

        private void DrawAll()
        {
            _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
            foreach (AFigure figureINList in _singletone.FigureList)
            {
                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(_modifyingFigure.Color, _modifyingFigure.Width));
                _singletone.Canvas.Save();
            }
        }
    }
}
