using System.Threading.Tasks;
using klp_api.Controllers.CouchDBControllers;
using klp_api.Controllers.CouchDBResponseController;
using Microsoft.AspNetCore.Mvc;


namespace klp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/<CategoriesController>
        //para obtener la lista de categorias. aqui debieses entregar una lista con objetos asi:
        [HttpGet]
        public async Task<JsonResult> Get([FromQuery] string code, [FromQuery] string name)
        {
            CategoriesRequest Req = new CategoriesRequest();
            CategoriesResponse Res = new CategoriesResponse();
            dynamic json = Res.RequestBody(code, name);
            var Request = await Req.RequestAsync(json);
            var h = Res.ResponseBody(Request);
            return new JsonResult(h);
            
        }
    }
}
