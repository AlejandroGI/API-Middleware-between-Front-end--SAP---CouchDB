using klp_api.Models.Res.Categories;

namespace klp_api.Controllers.ResController
{
    public class CategoriesResponse
    {
        private ValidationCategoriesResBodyModel _jsonObject;
        public dynamic ResponseProductsBody(dynamic res, string dataSource)
        {
            _jsonObject = new ValidationCategoriesResBodyModel
            {
                Docs = res.Docs,
                Origin = dataSource
            };
            return _jsonObject;
        }
    }
}
