using Newtonsoft.Json;

namespace klp_api.Models
{
    public class GenericResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }
    }
}
