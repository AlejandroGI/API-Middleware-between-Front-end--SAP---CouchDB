using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

//Clase modelo de estructura Object
namespace klp_api.Models.Req
{
    
    public class CodeClass
    {
        [JsonProperty("$regex")]
        public string regex { get; set; }
    }
    public class OrClass
    {
        public NameClass name { get; set; }
    }
    public class NameClass
    {
        [JsonProperty("$regex")]
        public string regex { get; set; }
    }
    public class ProductsReqBodyModel
    {
        public CodeClass code { get; set; }
        [JsonProperty("$or")]
        public OrClass[]  or { get; set; }
    }
}
