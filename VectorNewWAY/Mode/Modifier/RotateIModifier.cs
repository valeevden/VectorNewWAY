using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.Mode.Modifier
{
    public class RotateIModifier: IModifier
    {
        public void Modify(AFigure figure, PointF delta)
        {
            figure.Rotate(delta.X/3);
        }
    }
}
