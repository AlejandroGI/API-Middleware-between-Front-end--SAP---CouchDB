using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.CouchDBResponseController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace klp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRequest Req = new ProductsRequest();
        private readonly ProductsResponse Res = new ProductsResponse();
        private readonly EndpointSAPAndCouchDB Endpoint = new EndpointSAPAndCouchDB();
        // GET: api/<CategoriesController>
        //para obtener la lista de categorias. aqui debieses entregar una lista con objetos asi:
        [HttpGet]
        public async Task<JsonResult> Get([FromQuery] string code, [FromQuery] string name, [FromQuery] int? limit, [FromQuery] int? skip)
        {

            dynamic json = Res.RequestProductsBody(code, name, limit, skip);
            var Request = await Endpoint.RequestProductsAsync(json, "products");
            if (Request != null)
            {
                return new JsonResult(Res.ResponseProductsBody(Request[0], Request[1]));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }

        [HttpGet("{code}")]
        public async Task<JsonResult> GetCode(string code)
        {
            dynamic json = Res.RequestProductsCodeBody(code);
            var Request = await Endpoint.RequestProductsAsync(json, "code");
            if (Request != null)
            {
                return new JsonResult(Res.ResponseProductsCodeBody(Request[0], Request[1]));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }
    }
}
