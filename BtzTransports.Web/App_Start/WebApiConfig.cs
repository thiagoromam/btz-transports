using General.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace BtzTransports.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var xmlFormatter = config.Formatters.OfType<XmlMediaTypeFormatter>().Single();
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().Single();

            config.Formatters.Remove(xmlFormatter);

            jsonFormatter.SerializerSettings = new CommonJsonSettings();
        }
    }
}
