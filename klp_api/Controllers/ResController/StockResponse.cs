using klp_api.Models.Res.Stock;

namespace klp_api.Controllers.ResController
{
    public class StockResponse
    {
        public dynamic StockProductsBody(dynamic res, string dataSource)
        {
            ValidationStockProductResBodyModel jsonObject = new ValidationStockProductResBodyModel
            {
                stock = new StockProductResBodyModel[]
                {
                    new StockProductResBodyModel
                    {
                        docs = res.docs
                    }
                },
                origin = dataSource
            };
            return jsonObject;
        }
    }
}
