using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace klp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EndpointSAPAndCouchDB _Endpoint = new EndpointSAPAndCouchDB();
        /// <summary>
        /// Buscar productos por código
        /// </summary>
        [HttpGet]
        public async Task<JsonResult> GetAsyncCode([FromBody]dynamic jsonIn)
        {
            var json = JsonConvert.SerializeObject(jsonIn);
            var Request = await _Endpoint.RequestProductsAsync(json, "category");
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
