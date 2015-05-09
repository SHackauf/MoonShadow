using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyFirstOwin
{
    //using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<MyOwinServer>("http://localhost:50500"))
            {
                Console.WriteLine("Server listening ...");
                Console.ReadKey();
            }
        }
    }

    public class MyOwinServer
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Use(async (context, next) =>
            {
                Console.WriteLine("=================");
                Console.WriteLine("Server call start");
                await next();
                Console.WriteLine("Server call end");
                Console.WriteLine("=================");
            });

            appBuilder.UseMyMiddlewareLogger();

            appBuilder.Map("/ping", pingApp =>
            {
                pingApp.Run(async (context) =>
                    {
                        var response = context.Response;
                        response.ContentType = "text/html";
                        response.StatusCode = (int)HttpStatusCode.OK;

                        var bytes = Encoding.UTF8.GetBytes("Server is running!");
                        await response.Body.WriteAsync(bytes, 0, bytes.Length);
                    });
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);
        }
    }

    
}
