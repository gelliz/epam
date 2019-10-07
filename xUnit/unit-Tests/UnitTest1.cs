using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit;

namespace unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsTriangleEquilateralTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(4, 4, 4));
        }

        [TestMethod]
        public void IsTriangleAllSidesNullTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void IsTriangleRightTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 8, 10));
        }

        [TestMethod]
        public void IsTriangleIsoscelesTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 3, 2));
        }

        [TestMethod]
        public void IsTriangleGoodTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 4, 5));
        }

        [TestMethod]
        public void IsTriangleBadTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(1, 12, 6));
        }

        [TestMethod]
        public void IsTriangleDoubleGoodTest()
        {
            Assert.IsTrue(Triangle.IsTriangle(1.5, 2.5, 3.5));
        }

        [TestMethod]
        public void IsTriangleOneBadSideTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(3, 4, -5));
        }

        [TestMethod]
        public void IsTriangleTwoBadSidesTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(-2, -3, 4));
        }

        [TestMethod]
        public void IsTriangleThreeBadSidesTest()
        {
            Assert.IsFalse(Triangle.IsTriangle(-5, -2, -3));
        }
    }
}

