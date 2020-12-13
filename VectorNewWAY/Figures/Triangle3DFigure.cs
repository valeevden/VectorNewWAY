using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;//для Brush
using VectorNewWAY.Painters;
using VectorNewWAY.Fillers;
using VectorNewWAY.Reaction;

namespace VectorNewWAY.Figures
{
    public class Triangle3DFigure : AFigure
    {
        public Triangle3DFigure(Pen pen) : base(pen)
        {
            Reaction = new Triangle3DIRightClickReaction(this);
            PointsList = new List<PointF> { new PointF(0, 0) };
            Painter = new PathIPainter();
            Filler = new PathFiller();
            AnglesNumber = 1;
        }

        public override GraphicsPath GetPath() //Получаем Path
        {
            //отрисовывается весь путь во время маус мува
            //последняя линяя двигается
            Path = new GraphicsPath();
            for (int i = 0; i < PointsList.Count - 1; i++)
            {
                Path.AddLine(PointsList[i], PointsList[i + 1]);
            }
            Path.CloseFigure();

            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            //PointsList = new List<PointF>();
            PointsList[AnglesNumber - 2] = startP;
            PointsList[AnglesNumber - 1] = endP;
        }
       

        public override void Scale(PointF point)
        {

        }
      
    }
}
