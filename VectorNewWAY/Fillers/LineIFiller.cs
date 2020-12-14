using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorNewWAY.Fillers
{
    public class LineIFiller : IFiller
    {
        public void FillFigure(Pen pen, Graphics graphics, GraphicsPath Path)
        {
            graphics.DrawPath(pen, Path);
        }
    }
}
