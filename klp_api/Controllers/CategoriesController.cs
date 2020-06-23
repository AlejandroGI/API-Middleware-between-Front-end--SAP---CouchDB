using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.ResController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace klp_api.Controllers
{
    [Route("api/[controller]/products")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRequest Req = new CategoriesRequest();
        private readonly CategoriesResponse Res = new CategoriesResponse();
        private readonly EndpointSAPAndCouchDB Endpoint = new EndpointSAPAndCouchDB();
        /// <summary>
        /// Buscar productos por código
        /// </summary>
        /// <param código="code"></param> 
        [HttpGet("{code}")]
        public async Task<JsonResult> GetAsyncCode(int code, [FromQuery] int? limit, [FromQuery] int? skip, [FromQuery] string rut)
        {
            dynamic json = Req.RequestCategoriesBody(code, limit, skip);
            var Request = await Endpoint.RequestProductsAsync(json, "categoryCode");
            if (Request != null)
            {
                return new JsonResult(Res.CategoriesBody(Request[0], Request[1], rut));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }

        [Route("api/[controller]")]
        /// <summary>
        /// enlistar los primeros 10 productos
        /// </summary>
        // GET api/<CategoriesController>/5
        [HttpGet()]
        public async Task<JsonResult> GetAsync([FromQuery] string rut)
        {
            var Request = await Endpoint.RequestProductsAsync(null, "category");
            if (Request != null)
            {
                return new JsonResult(Res.CategoriesBody(Request[0], Request[1], rut));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }
    }
}
