using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace klp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // GET api/<StockController>/5
        //para obtener el stock de un producto, siendo :product el codigo del producto
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Stock";
        }
    }
}
