using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VectorNewWAY.Mode
{
    public interface IMode
    {
        void MouseDown();
        void MouseMove(Pen pen, MouseEventArgs e);
        void MouseUp(Pen pen, MouseEventArgs e);
    }
}
