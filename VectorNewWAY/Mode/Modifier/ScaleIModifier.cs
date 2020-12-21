using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.Mode.Modifier
{
    public class ScaleIModifier: IModifier
    {
        public void Modify(AFigure figure, PointF delta)
        {
            figure.Scale(delta);
        }
    }
}
