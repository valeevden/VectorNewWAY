
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;

namespace VectorNewWAY.RightClickReaction
{
    public abstract class AReaction
    {
        public AFigure Figure;
        public SingletonData Singletone;
        public AReaction(AFigure figure)
        {
            Figure = figure;
            Singletone = SingletonData.GetData();
        }
        public virtual void FinishBuilding()
        {
            
        }
    }
}
