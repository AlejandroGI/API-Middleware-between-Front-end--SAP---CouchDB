using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace klp_api.Models.Res.Products
{
    public class ProductsResBodyModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("stock")]
        public string Stock { get; set; }
    }

    public class ProductsCodeResBodyModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("_rev")]
        public string Rev { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        [JsonProperty("groupCode")]
        public int GroupCode { get; set; }
        [JsonProperty("equality")]
        public float Equality { get; set; }
        [JsonProperty("dc")]
        public string Dc { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("pm")]
        public string Pm { get; set; }
        [JsonProperty("apm")]
        public string Apm { get; set; }
        [JsonProperty("equalityFormat")]
        public string EqualityFormat { get; set; }
        [JsonProperty("weightBox")]
        public float WeightBox { get; set; }
        [JsonProperty("boxPallet")]
        public float BoxPallet { get; set; }
        [JsonProperty("termination")]
        public string Termination { get; set; }
        [JsonProperty("serie")]
        public string Serie { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("style")]
        public string Style { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("webName")]
        public string WebName { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("subCategory")]
        public string SubCategory { get; set; }
        [JsonProperty("family")]
        public string Family { get; set; }
        [JsonProperty("provider")]
        public string Provider { get; set; }
        [JsonProperty("maker")]
        public string Maker { get; set; }
        [JsonProperty("makerCode")]
        public string MakerCode { get; set; }
        [JsonProperty("stock")]
        public int Stock { get; set; }
        [JsonProperty("isKit")]
        public int IsKit { get; set; }
        [JsonProperty("stockProvider")]
        public string StockProvider { get; set; }
        [JsonProperty("minSale")]
        public string MinSale { get; set; }
        [JsonProperty("rut")]
        public string Rut { get; set; }
    }
}
