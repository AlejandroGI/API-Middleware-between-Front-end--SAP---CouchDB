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
    public class CategoriesController : ControllerBase
    {
        // GET: api/<CategoriesController>
        //para obtener la lista de categorias. aqui debieses entregar una lista con objetos asi:
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"Categories"};
        }
    }
}
