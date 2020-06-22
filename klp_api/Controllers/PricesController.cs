using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.ResController;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace klp_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly PricesRequest Req = new PricesRequest();
        private readonly PricesResponse Res = new PricesResponse();
        private readonly EndpointSAPAndCouchDB Endpoint = new EndpointSAPAndCouchDB();
        // GET api/<PricesController>/5
        //para obtener los precios de un producto, siendo :product el codigo del producto
        [HttpGet("{code}")]
        public async Task<JsonResult> GetAsync(string code)
        {
            dynamic json = Req.RequestPricesProductsBody(code);
            var Request = await Endpoint.RequestProductsAsync(json, "pricesProduct");
            if (Request != null)
            {
                return new JsonResult(Res.PriceProductsBody(Request[0], Request[1]));
            }
            else
            {
                return new JsonResult("error en petición a endpoint CouchDB y SAP");
            }
        }
    }
}
