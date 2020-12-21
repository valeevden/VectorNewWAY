using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorNewWAY.Fabrics;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;
using VectorNewWAY.Mode.Modifier;

namespace VectorNewWAY.Mode
{
    public class MoveAMode : AModifierIMode
    {
        
        public MoveAMode()
        {
            Modifier = new MoveIModifier();
        }

        
    }
}
