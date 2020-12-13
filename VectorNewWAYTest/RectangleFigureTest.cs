using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Drawing;
using VectorNewWAY.Fabrics;
using VectorNewWAY.Figures;



namespace VectorNewWAYTest
{
    public class RectangleFigureTest
    {
        RectangleFigure rectangleFigure;

        [SetUp]
        public void Setup()
        {
            rectangleFigure = new RectangleFigure (new Pen (Color.Black, 5));
        }
    }
}
