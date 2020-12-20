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
using VectorNewWAY.Reaction;
using VectorNewWAY.FigureList;

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

        public override void Update(PointF startP, PointF endP)
        {
            PointsList[AnglesNumber - 2] = MouseDownPoint;
            PointsList[AnglesNumber - 1] = endP;
        }
        public override void ApplyFinalizer()
        {
            if (AnglesNumber == 3)
            {
                PointsList.Add(new PointF(PointsList[0].X, PointsList[0].Y));
                SingletonData singletone;
                singletone = SingletonData.GetData();
                singletone.PictureBox1.Image = singletone.Canvas.DrawIt(this, new Pen(this.Color, this.Width));
            }
        }

    }
}
