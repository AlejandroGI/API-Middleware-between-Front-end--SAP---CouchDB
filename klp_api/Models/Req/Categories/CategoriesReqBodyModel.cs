using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace klp_api.Models.Req.Categories
{
    public class CategoriesReqBodyModel
    {
        [JsonProperty("groupCode")]
        [JsonPropertyName("groupCode")]
        public ModelIntClass GroupCode { get; set; }
        [JsonProperty("origin")]
        [JsonPropertyName("origin")]
        public ModelStringClass Origin { get; set; }
        [JsonProperty("style")]
        [JsonPropertyName("style")]
        public ModelStringClass Style { get; set; }
        [JsonProperty("color")]
        [JsonPropertyName("color")]
        public ModelStringClass Color { get; set; }
        [JsonProperty("brand")]
        [JsonPropertyName("brand")]
        public ModelStringClass Brand { get; set; }
        [JsonProperty("category")]
        [JsonPropertyName("category")]
        public ModelStringClass Category { get; set; }
        [JsonProperty("subCategory")]
        [JsonPropertyName("subCategory")]
        public ModelStringClass SubCategory { get; set; }
        [JsonProperty("family")]
        [JsonPropertyName("family")]
        public ModelStringClass Family { get; set; }
        [JsonProperty("serie")]
        [JsonPropertyName("serie")]
        public ModelStringClass Serie { get; set; }
        [JsonProperty("termination")]
        [JsonPropertyName("termination")]
        public ModelStringClass Termination { get; set; }
        [JsonProperty("rut")]
        [JsonPropertyName("rut")]
        public RutClass Rut { get; set; }
    }

    public class ModelStringClass
    {
        [JsonProperty("$in")]
        [JsonPropertyName("$in")]
        public string[] In { get; set; }
    }
    public class ModelIntClass
    {
        [JsonProperty("$in")]
        [JsonPropertyName("$in")]
        public int[] In { get; set; }
    }

    public class RutClass
    {
        [JsonProperty("$eq")]
        [JsonPropertyName("$eq")]
        public string Eq { get; set; }
    }
}
