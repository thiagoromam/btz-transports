using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace General.Authorization
{
    public interface IRequestContext
    {
        IPrincipal Principal { get; set; }

        T GetService<T>() where T : class;
        IEnumerable<T> GetActionAttributes<T>(bool inherit) where T : Attribute;
        IEnumerable<T> GetControllerAttributes<T>(bool inherit) where T : Attribute;

        void HandleUnauthorizedRequest();
    }
}
