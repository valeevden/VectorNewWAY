
using VectorNewWAY.FigureList;
using VectorNewWAY.Figures;
using System.Drawing;

namespace VectorNewWAY.RightClickReaction
{
    public class FreeFigureIRightClickReaction : AReaction
    {
        SingletonData _singletone;
        AFigure _figure;
        public FreeFigureIRightClickReaction(AFigure figure) : base(figure)
        {
            _figure = figure;
            _singletone = SingletonData.GetData();
        }

        public override void FinishBuilding()
        {
            _figure.PointsList.Add(new PointF(_figure.PointsList[0].X, _figure.PointsList[0].Y));
            _singletone.PictureBox1.Image = _singletone.Canvas.DrawIt(_figure, new Pen(_figure.Color, _figure.Width));
        }
    }
}
