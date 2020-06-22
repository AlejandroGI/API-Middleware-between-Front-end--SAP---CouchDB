using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Req.Categories
{
    public class CategoriesProductCodeReqBodyModel
    {
        public GroupCodeClass groupCode { get; set; }
    }
    public class GroupCodeClass
    {
        [JsonProperty("$eq")]
        public int? eq { get; set; }
    }
}
