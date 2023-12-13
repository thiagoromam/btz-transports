using General.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web.Mvc;

namespace BtzTransports.Web.Authorization
{
    public class MvcAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            var requestContext = new MvcRequestContext(context);
            var integratedAuthorization = new IntegratedAuthorization<AllowAnonymousAttribute>(requestContext);

            integratedAuthorization.Authorize();
        }

        private class MvcRequestContext : IRequestContext
        {
            private readonly AuthorizationContext _context;

            public MvcRequestContext(AuthorizationContext context)
            {
                _context = context;
            }

            public IPrincipal Principal
            {
                get => _context.HttpContext.User;
                set => _context.HttpContext.User = value;
            }

            public T GetService<T>() where T : class
            {
                return DependencyResolver.Current.GetService<T>();
            }
            public IEnumerable<T> GetActionAttributes<T>(bool inherit) where T : Attribute
            {
                return _context.ActionDescriptor.GetCustomAttributes(inherit).OfType<T>();
            }
            public IEnumerable<T> GetControllerAttributes<T>(bool inherit) where T : Attribute
            {
                return _context.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(inherit).OfType<T>();
            }

            public void HandleUnauthorizedRequest()
            {
                _context.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
        }
    }
}