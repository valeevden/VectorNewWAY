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
//using PaintForSchool.RightClickReaction;

namespace VectorNewWAY.Figures
{
    public class CircleFigure : AFigure
    {
        public CircleFigure(Pen pen) : base (pen)
        {
            Painter = new PathIPainter();
            Reaction = new NoReactionIReaction();
            Filler = new PathFiller();
            Started = false;
            AnglesNumber = 0;
            IsFilled = false;
            ScaleMatrix = new Matrix();
            RotateMatrix = new Matrix();
            SizeX = 0;
            SizeY = 0;
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
            float radius = endP.X - startP.X;
            PointF startRectangleHere = new PointF(endP.X, startP.Y + radius);
            PointsList = new List<PointF>();
            PointsList.Add(startRectangleHere);
            PointsList.Add(startP);
            PointsList.Add(endP);
        }
        private RectangleF MakeRectangleFromPointsList()
        {
            float width = 2 * (PointsList[1].X - PointsList[0].X);
            float height = 2 * (PointsList[1].Y - PointsList[0].Y);
            RectangleF rectangle = new RectangleF(PointsList[0].X, PointsList[0].Y, width, height);
            return rectangle;
        }

        public override bool IsEdge(PointF eLocation)
        {
           
            Pen penGP = new Pen(Color, Width);
            if (Path.IsOutlineVisible(eLocation, penGP)) // Если точка входит в область видимости 
            {
                TouchPoint = eLocation;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool IsArea(PointF eLocation)
        {
           
            if (Path.IsVisible(eLocation)) // Если точка входит в область видимости 
            {
                TouchPoint = eLocation;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(PointF delta)
        {
            for (int i = 0; i < PointsList.Count; i++)
            {
                PointsList[i] = new PointF(PointsList[i].X + delta.X, PointsList[i].Y + delta.Y);
            }
           
        }

        public override void Scale(PointF point)
        {
            RectangleF rectangle = MakeRectangleFromPointsList();

            SizeX = SizeX - point.X / 2 * rectangle.Width * 0.008f;
            SizeY = SizeY - point.X / 2 * rectangle.Height * 0.008f;
        }


    }
}
