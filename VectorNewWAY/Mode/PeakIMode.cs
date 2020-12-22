using System;
using System.Drawing;
using System.Windows.Forms;
using VectorNewWAY.Fabrics;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;

namespace VectorNewWAY.Mode
{
    public class PeakIMode : IMode
    {
        SingletonData _singletone;
        PointF _startPoint;
        AFigure _movingFigure;
        AFigure _figure;
        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            _singletone = SingletonData.GetData();
            foreach (AFigure checkFigure in _singletone.FigureList)
            {
                if (checkFigure.IsEdge(e.Location))
                {
                    _figure = checkFigure;
                    _movingFigure = checkFigure;
                    _singletone.FigureList.Remove(_figure);//это удаление первой по значению?
                    _figure.AddPeak();
                    fabric = new FigureNDIFabric();
                    _figure = fabric.CreateFigure(p);
                    _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                    foreach (AFigure figureINList in _singletone.FigureList)
                    {
                        _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(figureINList.Color, figureINList.Width));
                        _singletone.Canvas.Save();
                    }
                    _startPoint = checkFigure.TouchPoint;
                }
            }
        }

        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            throw new NotImplementedException();
        }
    }
}
