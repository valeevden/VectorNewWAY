using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public class FigureNDIFabric : IFigureFabric
    {
        AFigure deadFigure;
        public FigureNDIFabric()
        {

        }
        public FigureNDIFabric(AFigure deadFigureFromForm)
        {
            deadFigure = deadFigureFromForm;
        }
        public AFigure CreateFigure(Pen pen)
        {
            if (deadFigure == null)
            {
                return new FigureNDIFigure(pen);
            }
            else
            {
                return new FigureNDIFigure(deadFigure, pen);
            }
        }
    }
}
