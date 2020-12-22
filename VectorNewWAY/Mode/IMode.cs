using System.Windows.Forms;
using System.Drawing;
using VectorNewWAY.Figures;
using VectorNewWAY.Fabrics;

namespace VectorNewWAY.Mode
{
    public interface IMode
    {
        void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric);
        void MouseMove(Pen pen, MouseEventArgs e);
        void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric);
    }
}
