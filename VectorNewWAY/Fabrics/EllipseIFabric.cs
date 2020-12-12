﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    class EllipseIFabric : IFigureFabric
    {
        public AFigure CreateFigure(Pen pen)
        {
          return new EllipseFigure(pen);
        }
    }
}