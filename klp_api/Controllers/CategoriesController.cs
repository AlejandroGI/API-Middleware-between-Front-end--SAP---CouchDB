using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.CouchDBResponseController;
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
        public void GetAsync([FromQuery] string code, [FromQuery] string name)
        {
            CategoriesRequest request = new CategoriesRequest();
            CategoriesResponse response = new CategoriesResponse();
            dynamic json = request.RequestBody(code, name);
            response.ResponseCategoriesAsync(json, "");
        }
    }
}
