
using klp_api.Models.Req.Stock;
using Newtonsoft.Json;

namespace klp_api.Controllers.CouchDBControllers
{
    public class StockRequest
    {
        public dynamic RequestStockBody(string code)
        {
            ValidationStockProductReqBodyModel jsonObject = new ValidationStockProductReqBodyModel
            {
                selector = new StockProductReqBodyModel
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
