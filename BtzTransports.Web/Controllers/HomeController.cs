using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    public class HomeController : BaseMvcController
    {
        public ActionResult Index() => View();
    }
}