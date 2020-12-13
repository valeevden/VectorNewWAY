﻿using System;
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
    public class BrushIFigure : AFigure
    {
        public BrushIFigure (Pen pen): base (pen)
        {
            Reaction = new NoReactionIReaction();
            Painter = new PathIPainter();
            AnglesNumber = 0;
            RotateMatrix = new Matrix();
            PointsList = new List<PointF>() { new PointF(0, 0), new PointF(0, 0) };
        }
        public override GraphicsPath GetPath() 
        {
            Path = new GraphicsPath();
            Path.AddLine(PointsList[0], PointsList[1]);
            //Pen.LineJoin = LineJoin.Round;
            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            Path.Transform(RotateMatrix);
            return Path;
        }

        public override void Update(PointF startP, PointF endP)
        {

            PointsList[0] = startP;
            PointsList[1] = endP;

        }

        public override void Scale(PointF point)
        {

        }

        public override void Rotate(float rotateAngle)
        {

            Center = new PointF(Math.Abs((PointsList[0].X + PointsList[1].X) / 2), Math.Abs((PointsList[0].Y + PointsList[1].Y) / 2));
            RotateMatrix.RotateAt(rotateAngle, Center);
            Path.Transform(RotateMatrix);
        }
    }
}
