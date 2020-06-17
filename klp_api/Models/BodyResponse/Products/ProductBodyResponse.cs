using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.BodyResponse
{
    public class ProductBodyResponse
    {
        public Products products { get; set; }
        public string origin { get; set; }
    }
    public class Products
    {
        public Docs doc { get; set; }
        public string bookmark { get; set; }
        public string warning { get; set; }
    }
    public class Docs
    {
        public string code { get; set; }
        public string name { get; set; }
    }

}
