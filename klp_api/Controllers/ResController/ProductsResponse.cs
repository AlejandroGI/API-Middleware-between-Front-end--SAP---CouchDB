using klp_api.Controllers.CouchDBControllers;
using klp_api.Models.Res;
using klp_api.Models.Res.Products;

namespace klp_api.Controllers.CouchDBResponseController
{
    public class ProductsResponse : ProductsRequest
    {
        private ValidationProductsResBodyModel _jsonObject;
        public dynamic ResponseProductsBody(dynamic res, string dataSource, string rut)
        {
            if (rut == null | rut == "")
            {
                rut = "No se agregó rut a la petición";
            }
             _jsonObject = new ValidationProductsResBodyModel
             {
                Rut = rut,
                Docs = res.Docs,
                Origin = dataSource
            };
            return _jsonObject;
        }

        public void ResponseProductsCodeBody (dynamic res, string dataSource, string rut)
        {
            if (rut == null | rut == "")
            {
                rut = "No se agregó rut a la petición";
            }
            
        }
    }
}
