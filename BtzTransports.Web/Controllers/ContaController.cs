using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    public class ContaController : BaseMvcController
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Usuario.IsAuthenticated)
                return RedirectToAction("Index");

            return View();
        }
    }
}