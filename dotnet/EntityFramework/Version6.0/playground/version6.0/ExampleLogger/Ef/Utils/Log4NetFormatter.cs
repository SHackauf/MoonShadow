using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace ExampleLogger.Ef.Utils
{
    class Log4NetFormatter : DatabaseLogFormatter
    {
        public Log4NetFormatter(DbContext context, Action<string> writeAction)
            : base(context, writeAction)
        {
        }

        public override void LogCommand<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            Write(string.Format("Context '{0}' is executing command '{1}'", Context.GetType().Name, DbCommandUtils.OneLineText(command)));
        }

        public override void LogResult<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            base.LogResult(command, interceptionContext);
        }

        protected override void Write(string output)
        {
            base.Write(output.TrimEnd(Environment.NewLine.ToCharArray()));
        }
    }
}
