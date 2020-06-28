using klp_api.Controllers.CouchDBResponseController;
using klp_api.Models.Req.Categories;
using klp_api.Models.Res.Categories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace klp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EndpointSAPAndCouchDB _Endpoint = new EndpointSAPAndCouchDB();
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<JsonResult> GetAsync([FromBody] ValidationCategoriesReqBodyModel jsonIn)
        {
            var json = JsonConvert.SerializeObject(jsonIn, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            List<dynamic> Request = await _Endpoint.RequestProductsAsync(json, "categories");
            if (Request != null)
            {
                return new JsonResult(Request[0]);
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }

    }
}
