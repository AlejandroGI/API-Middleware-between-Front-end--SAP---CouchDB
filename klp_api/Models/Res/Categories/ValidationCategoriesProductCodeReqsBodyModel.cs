using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Res.Categories
{
    public class ValidationCategoriesProductCodeReqsBodyModel
    {
        public CategoriesProductCodeReqsBodyModel[] categories { get; set; }
        public string origin { get; set; }
    }
}
