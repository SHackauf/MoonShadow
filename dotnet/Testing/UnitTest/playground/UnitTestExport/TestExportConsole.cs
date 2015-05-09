using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace UnitTestExport
{
    internal class TestExportConsole : ITestExport
    {
        private string _assemblyName = string.Empty;
        private string _regionName = string.Empty;
        private string _className = string.Empty;
        private readonly Dictionary<TestState, int> _testStatistics = new Dictionary<TestState, int>();

        public void ExportStart(string assemblyName, string regionName, string className)
        {
            if (!string.IsNullOrEmpty(_assemblyName) || !string.IsNullOrEmpty(_className))
            {
                ExportStop();
            }

            _assemblyName = assemblyName;
            _regionName = regionName;
            _className = className;
            _testStatistics.Clear();

            System.Diagnostics.Debug.WriteLine("Start: {0} - {1} - {2}", _assemblyName, _regionName, _className);
        }

        public void Export(TestContext context)
        {
            try
            {
                var methodName = context.Test.FullName;
                var state = context.Result.State;

                System.Diagnostics.Debug.WriteLine("   Testcase: {0} - {1}", methodName, state);

                if (_testStatistics.ContainsKey(state))
                {
                    _testStatistics[state]++;
                }
                else
                {
                    _testStatistics.Add(state, 1);
                }
            }
            catch (NullReferenceException)
            {
                System.Diagnostics.Debug.WriteLine("   Export doesn't work because the TestContext is null. Please use NUnit’s test runner.");
            }
        }

        public void ExportStop()
        {
            System.Diagnostics.Debug.WriteLine("   Statistics: {0} - {1} - {2}", _assemblyName, _regionName, _className);
            foreach (var testStatistic in _testStatistics)
            {
                System.Diagnostics.Debug.WriteLine("      - {0}: {1}", testStatistic.Key, testStatistic.Value);
            }
            System.Diagnostics.Debug.WriteLine("Stop: {0} - {1} - {2}", _assemblyName, _regionName, _className);

            _assemblyName = string.Empty;
            _regionName = string.Empty;
            _className = string.Empty;
            _testStatistics.Clear();
        }
    }
}
