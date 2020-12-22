using System.Windows.Forms;
using System.Drawing;
using VectorNewWAY.Figures;
using VectorNewWAY.Fabrics;

namespace VectorNewWAY.Mode
{
    public class FillAMode : AModifierIMode
    {
        public override void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            foreach (AFigure checkFigure in _singletone.FigureList)
            {
                if (checkFigure.IsEdge(e.Location) || checkFigure.IsArea(e.Location))
                {
                    checkFigure.IsFilled = true;
                    checkFigure.Color = p.Color;
                    DrawAll();
                    break;
                }
            }
        }

        public override void MouseMove(Pen pen, MouseEventArgs e)
        {
            return;
        }


        public override void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            return;
        }
    }
}
