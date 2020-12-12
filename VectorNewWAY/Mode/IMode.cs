using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using VectorNewWAY.Figures;

namespace VectorNewWAY.Mode
{
    public interface IMode
    {
        void MouseDown(Pen p, MouseEventArgs e, AFigure figure);
        void MouseMove(Pen pen, MouseEventArgs e);
        void MouseUp(Pen pen, MouseEventArgs e);
    }
}
