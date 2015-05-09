using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestPerformance
{
    [TestFixture]
    public class UnitTestsForTestBase : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            StartTimer();
            System.Threading.Thread.Sleep(4000);
            StopTimer();
            //CheckAllTimer();
        }

        [Test]
        public void TestMethod2()
        {
            StartTimer();
            
            StartTimer("Call1");
            System.Threading.Thread.Sleep(200);
            StopTimer("Call1");

            StartTimer("Call2");
            System.Threading.Thread.Sleep(200);
            StopTimer("Call2");

            StopTimer();
        }

        [Test]
        public void TestMethod3()
        {
            StartTimer();

            StartTimer("Call1");
            System.Threading.Thread.Sleep(200);
            StopTimer("Call1");

            StartTimer("Call2");
            System.Threading.Thread.Sleep(200);
            StopTimer("Call2");

            StartTimer("Call3");
            System.Threading.Thread.Sleep(200);
            StopTimer("Call3");

            StopTimer();
        }

        [Test]
        public void TestMethod4()
        {
            StartTimer("Call1", errorTime: 1000);
            System.Threading.Thread.Sleep(900);
            StopTimer("Call1");

            StartTimer("Call2", errorTime: 200);
            System.Threading.Thread.Sleep(100);
            StopTimer("Call2");
        }
    }
}
