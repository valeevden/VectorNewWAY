﻿using System;
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

namespace VectorNewWAY.Figures
{
    public class RectTriangleIFigure : AOneMoveFigure
    {
        public RectTriangleIFigure(Pen pen) : base(pen)
        {
            Painter = new PathIPainter();
            Filler = new PathFiller();
            AnglesNumber = 3;
        }

        public override GraphicsPath GetPath() 
        {
            MakePathFromLine();
            Path.CloseFigure();
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {
            PointF[] pointsArray = new PointF[3];
            pointsArray[0] = MouseDownPoint;
            pointsArray[1] = endP;
            pointsArray[2].X = MouseDownPoint.X;
            pointsArray[2].Y = endP.Y;

            PointsList = new List<PointF> { };
            PointsList = pointsArray.ToList();
        }


        public override PointF SetCenter()
        {
            Center = new PointF(0, 0);
            for (int i = 0; i < AnglesNumber; i++)
            {
                Center = new PointF(Center.X + PointsList[i].X, Center.Y + PointsList[i].Y);
            }
            Center = new PointF(Center.X / AnglesNumber, Center.Y / AnglesNumber);
            return Center;
        }
    }
}
