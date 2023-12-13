using BtzTransports.Context;
using BtzTransports.Exceptions;
using General.Exceptions;
using General.Helpers;

namespace BtzTransports.Contas
{
    public interface IGerenciadorDeUsuarios
    {
        void Adicionar(Usuario usuario, string senha);
        void Atualizar(Usuario usuario, string senha);
        void Remover(int id);
    }

    class GerenciadorDeUsuarios : IGerenciadorDeUsuarios
    {
        private readonly IContextoDeDados _contexto;
        private readonly IGerenciadorDeContas _gerenciadorDeContas;

        public GerenciadorDeUsuarios(IContextoDeDados contexto, IGerenciadorDeContas gerenciadorDeContas)
        {
            _contexto = contexto;
            _gerenciadorDeContas = gerenciadorDeContas;
        }

        public void Adicionar(Usuario usuario, string senha)
        {
            ValidarDisponibilidade(usuario);

            usuario.DefinirSenha(senha);

            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }
        public void Atualizar(Usuario usuario, string senha)
        {
            ValidarDisponibilidade(usuario);

            Usuario existente = _contexto.Usuarios.Find(usuario.Id) ?? throw new NotFoundException();

            existente.Nome = usuario.Nome;
            existente.Login = usuario.Login;

            if (!senha.IsNullOrWhiteSpace())
                existente.DefinirSenha(senha);

            _contexto.SaveChanges();
        }
        public void Remover(int id)
        {
            Usuario usuario = _contexto.Usuarios.Find(id) ?? throw new NotFoundException();

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
        }

        private void ValidarDisponibilidade(Usuario usuario)
        {
            if (!_gerenciadorDeContas.VerificarDisponibilidade(usuario.Id, usuario.Login))
                throw new CommonException("Esse login já está em uso.");
        }
    }
}
