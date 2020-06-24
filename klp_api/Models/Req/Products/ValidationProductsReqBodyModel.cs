using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Req.Products
{
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
}
