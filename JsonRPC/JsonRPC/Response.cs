using Newtonsoft.Json;

namespace JsonRPC
{
    /// <summary>A JSON Response.</summary>
    public abstract class Response
    {
        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string Version;

        /// <summary>Unique Request Id.</summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id;

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
    }
}
