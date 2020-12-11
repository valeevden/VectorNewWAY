using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Painters;

namespace VectorNewWAY.Figures
{
    public class RectangleFigure : AFigure
    {
        public RectangleFigure()
        {
            Painter = new PolygonIPainter();
        }
        public override AFigure ReturnItself()
        {
            return new RectangleFigure();
        }
    }
}
