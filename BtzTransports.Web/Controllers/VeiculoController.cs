using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    public class VeiculoController : BaseMvcController
    {
        public ActionResult Index() => View();
        public ActionResult Novo() => View("Editar");
        public ActionResult Editar(int id) => View("Editar", id);
    }
}