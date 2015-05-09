using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestPerformance
{
    [TestFixture]
    public class UnitTestsForAttribute : TestAttributBase
    {
        [Test]
        [UnitTestMaxDurationTime(500)]
        public void TestMethod1()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [Test]
        [UnitTestMaxDurationTime(5000)]
        public void TestMethod2()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [Test]
        public void TestMethod3()
        {
            System.Threading.Thread.Sleep(4000);
        }
    }
}
