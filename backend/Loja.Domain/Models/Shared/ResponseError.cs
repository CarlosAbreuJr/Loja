using Newtonsoft.Json;

namespace Loja.Domain.Models.Shared
{
    public class ResponseError
    {
        [JsonProperty("campo")]
        public string Campo { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
