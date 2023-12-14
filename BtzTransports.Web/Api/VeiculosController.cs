using BtzTransports.Context;
using BtzTransports.Veiculos;
using BtzTransports.Web.Models.Veiculos;
using System.Linq;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [Route("api/veiculos/{id?}")]
    public class VeiculosController : BaseApiController
    {
        private readonly IContextoDeDados _contexto;
        private readonly IGerenciadorDeVeiculos _gerenciador;

        public VeiculosController(IContextoDeDados contexto, IGerenciadorDeVeiculos gerenciador)
        {
            _contexto = contexto;
            _gerenciador = gerenciador;
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            var veiculos = _contexto.Veiculos.ToArray();

            // query, buscas e paginação ao invés de enumeração

            return Ok(veiculos.Select(VeiculoModel.Converter));
        }

        [HttpGet]
        public IHttpActionResult Buscar(int id)
        {
            Veiculo veiculo = _contexto.Veiculos.Find(id);

            if (veiculo == null)
                return BadRequest();

            return Ok(VeiculoModel.Converter(veiculo));
        }

        [HttpPost]
        public IHttpActionResult Adicionar(VeiculoModel model)
        {
            model.Id = 0;
            Veiculo veiculo = model.Converter();

            _gerenciador.Adicionar(veiculo);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Atualizar(int id, VeiculoModel model)
        {
            model.Id = id;
            Veiculo veiculo = model.Converter();

            _gerenciador.Atualizar(veiculo);

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