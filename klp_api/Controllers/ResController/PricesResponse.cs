using klp_api.Models.Res.Prices;

namespace klp_api.Controllers.ResController
{
    public class PricesResponse
    {
        public dynamic PriceProductsBody(dynamic res, string dataSource)
        {
            ValidationPricesProductResBodyModel jsonObject = new ValidationPricesProductResBodyModel
            {
                
                prices = new PricesProductResBodyModel[]
                {
                    new PricesProductResBodyModel
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
