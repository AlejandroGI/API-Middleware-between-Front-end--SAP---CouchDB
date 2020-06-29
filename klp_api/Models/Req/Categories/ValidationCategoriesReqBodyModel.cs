using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace klp_api.Models.Req.Categories
{
    public class ValidationCategoriesReqBodyModel
    {
        [JsonProperty("selector")]
        [JsonPropertyName("selector")]
        public CategoriesReqBodyModel Selector { get; set; }
        [JsonProperty("limit")]
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonProperty("skip")]
        [JsonPropertyName("skip")]
        public int Skip { get; set; }
    }
}
