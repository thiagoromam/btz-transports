using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace General.Serialization
{
    public class CommonJsonSettings : JsonSerializerSettings
    {
        public CommonJsonSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}