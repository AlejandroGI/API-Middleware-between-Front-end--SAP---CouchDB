using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.BodyRequest.Products
{
    public class ValidationSelectorModel
    {
        public SelectorModel selector { get; set; }
        public List<string> field { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
    }
}