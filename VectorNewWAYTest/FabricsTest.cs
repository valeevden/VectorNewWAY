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
        public void SqareCreateFigureTest()
        {
            SquareIFabric squareFabric = new SquareIFabric();
            AFigure actual = squareFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(SquareFigure), actual.GetType());
        }

        [Test]
        public void EllipseFCreateFigureTest()
        {
            EllipseIFabric ellipseFabric = new EllipseIFabric();
            AFigure actual = ellipseFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(EllipseFigure), actual.GetType());
        }

        [Test]
        public void RectangleCreateFigureTest()
        {
            RectangleIFabric rectangleFabric = new RectangleIFabric();
            AFigure actual = rectangleFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(RectangleFigure), actual.GetType());
        }

        [Test]
        public void BrushCreateFigureTest()
        {
            BrushFabric brushFabric = new BrushFabric();
            AFigure actual = brushFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(BrushIFigure), actual.GetType());
        }
        [Test]
        public void CircleCreateFigureTest()
        {
            CircleIFabric circleFabric = new CircleIFabric();
            AFigure actual = circleFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(CircleFigure), actual.GetType());
        }

        [Test]
        public void FigureNDCreateFigureTest()
        {
            FigureNDIFabric figureNDFabric = new FigureNDIFabric();
            AFigure actual = figureNDFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(FigureNDIFigure), actual.GetType());
        }
        [Test]
        public void IsoscelesTriangleIFabricTest()
        {
            IsoscelesTriangleIFabric isoscelesTriangleIFabric = new IsoscelesTriangleIFabric();
            AFigure actual = isoscelesTriangleIFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(IsoscelesTriangleIFigure), actual.GetType());
        }
        [Test]
        public void Line2DIFabricTest()
        {
            Line2DIFabric line2DIFabric = new Line2DIFabric();
            AFigure actual = line2DIFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(Line2DIFigure), actual.GetType());
        }

        [Test]
        public void LineNDIFabricTest()
        {
            LineNDIFabric lineNDIFabric = new LineNDIFabric();
            AFigure actual = lineNDIFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(LineNDIFigure), actual.GetType());
        }
        [Test]
        public void RectTriangleIFabricTest()
        {
            RectTriangleIFabric rectTriangleIFabric = new RectTriangleIFabric ();
            AFigure actual = rectTriangleIFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(RectTriangleIFigure), actual.GetType());
        }
        [Test]
        public void Triangle3DIFabricTest()
        {
            Triangle3DIFabric triangle3DIFabric = new Triangle3DIFabric();
            AFigure actual = triangle3DIFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(Triangle3DFigure), actual.GetType());
        }
        [Test]
        public void RectangleIFabricTest()
        {
            RectangleIFabric rectangleIFabric = new RectangleIFabric();
            AFigure actual = rectangleIFabric.CreateFigure(new Pen(Color.Black, 5));
            Assert.AreEqual(typeof(RectangleFigure), actual.GetType());
        }
        //[Test]
        //public void NAngleIFabricTest(int numberFromNumeric)
        //{
        //    NAngleIFabric nAngleIFabric = new NAngleIFabric(numberFromNumeric);
        //    AFigure actual = nAngleIFabric.CreateFigure(new Pen(Color.Black, 5));
        //    Assert.AreEqual(typeof(NAngleAFigure), actual.GetType());
        //}
    }

}