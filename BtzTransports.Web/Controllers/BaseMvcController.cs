using BtzTransports.Contas;
using BtzTransports.Web.Authorization;
using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    [MvcAuthorization]
    public abstract class BaseMvcController : Controller
    {
        protected IUsuarioDaSessao Usuario => (IUsuarioDaSessao)User;
    }
}