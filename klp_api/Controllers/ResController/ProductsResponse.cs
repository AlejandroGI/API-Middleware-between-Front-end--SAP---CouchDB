using klp_api.Controllers.CouchDBControllers;
using klp_api.Models.Res;
using klp_api.Models.Res.Products;

namespace klp_api.Controllers.CouchDBResponseController
{
    public class ProductsResponse : ProductsRequest
    {
        public dynamic ResponseProductsBody(dynamic res, string dataSource, string rut)
        {
            if (rut == null | rut == "")
            {
                rut = "No se agregó rut a la petición";
            }
            ValidationProductsBodyResModel jsonObject = new ValidationProductsBodyResModel
            {
                rut = rut,
                products = res.doc,
                origin = dataSource
            };
            return jsonObject;
        }

        public dynamic ResponseProductsCodeBody (dynamic res, string dataSource, string rut)
        {
            if (rut == null | rut == "")
            {
                rut = "No se agregó rut a la petición";
            }
            ValidationProductsCodeBodyResModel jsonObject = new ValidationProductsCodeBodyResModel
            {
                rut = rut,
                products = res,
                origin = dataSource
            };
            return jsonObject;
        }
    }
}
