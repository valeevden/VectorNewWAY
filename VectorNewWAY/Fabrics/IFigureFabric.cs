using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public interface IFigureFabric
    {
        AFigure CreateFigure(Pen pen);
    }
}
