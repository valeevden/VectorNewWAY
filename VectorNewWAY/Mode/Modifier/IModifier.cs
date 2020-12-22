
using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.Mode.Modifier
{
    public interface IModifier
    {
        void Modify(AFigure figure, PointF delta);
    }
}
