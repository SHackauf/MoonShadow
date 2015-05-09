using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using NUnit.Framework;

namespace UnitTestExport
{
    public abstract class TestBase
    {
        private readonly string _assemblyName;
        private readonly string _testRegion;
        private readonly string _className;

        protected TestBase(string testRegion = "")
        {
            _testRegion = testRegion;

            var method = new StackTrace().GetFrame(1).GetMethod();
            _className = method.ReflectedType.Name;
            //_assemblyName = method.Module.Name;
            _assemblyName = method.Module.Assembly.FullName;
        }

        private static ITestExport _export;
        protected virtual ITestExport Export
        {
            get
            {
                if (null == _export)
                {
                    lock (this)
                    {
                        if (null == _export)
                        {
                            _export = new TestExportConsole();
                        }
                    }
                }

                return _export;
            }
        }

        #region SetUp and TearDown

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            Export.Export(TestContext.CurrentContext);
        }

        [TestFixtureSetUp]
        public void OneTimeSetUp()
        {
            Export.ExportStart(_assemblyName, _testRegion, _className);
        }

        [TestFixtureTearDown]
        public void OneTimeTearDown()
        {
            Export.ExportStop();
        }

        #endregion
    }
}
