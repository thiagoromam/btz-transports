using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BtzTransports.Web.Serialization
{
    public class CommonJsonSettings : JsonSerializerSettings
    {
        public CommonJsonSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}