using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Res.Categories
{
    public class CategoriesProductCodeResBodyModel
    {
        public DocsClass[] docs { get; set; }
        public string bookmark { get; set; }
    }
    public class DocsClass
    {
        [JsonProperty("_id")]
        public string id { get; set; }
        [JsonProperty("_rev")]
        public string rev { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string groupName { get; set; }
        public int groupCode { get; set; }
        public float equality { get; set; }
        public string dc { get; set; }
        public string unit { get; set; }
        public string format { get; set; }
        public string pm { get; set; }
        public string apm { get; set; }
        public string equalityFormat { get; set; }
        public float weightBox { get; set; }
        public float boxPallet { get; set; }
        public string termination { get; set; }
        public string serie { get; set; }
        public string origin { get; set; }
        public string style { get; set; }
        public string color { get; set; }
        public string brand { get; set; }
        public string webName { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string family { get; set; }
        public string provider { get; set; }
        public string maker { get; set; }
        public string makerCode { get; set; }
        public float inStock { get; set; }
        public float stockCommitted { get; set; }
        public float ocfrp { get; set; }
        public float stockAvailable { get; set; }
        public float isKit { get; set; }
        public string stockProvider { get; set; }
        public string minSale { get; set; }
    }
}
