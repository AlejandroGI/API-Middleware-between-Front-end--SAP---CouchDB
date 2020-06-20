using Newtonsoft.Json;

namespace klp_api.Models.Req.Stock
{
    public class StockProductReqBodyModel
    {
        public ProductClass product { get; set; }
    }
    public class ProductClass
    {
        [JsonProperty("$eq")]
        public string eq { get; set; }
    }

}
