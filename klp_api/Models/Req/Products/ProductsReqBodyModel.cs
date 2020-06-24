//Clase modelo de estructura Object
using Newtonsoft.Json;

namespace klp_api.Models.Req
{
    public class ProductReqModel
    {
        [JsonProperty("$or")]
        public OrClass[] Or { get; set; }
        [JsonProperty("$and")]
        public AndClass[] And { get; set; }

    }
    public class OrClass
    {
        [JsonProperty("code")]
        public CodeClass Code { get; set; }
        [JsonProperty("name")]
        public NameClass Name { get; set; }
    }
    public class NameClass
    {
        [JsonProperty("$regex")]
        public string Regex { get; set; }
    }
    public class CodeClass
    {
        [JsonProperty("$regex")]
        public string Regex { get; set; }
    }
    public class AndClass
    {
        [JsonProperty("rut")]
        public RutClass Rut { get; set; }
    }
    public class RutClass
    {
        [JsonProperty("$eq")]
        public string Eq { get; set; }
    }
}
