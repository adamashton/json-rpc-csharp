using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonRPC
{
    /// <summary>A JSON Response.</summary>
    public class Response
    {
        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string Version;

        /// <summary>Unique Request Id.</summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id;

        /// <summary>The result if no error occured.</summary>
        [JsonProperty("result", Required = Required.Default)]
        public JToken Result;

        /// <summary>The error. NULL if no error occured.</summary>
        [JsonProperty("error", Required = Required.Default)]
        public Error Error;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public bool ShouldSerializeError()
        {
            return this.Error != null;
        }

        public bool ShouldSerializeResult()
        {
            return this.Result != null;
        }
    }
}
