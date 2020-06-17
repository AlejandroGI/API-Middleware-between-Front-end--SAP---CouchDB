using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Clase modelo de estructura Json a enviar
namespace klp_api.Models.BodyRequest.Products
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
    public class SelectorModel
    {
        public CodeClass code { get; set; }
        [JsonProperty("$or")]
        public OrClass or { get; set; }
    }
}
