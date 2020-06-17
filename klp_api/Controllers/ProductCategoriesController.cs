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
    public class ProductCategoriesController : ControllerBase
    {
        // GET api/<ProductCategoriesController>/5
        //para obtener los productos de una categoria y recibir por query el limit y la pagina
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
