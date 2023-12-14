using BtzTransports.Context;
using BtzTransports.Abastecimentos;
using BtzTransports.Web.Models.Abastecimentos;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace BtzTransports.Web.Api
{
    [Route("api/abastecimentos/{id?}")]
    public class AbastecimentosController : BaseApiController
    {
        private readonly IContextoDeDados _contexto;
        private readonly IGerenciadorDeAbastecimentos _gerenciador;

        public AbastecimentosController(IContextoDeDados contexto, IGerenciadorDeAbastecimentos gerenciador)
        {
            _contexto = contexto;
            _gerenciador = gerenciador;
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            var abastecimentos = _contexto.Abastecimentos
                .Include(a => a.Veiculo)
                .Include(a => a.Motorista) // o lazy load está habilitado, mas o include já carrega tudo numa consulta
                .ToArray();

            // query, buscas e paginação ao invés de enumeração

            var models = abastecimentos.Select(a => AbastecimentoModel.Converter(a, 
                veiculo: true, 
                motorista: true
            ));

            return Ok(models);
        }

        [HttpGet]
        public IHttpActionResult Buscar(int id)
        {
            Abastecimento abastecimento = _contexto.Abastecimentos.Find(id);

            if (abastecimento == null)
                return BadRequest();

            return Ok(AbastecimentoModel.Converter(abastecimento));
        }

        [HttpPost]
        public IHttpActionResult Adicionar(AbastecimentoModel model)
        {
            model.Id = 0;
            Abastecimento abastecimento = model.Converter();

            _gerenciador.Adicionar(abastecimento);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Atualizar(int id, AbastecimentoModel model)
        {
            model.Id = id;
            Abastecimento abastecimento = model.Converter();

            _gerenciador.Atualizar(abastecimento);

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