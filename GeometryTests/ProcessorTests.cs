using System.Collections.Generic;
using System.Drawing;
using GeometryProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryTests
{
    [TestClass]
    public class ProcessorTests
    {
        [TestMethod]
        public void TestGetCoordinates()
        {
            //Arrange
            ShapesProcessor proc = new ShapesProcessor();

            //Test
            List<Point> ptC7 = proc.GetCoordinates("C", 7);
            List<Point> ptD8 = proc.GetCoordinates("D", 8);
            List<Point> ptA1 = proc.GetCoordinates("A", 1);
            List<Point> ptF12 = proc.GetCoordinates("F", 12);

            //Assert
            Assert.IsTrue(ptC7.Contains(new Point(30, 20)));
            Assert.IsTrue(ptC7.Contains(new Point(30, 30)));
            Assert.IsTrue(ptC7.Contains(new Point(40, 30)));

            Assert.IsTrue(ptD8.Contains(new Point(30, 30)));
            Assert.IsTrue(ptD8.Contains(new Point(40, 30)));
            Assert.IsTrue(ptD8.Contains(new Point(40, 40)));

            Assert.IsTrue(ptA1.Contains(new Point(0, 0)));
            Assert.IsTrue(ptA1.Contains(new Point(0, 10)));
            Assert.IsTrue(ptA1.Contains(new Point(10, 10)));

            Assert.IsTrue(ptF12.Contains(new Point(50, 50)));
            Assert.IsTrue(ptF12.Contains(new Point(60, 50)));
            Assert.IsTrue(ptF12.Contains(new Point(60, 60)));
        }

        [TestMethod]
        public void TestGetLocation()
        {
            //Arrange
            ShapesProcessor proc = new ShapesProcessor();

            List<Point> lstPtF12 = new List<Point> { new Point(50, 50), new Point(60, 50), new Point(60, 60) };
            List<Point> lstPtA1 = new List<Point> { new Point(0, 0), new Point(0, 10), new Point(10, 10) };
            List<Point> lstPtD8 = new List<Point> { new Point(30, 30), new Point(40, 30), new Point(40, 40) };
            List<Point> lstPtC7 = new List<Point> { new Point(30, 20), new Point(30, 30), new Point(40, 30) };

            //Test
            Dictionary<string, int> resPtF12 = proc.GetLocation(lstPtF12);
            Dictionary<string, int> resPtA1 = proc.GetLocation(lstPtA1);
            Dictionary<string, int> resPtD8 = proc.GetLocation(lstPtD8);
            Dictionary<string, int> resPtC7 = proc.GetLocation(lstPtC7);

            //Assert
            Assert.IsTrue(resPtF12["F"] == 12);
            Assert.IsTrue(resPtA1["A"] == 1);
            Assert.IsTrue(resPtD8["D"] == 8);
            Assert.IsTrue(resPtC7["C"] == 7);
        }
    }
}
