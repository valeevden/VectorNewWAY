using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorNewWAY.Mode
{
    public interface IMode
    {
        void MouseDown();
        void MouseMove();
        void MouseUp();
    }
}
