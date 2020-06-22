using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.CouchDBResponseController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace klp_api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRequest _Req = new ProductsRequest();
        private readonly ProductsResponse _Res = new ProductsResponse();
        private readonly EndpointSAPAndCouchDB _Endpoint = new EndpointSAPAndCouchDB();

        //para obtener la lista de categorias
        [HttpGet]
        public async Task<JsonResult> Get([FromQuery] string code, [FromQuery] string name, [FromQuery] int? limit, [FromQuery] int? skip)
        {

            dynamic json = _Res.RequestProductsBody(code, name, limit, skip);
            var Request = await _Endpoint.RequestProductsAsync(json, "products");
            if (Request != null)
            {
                return new JsonResult(_Res.ResponseProductsBody(Request[0], Request[1]));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }

        //Obtener datos de producto por código
        [HttpGet("{code}")]
        public async Task<JsonResult> GetCodeAsync(string code)
        {
            dynamic json = _Res.RequestProductsCodeBody(code);
            var Request = await _Endpoint.RequestProductsAsync(json, "code");
            if (Request != null)
            {
                return new JsonResult(_Res.ResponseProductsCodeBody(Request[0], Request[1]));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }
    }
}
