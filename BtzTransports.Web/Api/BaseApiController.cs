using BtzTransports.Contas;
using BtzTransports.Web.Authorization;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [ApiAuthorization]
    public abstract class BaseApiController : ApiController
    {
        protected IUsuarioDaSessao Usuario => (IUsuarioDaSessao)User;
    }
}