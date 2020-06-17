using klp_api.Controllers.CouchDBControllers;
using klp_api.Models.Res;

namespace klp_api.Controllers.CouchDBResponseController
{
    public class CategoriesResponse : CategoriesRequest
    {
        public dynamic ResponseBody(dynamic res)
        {
            ValidationBodyResModel jsonObject = new ValidationBodyResModel
            {
                products = res.doc,
                origin = "CouchDB"
            };
            return jsonObject;
        }
    }
}




