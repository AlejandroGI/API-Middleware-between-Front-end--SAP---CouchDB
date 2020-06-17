using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Res
{
    public class ValidationBodyResModel
    {
        public Docs[] products { get; set; }
        public string origin { get; set; }
    }
}
