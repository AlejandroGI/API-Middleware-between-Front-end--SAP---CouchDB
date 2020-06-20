using Newtonsoft.Json;

namespace klp_api.Models.Res.Stock
{
    public class StockProductResBodyModel
    {
        public DocsStock[] docs { get; set; }
    }
    public class DocsStock
    {
        [JsonProperty("_id")]
        public string id { get; set; }
        [JsonProperty("_rev")]
        public string rev { get; set; }
        public string code { get; set; }
        public string product { get; set; }
        public string warehouseCode { get; set; }
        public string warehouseName { get; set; }
        public float inStock { get; set; }
        public float committed { get; set; }
        public float proforma { get; set; }
        public float available { get; set; }
    }
}
