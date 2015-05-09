using System.Data.Entity;

using ExampleLogger.Ef.Utils;

using log4net;

namespace ExampleLogger.Ef
{
    class MyDbConfiguration : DbConfiguration
    {
        private static readonly ILog _log = LogManager.GetLogger("EntityFramework");

        public MyDbConfiguration()
        {
            SetDatabaseLogFormatter((context, writeAction) => new Log4NetFormatter(context, writeAction));
            this.AddInterceptor(new Log4NetCommandInterceptor());
        }
    }
}
