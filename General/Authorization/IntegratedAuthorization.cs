using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;

namespace General.Authorization
{
    public class IntegratedAuthorization<TAllowAnonymousAttribute> where TAllowAnonymousAttribute : Attribute
    {
        private readonly IRequestContext _context;

        public IntegratedAuthorization(IRequestContext context)
        {
            _context = context;
        }

        public void Authorize()
        {
            UpdatePrincipal();

            if (AllowAnonymous())
                return;

            if (!IsAuthorized())
                _context.HandleUnauthorizedRequest();
        }

        private void UpdatePrincipal()
        {
            ISessionUser user = _context.GetService<ISessionUser>() ?? throw new Exception("The ISessionUser object is not registered.");
            IAuthenticationManager authenticationManager = _context.GetService<IAuthenticationManager>() ?? throw new Exception("The IAuthenticationManager object is not registered.");

            user.Load((ClaimsIdentity)_context.Principal.Identity);

            if (user.IsAuthenticated)
            {
                authenticationManager.SignOut(user.AuthenticationType);
                user.Load(new ClaimsIdentity());
            }

            _context.Principal = user;
        }
        private bool AllowAnonymous()
        {
            if (ActionHasAttribute<TAllowAnonymousAttribute>()) return true;
            if (ControllerHasAttribute<TAllowAnonymousAttribute>()) return true;

            return false;
        }
        private bool IsAuthorized()
        {
            return _context.Principal.Identity.IsAuthenticated;
        }

        private bool ActionHasAttribute<T>() where T : Attribute
        {
            return _context.GetActionAttributes<T>(false).Any();
        }
        private bool ControllerHasAttribute<T>() where T : Attribute
        {
            return _context.GetControllerAttributes<T>(false).Any();
        }
    }
}
