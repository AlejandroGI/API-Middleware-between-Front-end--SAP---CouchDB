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
        /// <summary>
        /// Obtener la lista de categorias por su nombre o código. limit y skip son para paginar resultados, si no se piden por defecto serán los 10 primeros resultados
        /// </summary>
        /// <param código="code"></param> 
        [HttpGet]
        public async Task<JsonResult> Get([FromQuery] string code, [FromQuery] int? limit, [FromQuery] int? skip, [FromQuery] string rut)
        {

            dynamic json = _Res.RequestProductsBody(code, limit, skip);
            var Request = await _Endpoint.RequestProductsAsync(json, "products");
            if (Request != null)
            {
                return new JsonResult(_Res.ResponseProductsBody(Request[0], Request[1], rut));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }

        //Obtener datos de producto por código
        /// <summary>
        /// Obtener la lista de categorias por código, devolviendo los primeros 10 resultados
        /// </summary>
        /// <param código="code"></param> 
        [HttpGet("{code}")]
        public async Task<JsonResult> GetCodeAsync(string code, [FromQuery] string rut)
        {
            dynamic json = _Res.RequestProductsCodeBody(code);
            var Request = await _Endpoint.RequestProductsAsync(json, "code");
            if (Request != null)
            {
                return new JsonResult(_Res.ResponseProductsCodeBody(Request[0], Request[1], rut));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }
    }
}
