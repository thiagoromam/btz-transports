using BtzTransports.Contas;
using BtzTransports.Context;
using BtzTransports.Web.Models.Contas;
using System.Linq;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [Route("api/usuarios/{id?}")]
    public class UsuariosController : BaseApiController
    {
        private readonly IContextoDeDados _contexto;
        private readonly IGerenciadorDeUsuarios _gerenciador;

        public UsuariosController(IContextoDeDados contexto, IGerenciadorDeUsuarios gerenciador)
        {
            _contexto = contexto;
            _gerenciador = gerenciador;
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            var usuarios = _contexto.Usuarios.ToArray();

            // query, buscas e paginação ao invés de enumeração

            return Ok(usuarios.Select(UsuarioModel.Converter));
        }

        [HttpGet]
        public IHttpActionResult Buscar(int id)
        {
            Usuario usuario = _contexto.Usuarios.Find(id);

            if (usuario == null)
                return BadRequest();

            return Ok(UsuarioModel.Converter(usuario));
        }

        [HttpPost]
        public IHttpActionResult Adicionar(UsuarioModel model)
        {
            model.Id = 0;
            Usuario usuario = model.Converter();

            _gerenciador.Adicionar(usuario, model.Senha);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Atualizar(int id, UsuarioModel model)
        {
            model.Id = id;
            Usuario usuario = model.Converter();

            _gerenciador.Atualizar(usuario, model.Senha);

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