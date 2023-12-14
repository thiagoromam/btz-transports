using BtzTransports.Contas;
using General.Authorization;
using System.Web.Mvc;

namespace BtzTransports.Web.Controllers
{
    [MvcAuthorization]
    public abstract class BaseMvcController : Controller
    {
        protected IUsuarioDaSessao Usuario => (IUsuarioDaSessao)User;
    }
}