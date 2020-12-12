using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorNewWAY.Painters
{
    public class PolygonIPainter //: IPainter
    {
        public void DrawFigure(Pen pen, Graphics graphics, Point[] points)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //взможно нужно перенести GetPoints прямо сюда, а аргументе принимать лист
            graphics.DrawPolygon(pen, points);
        }
    }
}
