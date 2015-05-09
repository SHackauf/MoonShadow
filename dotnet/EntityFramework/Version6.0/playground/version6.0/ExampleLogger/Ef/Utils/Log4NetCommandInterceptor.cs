using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

using log4net;

namespace ExampleLogger.Ef.Utils
{
    class Log4NetCommandInterceptor : IDbCommandInterceptor
    {
        private static readonly ILog _log = LogManager.GetLogger("EntityFramework");

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfNonAsync(command, interceptionContext);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogIfError(command, interceptionContext);
        }

        private void LogIfNonAsync<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (!interceptionContext.IsAsync)
            {
                _log.Warn("Non-async command used: " + DbCommandUtils.OneLineText(command));
            }
        }

        private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                _log.Error("Command " + DbCommandUtils.OneLineText(command) + " failed with exception", interceptionContext.Exception);
                if (interceptionContext.OriginalException != null)
                    _log.Error("OriginalException", interceptionContext.OriginalException);
            }
        }
    }
}
