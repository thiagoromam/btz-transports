using BtzTransports.Contas;
using General.Authorization;
using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    public class ContaController : BaseMvcController
    {
        public ContaController(ISessionUser sessionUser, IUsuarioDaSessao usuarioDaSessao)
        {
            
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Usuario.IsAuthenticated)
                return RedirectToAction("Index");

            return View();
        }
    }
}