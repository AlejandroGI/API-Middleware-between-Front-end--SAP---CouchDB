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
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        //para buscar productos y recibir por query el texto a buscar, el limit y la pagina
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Products" };
        }

        // GET api/<ProductsController>/5
        //para obtener los datos de un producto por su codigo
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Products";
        }
    }
}
