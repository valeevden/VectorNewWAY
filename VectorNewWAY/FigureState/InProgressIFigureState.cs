using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.FigureState
{
    public class InProgressIFigureState: IFigureState
    {
        public void Set(PointF eLocation, AFigure figure)
        {
          
        }
        public void SaveFigure(AFigure figure)
        {
            figure.State = new FinishedIFigureState();
            figure.ApplySaver();
        }
    }
}
