using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonRPC
{
    /// <summary>A JSON Request.</summary>
    public class Request
    {
        internal Request(int id, string method)
            : this(id, method, null)
        {
        }

        internal Request(int id, string method, JToken parameters)
        {
            this.Id = id;
            this.Method = method;
            this.Parameters = parameters;
        }

        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string JsonRPC { get { return "2.0"; } }

        /// <summary>Unique call id.</summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; private set; }

        /// <summary>The rpc method.</summary>
        [JsonProperty("method", Required = Required.Always)]
        public string Method { get; private set; }

        /// <summary>Any parameters, optional.</summary>
        [JsonProperty("params")]
        public JToken Parameters { get; private set; }

        public bool ShouldSerializeParameters()
        {
            return this.Parameters != null;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
