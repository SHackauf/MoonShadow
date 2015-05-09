using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPass()
        {
            Assert.AreEqual(true, true, "Works");
        }

        [TestMethod]
        public void TestFail()
        {
            Assert.Fail("Doesn't work");
        }

        [TestMethod]
        public void TestMethodIgnore()
        {
            Assert.Inconclusive("Not running.");
        }
    }
}
