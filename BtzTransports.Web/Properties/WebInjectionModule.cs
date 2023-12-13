using General.Injection;
using SimpleInjector;
using System.Web;

namespace BtzTransports.Web.Properties
{
    public class WebInjectionModule : IInjectionModule
    {
        public void Register(Container container)
        {
            container.Register(() => HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}