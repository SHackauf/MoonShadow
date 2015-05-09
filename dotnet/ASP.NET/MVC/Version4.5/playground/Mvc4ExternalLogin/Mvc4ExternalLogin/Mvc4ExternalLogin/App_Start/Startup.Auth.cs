using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

using Owin;

// ReSharper disable CheckNamespace
namespace Mvc4ExternalLogin
// ReSharper restore CheckNamespace
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.UseGoogleAuthentication(
                clientId: "894655676248-kfre2gebipqb11fdcb5k2le7p06aet44.apps.googleusercontent.com",
                clientSecret: "gWovTYa8Dnwr4WOi2oSCrKA6");

            // app.UseMicrosoftAccountAuthentication(clientId: "", clientSecret: "");
            // app.UseTwitterAuthentication(consumerKey: "", consumerSecret: "");
            // app.UseFacebookAuthentication(appId: "", appSecret: "");
        }
    }
}