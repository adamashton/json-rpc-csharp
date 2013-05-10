using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonRPC
{
    public class Error
    {
        [JsonProperty("code", Required = Required.Always)]
        public int Code;

        [JsonProperty("message", Required = Required.Always)]
        public string Message;

        [JsonProperty("data")]
        public JToken Data;

        public bool ShouldSerializeData()
        {
            return this.Data != null;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
