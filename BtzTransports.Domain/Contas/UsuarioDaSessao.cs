using General.Authorization;

namespace BtzTransports.Contas
{
    public interface IUsuarioDaSessao : ISessionUser
    {
        int Id { get; }
        string Nome { get; }
        string Login { get; }
    }

    class UsuarioDaSessao : SessionUser, IUsuarioDaSessao
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
    }
}
