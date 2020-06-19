using Newtonsoft.Json;

namespace klp_api.Models.Req.Prices
{
    public class PricesProductReqBodyModel
    {
        public ProductClass product { get; set; }
    }
    public class ProductClass
    {
        [JsonProperty("$eq")]
        public string eq { get; set; }
    }
}
