using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klp_api.Models.Res.Stock
{
    public class ValidationStockProductResBodyModel
    {
        public string rut { get; set; }
        public StockProductResBodyModel[] stock { get; set; }
        public string origin { get; set; }
    }
}
