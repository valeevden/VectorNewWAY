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
    public class Triangle3DIRightClickReaction : IReaction
    {
        SingletonData _singletone;
        AFigure _figure;
        public Triangle3DIRightClickReaction(AFigure figure)
        {
            _figure = figure;
        }
        public void Do()
        {
            if (_figure.AnglesNumber == 3)
            {
                _figure.PointsList.Add(new PointF(_figure.PointsList[0].X, _figure.PointsList[0].Y));
                _singletone = SingletonData.GetData();
                _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, new Pen(_figure.Color, _figure.Width));
                
            }

        }
    }
}
