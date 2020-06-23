using klp_api.Models.Res.Stock;

namespace klp_api.Controllers.ResController
{
    public class StockResponse
    {
        public dynamic StockProductsBody(dynamic res, string dataSource, string rut)
        {
            if (rut == null || rut == "")
            {
                rut = "No se agregó rut";
            }
            ValidationStockProductResBodyModel jsonObject = new ValidationStockProductResBodyModel
            {
                rut = rut,
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
