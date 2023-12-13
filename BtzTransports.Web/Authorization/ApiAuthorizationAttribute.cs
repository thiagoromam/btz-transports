using General.Authorization;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BtzTransports.Web.Authorization
{
    public class ApiAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
            var requestContext = new ApiRequestContext(context);
            var integratedAuthorization = new IntegratedAuthorization<AllowAnonymousAttribute>(requestContext);

            integratedAuthorization.Authorize();
        }

        private class ApiRequestContext : IRequestContext
        {
            private readonly HttpActionContext _context;

            public ApiRequestContext(HttpActionContext context)
            {
                _context = context;
            }

            public IPrincipal Principal
            {
                get => _context.RequestContext.Principal;
                set => _context.RequestContext.Principal = value;
            }

            public T GetService<T>() where T : class
            {
                return (T)_context.Request.GetDependencyScope().GetService(typeof(T));
            }
            public IEnumerable<T> GetActionAttributes<T>(bool inherit) where T : Attribute
            {
                return _context.ActionDescriptor.GetCustomAttributes<T>(inherit);
            }
            public IEnumerable<T> GetControllerAttributes<T>(bool inherit) where T : Attribute
            {
                return _context.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<T>(inherit);
            }

            public void HandleUnauthorizedRequest()
            {
                _context.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    RequestMessage = _context.Request
                };
            }
        }
    }
}