using System.Text.Json.Serialization;

namespace klp_api.Models.Req.Categories
{
    public class ValidationCategoriesReqBodyModel
    {
        [JsonPropertyName("selector")]
        public CategoriesReqBodyModel Selector { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonPropertyName("skip")]
        public int Skip { get; set; }
    }
}
