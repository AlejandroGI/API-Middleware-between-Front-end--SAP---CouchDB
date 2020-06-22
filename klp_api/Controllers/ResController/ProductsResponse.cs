using klp_api.Controllers.CouchDBControllers;
using klp_api.Models.Res;
using klp_api.Models.Res.Products;

namespace klp_api.Controllers.CouchDBResponseController
{
    public class ProductsResponse : ProductsRequest
    {
        public dynamic ResponseProductsBody(dynamic res, string dataSource)
        {
            ValidationProductsBodyResModel jsonObject = new ValidationProductsBodyResModel
            {
                products = res.doc,
                origin = dataSource
            };
            return jsonObject;
        }

        public dynamic ResponseProductsCodeBody (dynamic res, string dataSource)
        {
            ValidationProductsCodeBodyResModel jsonObject = new ValidationProductsCodeBodyResModel
            {
                products = res,
                origin = dataSource
            };
            return jsonObject;
        }
    }
}
