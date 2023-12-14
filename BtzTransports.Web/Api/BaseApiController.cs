using BtzTransports.Contas;
using General.Authorization;
using General.Filters;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [ApiAuthorization]
    [ExceptionHandler]
    public abstract class BaseApiController : ApiController
    {
        protected IUsuarioDaSessao Usuario => (IUsuarioDaSessao)User;
    }
}