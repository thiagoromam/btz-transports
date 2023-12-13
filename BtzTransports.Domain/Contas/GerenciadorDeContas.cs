using BtzTransports.Context;
using System.Linq;

namespace BtzTransports.Contas
{
    public interface IGerenciadorDeContas
    {
        Usuario Logar(string login, string senha);

        bool VerificarDisponibilidade(int id, string login);
    }

    class GerenciadorDeContas : IGerenciadorDeContas
    {
        private readonly IContextoDeDados _contexto;

        public GerenciadorDeContas(IContextoDeDados contexto)
        {
            _contexto = contexto;
        }

        public Usuario Logar(string login, string senha)
        {
            Usuario usuario = _contexto.Usuarios.SingleOrDefault(u => u.Login == login);

            if (usuario?.VerificarSenha(senha) == true)
                return usuario;

            return null;
        }

        public bool VerificarDisponibilidade(int id, string login)
        {
            var query = _contexto.Usuarios.AsQueryable();

            if (id > 0)
                query = query.Where(u => u.Id != id); // outros usuários

            return !query.Any(u => u.Login == login);
        }
    }
}
