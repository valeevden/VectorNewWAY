using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Drawing;
using VectorNewWAY.Fabrics;
using VectorNewWAY.Figures;
using System.Collections;

namespace VectorNewWAYTest
{
    public class FabricTest
    {
        [Test]
        public void SFCreateFigureTest()
        {
            SquareIFabric squareFabric = new SquareIFabric();
            AFigure actual = squareFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(SquareFigure), actual.GetType());
        }
    }
    [Test]
    public void EllFCreateFigureTest()
    {
        EllipseIFabric ellipseFabric = new EllipseIFabric();
        AFigure actual = ellipseFabric.CreateFigure(new Pen(Color.Black, 5));
        Assert.AreEqual(typeof(EllipseFigure), actual.GetType());
    }

    [Test]
    public void RecCreateFigureTest()
    {
        RectangleIFabric rectangleFabric = new RectangleIFabric();
        AFigure actual = rectangleFabric.CreateFigure(new Pen(Color.Black, 5));
        Assert.AreEqual(typeof(RectangleFigure), actual.GetType());
    }

}