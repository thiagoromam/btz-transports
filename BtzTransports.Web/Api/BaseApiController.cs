using BtzTransports.Contas;
using BtzTransports.Web.Authorization;
using BtzTransports.Web.Handlers;
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