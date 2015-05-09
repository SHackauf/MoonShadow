using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestPerformance
{
    public class TestAttributBase
    {
        private Stopwatch _stopwatch;

        [SetUp]
        public void SetUp()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        [TearDown]
        public void TearDown()
        {
            _stopwatch.Stop();

            var methodName = TestContext.CurrentContext.Test.Name;
            var method = GetType().GetMethod(methodName);
            var attributes = method.GetCustomAttributes(typeof(UnitTestMaxDurationTimeAttribute), true);
            if (attributes.Any())
            {
                var attribute = (UnitTestMaxDurationTimeAttribute)attributes[0];
                var time = _stopwatch.ElapsedMilliseconds;
                if (time > attribute.GetTime())
                    Assert.Fail("Duration to long! [Maximal time: " + attribute.GetTime() + "][Real time: " + time + "]");
            }
        }
    }
}
