using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
   public class BrushFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
            return new BrushIFigure(pen);
        }
    }
}
