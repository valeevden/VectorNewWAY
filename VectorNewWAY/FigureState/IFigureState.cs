using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.FigureState
{
    public interface IFigureState
    {
        void Set(PointF e, AFigure figure);
        void SaveFigure(AFigure figure);
    }
}
