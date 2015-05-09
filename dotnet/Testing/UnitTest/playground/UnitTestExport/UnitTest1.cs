using System;

using NUnit.Framework;

namespace UnitTestExport
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        [Test]
        public void TestFail()
        {
            Assert.Fail("Doesn't work");
        }

        [Test]
        public void TestPass()
        {
            Assert.Pass("Works");
        }

        [Test]
        public void TestMethodIgnore()
        {
            Assert.Ignore("Not running.");
        }

        [TestCase(TestName = "MyFirst")]
        public void TestOtherName()
        {
            Assert.Fail("Doesn't work");
        }

        [TestCase(1, 2, ExpectedResult = 3)]
        [TestCase(1, 3, ExpectedResult = 10)]
        [TestCase(1, 4, ExpectedResult = 5)]
        public int TestWithValues(int a, int b)
        {
            return (a + b);
        }
    }
}
