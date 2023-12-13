using General.Authorization;
using General.Helpers;
using System.Security.Claims;

namespace BtzTransports.Contas
{
    public interface IUsuarioDaSessao : ISessionUser
    {
        int Id { get; }
        string Login { get; }

        void Preencher(Usuario usuario, string tipoDeAutenticacao, bool lembrar);
    }

    class UsuarioDaSessao : SessionUser, IUsuarioDaSessao
    {
        public int Id { get; private set; }
        public string Login { get; private set; }

        public void Preencher(Usuario usuario, string tipoDeAutenticacao, bool lembrar)
        {
            IsAuthenticated = true;
            AuthenticationType = tipoDeAutenticacao;
            IsSessionPersisted = lembrar;
            Name = usuario.Nome;
            Id = usuario.Id;
            Login = usuario.Login;
        }

        public override void Load(ClaimsIdentity claims)
        {
            base.Load(claims);

            Id = claims.GetValue(ClaimTypes.NameIdentifier).ToIntOrZero();
            Login = claims.GetValue(nameof(Login)).IfEmptyThenNull();
        }
        public override ClaimsIdentity GetClaims()
        {
            var claims = base.GetClaims();

            claims.AddValue(ClaimTypes.NameIdentifier, Id);
            claims.AddValue(nameof(Login), Login);

            return claims;
        }
    }
}
