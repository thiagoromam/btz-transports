using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    public class ContaController : BaseMvcController
    {
        private readonly IAuthenticationManager _authenticationManager;

        public ContaController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Usuario.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }
    }
}