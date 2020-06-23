using Newtonsoft.Json;

namespace klp_api.Models.Res.Prices
{
    public class PricesProductResBodyModel
    {
        public DocsPrices[] docs { get; set; }
        public string bookmark { get; set; }
    }
    public class DocsPrices
    {
        [JsonProperty("_id")]
        public string id { get; set; }
        [JsonProperty("_rev")]
        public string rev { get; set; }
        public string code { get; set; }
        public string product { get; set; }
        public int priceListCode { get; set; }
        public string priceListName { get; set; }
        public string currency { get; set; }
        public float price { get; set; }
        public float discount { get; set; }
        public float finalPrice { get; set; }
    }
}
