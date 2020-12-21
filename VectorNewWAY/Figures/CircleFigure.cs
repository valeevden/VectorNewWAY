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
using VectorNewWAY.RightClickReaction;
//using PaintForSchool.RightClickReaction;

namespace VectorNewWAY.Figures
{
    public class CircleFigure : AOneMoveFigure
    {
        List<PointF> RPointsList;
        public CircleFigure(Pen pen) : base (pen)
        {
            Painter = new PathIPainter();
            RightClickReaction = new NoReactionIReaction(this);
            Filler = new PathFiller();
            AnglesNumber = 0;
        }


        public override GraphicsPath GetPath() //Получаем Path
        {
            Path = new GraphicsPath();
            RectangleF rectangle = MakeRectangleFromPointsList();
            rectangle.Inflate(SizeX, SizeY);
            Path.AddEllipse(rectangle);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            float radius = endP.X - PointsList[0].X;
            PointF startRectangleHere = new PointF(endP.X, PointsList[0].Y + radius);
            RPointsList = new List<PointF>();
            RPointsList.Add(startRectangleHere);
            RPointsList.Add(PointsList[0]);
            RPointsList.Add(endP);
        }
        public override RectangleF MakeRectangleFromPointsList()
        {
            float width = 2 * (RPointsList[1].X - RPointsList[0].X);
            float height = 2 * (RPointsList[1].Y - RPointsList[0].Y);
            RectangleF rectangle = new RectangleF(RPointsList[0].X, RPointsList[0].Y, width, height);
            return rectangle;
        }

        public override void Scale(PointF point)
        {
            RectangleF rectangle = MakeRectangleFromPointsList();

            SizeX = SizeX - point.X / 2 * rectangle.Width * 0.008f;
            SizeY = SizeY - point.X / 2 * rectangle.Height * 0.008f;
        }


    }
}
