using SimpleInjector;
using System.Collections.Generic;

namespace General.Injection
{
    public static class InjectionHelper
    {
        public static void RegisterModules(this Container container, IEnumerable<IInjectionModule> modules)
        {
            foreach (var module in modules)
                module.Register(container);
        }
    }
}
