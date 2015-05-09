using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.Owin.Security;

using Mvc4ExternalLogin.Models;

namespace Mvc4ExternalLogin.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index(string info = "")
        {
            return View(new LoginViewModel(info));
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider)
        {
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Login"));
        }

        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Index", new { info = "No login information found!" });
            }

            var email = loginInfo.Email;
            // Hier gegebenenfalls die Email mit der internen Benutzerverwaltung prüfen
            // und anschließend die eigentliche Anwendung aufrufen.
            return RedirectToAction("Index", new { info = "[User: " + email + "]" });
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
    }
}
