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

        [Test, TestCaseSource(typeof(IsAreaTestSource))]
        public void IsAreaTest(Point startPoint, Point endPoint, Point delta, bool exspected)
        {
            rectangleFigure.Update(startPoint, endPoint);
            bool actual = rectangleFigure.IsArea(delta);

            Assert.AreEqual(exspected, actual);
        }

        [Test, TestCaseSource(typeof(ScaleTestSource))]
        public void ScaleTest(Point startPoint, Point endPoint, Point point, Point delta, bool exspected)
        {
            rectangleFigure.Update(startPoint, endPoint);
            for (int i = 0; i< 20; i++)
            {
                rectangleFigure.Scale(delta);
            }
            bool  actual = rectangleFigure.IsArea(point);
            Assert.AreEqual (exspected, actual);
        }

        [Test, TestCaseSource(typeof(MoveTestSource))]
        public void MoveTest(Point startPoint, Point endPoint,Point delta, List<PointF> expected)
        {
            rectangleFigure.Update(startPoint, endPoint);
            rectangleFigure.Move(delta);
            List<PointF> actual = rectangleFigure.PointsList;
            Assert.AreEqual(expected, actual);

        }

        [Test, TestCaseSource(typeof(RotateTestSource))]
        public void RotateTest(Point startPoint, Point endPoint,Point point, float delta,  bool expected)
        {
            rectangleFigure.Update(startPoint, endPoint);
            rectangleFigure.Rotate(delta);
            bool actual = rectangleFigure.IsEdge(point); 
            Assert.AreEqual(expected, actual);

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
        public class IsAreaTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(5, 8), true };
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(10, 10), true };
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(50, 100), false };
            }

        }

        public class ScaleTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(20, 15), new Point(1, 1), false};
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(10, 10), new Point(5, 8), true};
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(50, 100), new Point(5, 8), false};
            }

        }

        public class MoveTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new Point(6, 7), new Point(16, 17) };
            List<PointF> points2 = new List<PointF>() { new Point(-4, 5), new Point(16, 25) };
            List<PointF> points3 = new List<PointF>() { new Point(6, 6), new Point(11, 11) };

            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(6, 7), points1 };
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(-4, 5), points2 };
                yield return new object[] { new Point(5, 5), new Point(10, 10),new Point (1,1), points3 };
            }
        }

        public class RotateTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new Point(6, 7), new Point(16, 17) };
            
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(10, 10), 90, true};
             }
        }

    }
    public class SquareTest
    {

        SquareFigure squareFigure;

        [SetUp]

        public void Setup()
        {
            squareFigure = new SquareFigure(new Pen(Color.Black, 5));
        }

        [Test, TestCaseSource(typeof(UpdateTestSource))]
        public void UpdateTest(Point startPoint, Point endPoint, List<PointF> expected)
        {
            squareFigure.Update(startPoint, endPoint);
            List<PointF> actual = squareFigure.PointsList;
            Assert.AreEqual(expected, actual);

        }

        [Test, TestCaseSource(typeof(IsEdgeTestSource))]
        public void IsEdgeTest(Point startPoint, Point endPoint, Point delta, bool exspected)
        {
            squareFigure.Update(startPoint, endPoint);
            bool actual = squareFigure.IsEdge(delta);

            Assert.AreEqual(exspected, actual);
        }

        [Test, TestCaseSource(typeof(IsAreaTestSource))]
        public void IsAreaTest(Point startPoint, Point endPoint, Point delta, bool exspected)
        {
            squareFigure.Update(startPoint, endPoint);
            bool actual = squareFigure.IsArea(delta);

            Assert.AreEqual(exspected, actual);
        }

        [Test, TestCaseSource(typeof(ScaleTestSource))]
        public void ScaleTest(Point startPoint, Point endPoint, Point point, Point delta, bool exspected)
        {
            squareFigure.Update(startPoint, endPoint);
            for (int i = 0; i < 20; i++)
            {
                squareFigure.Scale(delta);
            }
            bool actual = squareFigure.IsArea(point);
            Assert.AreEqual(exspected, actual);
        }

        [Test, TestCaseSource(typeof(MoveTestSource))]
        public void MoveTest(Point startPoint, Point endPoint, Point delta, List<PointF> expected)
        {
            squareFigure.Update(startPoint, endPoint);
            squareFigure.Move(delta);
            List<PointF> actual = squareFigure.PointsList;
            Assert.AreEqual(expected, actual);

        }

        [Test, TestCaseSource(typeof(RotateTestSource))]
        public void RotateTest(Point startPoint, Point endPoint, Point point, float delta, bool expected)
        {
            squareFigure.Update(startPoint, endPoint);
            squareFigure.Rotate(delta);
            bool actual = squareFigure.IsEdge(point);
            Assert.AreEqual(expected, actual);

        }



        public class UpdateTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new Point(0, 0), new Point(10, 10) };
            List<PointF> points2 = new List<PointF>() { new Point(0, 0), new Point(20, 20) };
            List<PointF> points3 = new List<PointF>() { new Point(5, 5), new Point(10, 10) };

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
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(5, 8), true };
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(10, 10), false };
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(50, 100), false };
            }

        }
        public class IsAreaTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(5, 8), true };
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(10, 10), true };
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(50, 100), false };
            }

        }

        public class ScaleTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(20, 15), new Point(1, 1), false };
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(10, 10), new Point(5, 8), true };
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(50, 100), new Point(5, 8), false };
            }

        }

        public class MoveTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new Point(6, 7), new Point(16, 17) };
            List<PointF> points2 = new List<PointF>() { new Point(-4, 5), new Point(16, 25) };
            List<PointF> points3 = new List<PointF>() { new Point(6, 6), new Point(11, 11) };

            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(6, 7), points1 };
                yield return new object[] { new Point(0, 0), new Point(20, 20), new Point(-4, 5), points2 };
                yield return new object[] { new Point(5, 5), new Point(10, 10), new Point(1, 1), points3 };
            }
        }

        public class RotateTestSource : IEnumerable
        {
            List<PointF> points1 = new List<PointF>() { new Point(6, 7), new Point(16, 17) };

            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Point(0, 0), new Point(10, 10), new Point(10, 10), 90, true };
            }
        }
    }
}
        


        

    
