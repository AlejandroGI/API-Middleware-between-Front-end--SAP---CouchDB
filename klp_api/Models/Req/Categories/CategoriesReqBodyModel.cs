using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace klp_api.Models.Req.Categories
{
    public class CategoriesReqBodyModel
    {
        [JsonPropertyName("groupCode")]
        public ModelIntClass GroupCode { get; set; }
        [JsonPropertyName("origin")]
        public ModelStringClass Origin { get; set; }
        [JsonPropertyName("style")]
        public ModelStringClass Style { get; set; }
        [JsonPropertyName("color")]
        public ModelStringClass Color { get; set; }
        [JsonPropertyName("brand")]
        public ModelStringClass Brand { get; set; }
        [JsonPropertyName("category")]
        public ModelStringClass Category { get; set; }
        [JsonPropertyName("subCategory")]
        public ModelStringClass SubCategory { get; set; }
        [JsonPropertyName("family")]
        public ModelStringClass Family { get; set; }
        [JsonPropertyName("serie")]
        public ModelStringClass Serie { get; set; }
        [JsonPropertyName("termination")]
        public ModelStringClass Termination { get; set; }
        [JsonPropertyName("rut")]
        public RutClass Rut { get; set; }
    }

    public class ModelStringClass
    {
        [JsonPropertyName("$in")]
        public string[] In { get; set; }
    }
    public class ModelIntClass
    {
        [JsonPropertyName("$in")]
        public int[] In { get; set; }
    }

    public class RutClass
    {
        [JsonPropertyName("$eq")]
        public string Eq { get; set; }
    }
}
