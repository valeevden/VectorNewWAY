using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
   public  class SquareIFabric :IFigureFabric 
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new SquareFigure(pen);
        }
    }
}
