using General.Helpers;
using System.Security.Claims;
using System.Security.Principal;

namespace General.Authorization
{
    public interface ISessionUser : IPrincipal, IIdentity
    {
        bool IsSessionPersisted { get; }

        void Load(ClaimsIdentity claims);
        ClaimsIdentity GetClaims();
    }

    public class SessionUser : ISessionUser
    {
        public bool IsAuthenticated { get; protected set; }
        public string AuthenticationType { get; protected set; }
        public string Name { get; protected set; }
        public bool IsSessionPersisted { get; protected set; }

        public virtual void Load(ClaimsIdentity claims)
        {
            AuthenticationType = claims.AuthenticationType;
            IsAuthenticated = claims.IsAuthenticated;
            Name = claims.GetValue(ClaimTypes.Name);
            IsSessionPersisted = claims.GetValue(nameof(IsSessionPersisted)) == bool.TrueString;
        }
        public virtual ClaimsIdentity GetClaims()
        {
            var claims = new ClaimsIdentity(AuthenticationType);

            claims.AddValue(ClaimTypes.Name, Name);
            claims.AddValue(nameof(IsSessionPersisted), IsSessionPersisted);

            return claims;
        }

        IIdentity IPrincipal.Identity => this;
        bool IPrincipal.IsInRole(string role) => true;
    }
}
