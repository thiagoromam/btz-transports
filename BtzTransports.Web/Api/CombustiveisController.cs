using BtzTransports.Context;
using BtzTransports.Web.Models.Abastecimentos;
using System.Linq;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [Route("api/combustiveis")]
    public class CombustiveisController : BaseApiController
    {
        private readonly IContextoDeDados _contexto;

        public CombustiveisController(IContextoDeDados contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            var combustiveis = _contexto.Combustiveis.ToArray();

            return Ok(combustiveis.Select(CombustivelModel.Converter));
        }
    }
}