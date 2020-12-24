using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using VectorNewWAY.Painters;
using VectorNewWAY.Fillers;
using VectorNewWAY.RightClickReaction;
using VectorNewWAY.FigureList;
using VectorNewWAY.Saver;

namespace VectorNewWAY.Figures
{
    public class Triangle3DFigure : AOneMoveFigure
    {
        public Triangle3DFigure(Pen pen) : base(pen)
        {
            
            Painter = new PathIPainter();
            Filler = new PathFiller();
            AnglesNumber = 1;
        }

        public override GraphicsPath GetPath() 
        {
            MakePathFromLine();
            Path.Transform(RotateMatrix);
            return Path;
        }

        
        public override void ApplySaver()
        {
            if (AnglesNumber == 3)
            {
                Saver = new ActiveISaver();
            }
            Saver.SaveFigure(this);
        }

    }
}
