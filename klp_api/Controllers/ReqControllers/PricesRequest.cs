using klp_api.Models.Req.Prices;
using Newtonsoft.Json;

namespace klp_api.Controllers.CouchDBControllers
{
    public class PricesRequest
    {

        public dynamic RequestPricesProductsBody(string code)
        {
            ValidationPricesProductReqBodyModel jsonObject = new ValidationPricesProductReqBodyModel
            {
                selector = new PricesProductReqBodyModel
                {
                    product = new ProductClass
                    {
                        eq = code
                    }
                }
            };
            dynamic json = JsonConvert.SerializeObject(jsonObject);
            return json;
        }
    }
}
