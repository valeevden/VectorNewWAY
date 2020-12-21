using System.Windows.Forms;
using System.Drawing;
using VectorNewWAY.Figures;
using VectorNewWAY.Fabrics;

namespace VectorNewWAY.Mode
{
    public class FillAMode : AModifierIMode
    {

        public override void MouseMove(Pen pen, MouseEventArgs e)
        {

        }


        public override void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            if (_modifyingFigure != null)
            {
                _modifyingFigure.IsFilled = true;
                _modifyingFigure.Color = pen.Color;
                _singletone.FigureList.Add(_modifyingFigure);
                _singletone.PictureBox1.Image = _singletone.Canvas.Clear();
                foreach (AFigure figureINList in _singletone.FigureList)
                {
                    _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(figureINList, new Pen(figureINList.Color, figureINList.Width));
                }
                _singletone.Canvas.Save();
            }
        }
    }
}
