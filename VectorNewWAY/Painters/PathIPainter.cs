using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorNewWAY.Painters
{
   public class PathIPainter : IPainter
    {
        public void DrawFigure(Pen pen, Graphics graphics, GraphicsPath Path)
        {
            graphics.DrawPath(pen, Path);
        }
    }
}
