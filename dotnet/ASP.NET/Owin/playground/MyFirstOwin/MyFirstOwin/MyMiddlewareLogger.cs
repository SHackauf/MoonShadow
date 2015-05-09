using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstOwin
{
    public class MyMiddlewareLogger
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public MyMiddlewareLogger(Func<IDictionary<string, object>, Task> next)
        {
            this._next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
            Console.WriteLine(string.Format("Log: [Request [Uri: {0}]]", context.Request.Uri));
            await this._next(environment);
            Console.WriteLine(string.Format("Log: [Response [StatusCode: {0}]]", context.Response.StatusCode));
        }
    }

    public static class MyMiddlewareLoggerExtension
    {
        public static void UseMyMiddlewareLogger(this IAppBuilder appBuilder)
        {
            appBuilder.Use<MyMiddlewareLogger>();
        }
    }
}
