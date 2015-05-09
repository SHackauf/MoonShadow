using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestExport
{
    public interface ITestExport
    {
        void ExportStart(string assemblyName, string region, string className);
        void Export(TestContext context);
        void ExportStop();
    }
}
