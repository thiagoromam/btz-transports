using General.Injection;
using SimpleInjector;

namespace BtzTransports.Context.Properties
{
    public class ContextInjectionModule : IInjectionModule
    {
        public void Register(Container container)
        {
            container.Register<IContextoDeDados, ContextoDeDados>(Lifestyle.Scoped);
        }
    }
}
