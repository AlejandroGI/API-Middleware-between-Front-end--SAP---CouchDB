using klp_api.Controllers.CouchDBControllers;
using klp_api.Models.Res;
using klp_api.Models.Res.Products;

namespace klp_api.Controllers.CouchDBResponseController
{
    public class ProductsResponse : ProductsRequest
    {
        public dynamic ResponseProductsBody(dynamic res)
        {
            ValidationBodyResModel jsonObject = new ValidationBodyResModel
            {
                products = res.doc,
                origin = "CouchDB"
            };
            return jsonObject;
        }

        public dynamic ResponseProductsCodeBody (dynamic res)
        {
            ValidationProductsCodeBodyResModel jsonObject = new ValidationProductsCodeBodyResModel
            {
                products = res,
                origin = "CouchDB"
            };
            return jsonObject;
        }
    }
}




