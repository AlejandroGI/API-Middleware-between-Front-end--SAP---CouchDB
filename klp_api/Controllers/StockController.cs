using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.ResController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace klp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockRequest Req = new StockRequest();
        private readonly StockResponse Res = new StockResponse();
        private readonly EndpointSAPAndCouchDB Endpoint = new EndpointSAPAndCouchDB();
        // GET api/<StockController>/5
        //para obtener el stock de un producto, siendo :product el codigo del producto
        [HttpGet("{code}")]
        public async Task<JsonResult> GetAsync(string code)
        {
            dynamic json = Req.RequestStockBody(code);
            var Request = await Endpoint.RequestProductsAsync(json, "stock");
            if (Request != null)
            {
                return new JsonResult(Res.StockProductsBody(Request[0], Request[1]));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }
    }
}
