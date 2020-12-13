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
    public class FigureTest
    {
        RectangleFigure rectangleFigure;

        [SetUp]
        public void Setup()
        {
            rectangleFigure = new RectangleFigure(new Pen(Color.Black, 5));
        }

        [Test, TestCaseSource(typeof(UpdateTestSource))]
        public void UpdateTest(Point startPoint, Point endPoint, List<PointF> expected)
        {
            rectangleFigure.Update(startPoint, endPoint);
            List<PointF> actual = rectangleFigure.PointsList;
            Assert.AreEqual(expected, actual);

        }

        [Test, TestCaseSource(typeof(IsEdgeTestSource))]
        public void IsEdgeTest(Point startPoint, Point endPoint, Point delta, bool exspected)
        {
            rectangleFigure.Update(startPoint, endPoint);
            bool actual = rectangleFigure.IsEdge(delta);

            Assert.AreEqual(exspected, actual);
        }



        public class UpdateTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new Point(0, 0), new Point(10, 10)};
            List<PointF> points2 = new List<PointF>() { new Point(0, 0), new Point(20, 20)};
            List<PointF> points3 = new List<PointF>() { new Point(5, 5), new Point(10, 10)};

            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), points1 };
                yield return new object[] { new Point(0, 0), new Point(20, 20), points2 };
                yield return new object[] { new Point(5, 5), new Point(10, 10), points3 };
            }
        }
        public class IsEdgeTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(5, 8), true};
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(10, 10), false };
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(50, 100), false };
            }

        }

    }
}
        


        

    
