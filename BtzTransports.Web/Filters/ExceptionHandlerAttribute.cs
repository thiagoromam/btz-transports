using BtzTransports.Exceptions;
using BtzTransports.Web.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace BtzTransports.Web.Handlers
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CommonException)
            {
                var jsonSettings = new CommonJsonSettings();
                var json = JsonConvert.SerializeObject(new { context.Exception.Message }, jsonSettings);

                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                context.Response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
        }
    }
}