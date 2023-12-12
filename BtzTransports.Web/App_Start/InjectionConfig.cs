using BtzTransports.Context.Properties;
using BtzTransports.Domain.Properties;
using BtzTransports.Web.Properties;
using General.Injection;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BtzTransports.Web.App_Start
{
    public static class InjectionConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterModules(GetModules());
            container.RegisterWebApiControllers(configuration);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static IEnumerable<IInjectionModule> GetModules()
        {
            yield return new DomainInjectionModule();
            yield return new ContextInjectionModule();
            yield return new WebInjectionModule();
        }
    }
}