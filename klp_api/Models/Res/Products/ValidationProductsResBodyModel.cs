using Newtonsoft.Json;

namespace klp_api.Models.Res.Products
{
    //~/api/products
    public class ValidationProductsResBodyModel
    {
        [JsonProperty("rut")]
        public string Rut { get; set; }
        [JsonProperty("docs")]
        public ProductsResBodyModel[] Docs { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("bookmark")]
        public string Bookmark { get; set; }
    }
    //~/api/products/:code

    public class ValidationProductsCodeResBodyModel
    {
        [JsonProperty("rut")]
        public string Rut { get; set; }
        [JsonProperty("docs")]
        public ProductsCodeResBodyModel[] Docs { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("bookmark")]
        public string Bookmark { get; set; }
    }
    public class EndpointValidationProductsCodeResBodyModel
    {
        [JsonProperty("docs")]
        public ProductsCodeResBodyModel[] Docs { get; set; }
    }

}
