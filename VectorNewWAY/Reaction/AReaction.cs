using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;

namespace VectorNewWAY.Reaction
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
        public virtual void Do()
        {
            Singletone.FigureList.Add(Figure);
        }
    }
}
