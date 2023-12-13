using BtzTransports.Context;
using BtzTransports.Motoristas;
using BtzTransports.Web.Models.Motoristas;
using System.Linq;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [Route("api/motoristas/{id?}")]
    public class MotoristasController : BaseApiController
    {
        private readonly IContextoDeDados _contexto;
        private readonly IGerenciadorDeMotoristas _gerenciador;

        public MotoristasController(IContextoDeDados contexto, IGerenciadorDeMotoristas gerenciador)
        {
            _contexto = contexto;
            _gerenciador = gerenciador;
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            var motoristas = _contexto.Motoristas.ToArray();

            // query, buscas e paginação ao invés de enumeração

            return Ok(motoristas.Select(MotoristaModel.Converter));
        }

        [HttpGet]
        public IHttpActionResult Buscar(int id)
        {
            Motorista motorista = _contexto.Motoristas.Find(id);

            if (motorista == null)
                return BadRequest();

            return Ok(MotoristaModel.Converter(motorista));
        }

        [HttpPost]
        public IHttpActionResult Adicionar(MotoristaModel model)
        {
            model.Id = 0;
            Motorista motorista = model.Converter();

            _gerenciador.Adicionar(motorista);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Atualizar(int id, MotoristaModel model)
        {
            model.Id = id;
            Motorista motorista = model.Converter();

            _gerenciador.Atualizar(motorista);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Remover(int id)
        {
            _gerenciador.Remover(id);

            return Ok();
        }
    }
}