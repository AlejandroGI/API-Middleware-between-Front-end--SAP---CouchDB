using System.Collections.Generic;

namespace klp_api.Models.Req
{
    //Clase validación para estructura de Json
    public class ValidationProductsReqBodyModel
    {
        public ProductsReqBodyModel selector { get; set; }
        public List<string> fields { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
    }
}