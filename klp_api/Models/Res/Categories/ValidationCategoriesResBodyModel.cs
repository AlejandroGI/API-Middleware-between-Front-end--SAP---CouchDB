using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Res.Categories
{
    public class ValidationCategoriesResBodyModel
    {
        [JsonProperty("docs")]
        public CategoriesResBodyModel[] Docs { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
    }
}
