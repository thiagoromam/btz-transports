using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web.Helpers;

namespace BtzTransports.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "BtzTransports",
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Conta/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = OnApplyRedirect
                }
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }

        private static void OnApplyRedirect(CookieApplyRedirectContext context)
        {
            var redirect = true;

            if (Regex.IsMatch(context.Request.Uri.AbsolutePath, "^/?api"))
                redirect = false;
            else if (context.Request.Query?["X-Requested-With"] == "XMLHttpRequest")
                redirect = false;
            else if (context.Request.Headers?["X-Requested-With"] == "XMLHttpRequest")
                redirect = false;

            if (redirect)
                context.Response.Redirect(context.RedirectUri);
        }
    }
}