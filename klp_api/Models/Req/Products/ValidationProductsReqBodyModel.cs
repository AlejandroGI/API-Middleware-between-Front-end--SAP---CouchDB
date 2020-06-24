using Newtonsoft.Json;

namespace klp_api.Models.Req.Products
{
    //~/api/products
    public class ValidationProductsReqBodyModel
    {
        [JsonProperty("selector")]
        public ProductReqModel Selector { get; set; }
        [JsonProperty("fields")]
        public string[] Fields { get; set; }
        [JsonProperty("limit")]
        public int? Limit { get; set; }
        [JsonProperty("skip")]
        public int? Skip { get; set; }
    }
    //~/api/products/:code
    public class ValidationProductsCodeReqBodyModel
    {
        [JsonProperty("selector")]
        public ProductsCodeModel Selector { get; set; }
    }
}
