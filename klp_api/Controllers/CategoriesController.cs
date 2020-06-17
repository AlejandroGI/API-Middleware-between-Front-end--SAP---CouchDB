using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klp_api.Models.BodyRequest.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
        public void Get()
        {
            ValidationSelectorModel jsonObject = new ValidationSelectorModel();
            dynamic selector = new SelectorModel();
            jsonObject.selector = new SelectorModel()
            {
                code = new CodeClass()
                {
                    regex = ""
                },
                or = new OrClass()
                {
                    name = new NameClass()
                    {
                        regex = ""
                    }
                }
            };
            jsonObject.field = new List<string> { "code", "name" };
            jsonObject.limit = 10;
            jsonObject.skip = 0;
            var json = JsonConvert.SerializeObject(jsonObject);
        }
    }
}
