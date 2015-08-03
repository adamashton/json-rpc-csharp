using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonRPC
{
    public class GenericResponse : Response
    {
        /// <summary>The result if no error occured.</summary>
        [JsonProperty("result", Required = Required.Default)]
        public JToken Result;

        public bool ShouldSerializeResult()
        {
            return this.Result != null;
        }
    }
}