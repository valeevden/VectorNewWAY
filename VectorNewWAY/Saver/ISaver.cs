using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Saver
{
    public interface ISaver
    {
        void SaveFigure(AFigure figure);
    }
}
