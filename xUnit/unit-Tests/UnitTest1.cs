using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xUnit;

namespace unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(triangle.IsTriangle(1, 2, 3), true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(triangle.IsTriangle(1, 2, 3), true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(triangle.IsTriangle(1, 2, 3), true);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(triangle.IsTriangle(1, -1, 1), true);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(triangle.IsTriangle(1, 1, 1), true);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(triangle.IsTriangle(0, 0, 0), true);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(triangle.IsTriangle(-1, 0, 3), true);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(triangle.IsTriangle(1, 2, 0), true);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(triangle.IsTriangle(1.1, 2.2, 3.3), true);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual(triangle.IsTriangle(10, 100, 10), true);
        }
    }
}

