using VectorNewWAY.Figures;

namespace VectorNewWAY.Saver
{
    public class ActiveISaver : ISaver
    {
        public void SaveFigure(AFigure figure)
        {
            figure.State.SaveFigure(figure);
        }
    }
}
