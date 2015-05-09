using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPerformance
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public sealed class UnitTestMaxDurationTimeAttribute : System.Attribute
    {
        private readonly int _milliceconds;
        public UnitTestMaxDurationTimeAttribute(int milliseconds)
        {
            _milliceconds = milliseconds;
        }

        public int GetTime()
        {
            return _milliceconds;
        }
    }
}
