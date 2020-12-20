using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.FigureList;
using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.Reaction
{
    public class Triangle3DIRightClickReaction : AReaction
    {
  
        
        public Triangle3DIRightClickReaction(AFigure figure):base(figure)
        {
            
        }
        public override void Do()
        {
            if (Figure.AnglesNumber == 3)
            {
                Figure.PointsList.Add(new PointF(Figure.PointsList[0].X, Figure.PointsList[0].Y));
                Singletone = SingletonData.GetData();
                Singletone.PictureBox1.Image = Singletone.Canvas.DrawIt(Figure, new Pen(Figure.Color, Figure.Width));
                Singletone.FigureList.Add(Figure);
            }

        }
    }
}
