﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using VectorNewWAY.Mode;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Fabrics
{
    public interface IModeFabric
    {
        IMode CreateMode(Pen p, MouseEventArgs e, AFigure figure);
    }
}
