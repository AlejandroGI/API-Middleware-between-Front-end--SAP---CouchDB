using Newtonsoft.Json;

namespace klp_api.Models.Res
{
    public class ProductsBodyResModel
    {
        [JsonProperty("docs")]
        public Docs[] doc { get; set; }
        public string bookmark { get; set; }
        public string warning { get; set; }
    }
    public class Docs
    {
        public string code { get; set; }
        public string name { get; set; }
    }

}
