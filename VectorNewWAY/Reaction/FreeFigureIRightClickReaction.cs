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
    public class FreeFigureIRightClickReaction : AReaction
    {
        SingletonData _singletone;
        AFigure _figure;
        public FreeFigureIRightClickReaction(AFigure figure) : base(figure)
        {
            _figure = figure;
        }

        public override void Do()
        {
            _singletone = SingletonData.GetData();
            _figure.PointsList.Add(new PointF(_figure.PointsList[0].X, _figure.PointsList[0].Y));
            _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, new Pen(_figure.Color, _figure.Width));
        }
    }
}
