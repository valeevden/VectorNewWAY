using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorNewWAY.Fillers
{
    public class PathFiller : IFiller
    {
        GraphicsPath Path;
        public PathFiller()
        {

        }
        public PathFiller(GraphicsPath path)
        {
            Path = path;
        }
        public void FillFigure(Pen pen, Graphics graphics, Point[] points)
        {
            graphics.FillPath(new SolidBrush(pen.Color), Path);
        }
    }
}
