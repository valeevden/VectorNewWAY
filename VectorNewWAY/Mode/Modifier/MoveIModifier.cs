using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Mode.Modifier
{
    public class MoveIModifier : IModifier
    {
        public void Modify(AFigure figure, PointF delta)
        {
            figure.Move(delta);
        }
    }
}
