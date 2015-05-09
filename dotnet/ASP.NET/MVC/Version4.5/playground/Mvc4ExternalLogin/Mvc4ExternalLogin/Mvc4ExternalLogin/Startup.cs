using Microsoft.Owin;

using Mvc4ExternalLogin;

using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Mvc4ExternalLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}