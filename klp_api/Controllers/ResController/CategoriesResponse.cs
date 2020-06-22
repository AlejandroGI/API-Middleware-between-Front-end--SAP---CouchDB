using klp_api.Models.Res.Categories;

namespace klp_api.Controllers.ResController
{
    public class CategoriesResponse
    {
        public dynamic CategoriesBody(dynamic res, string dataSource)
        {
            ValidationCategoriesProductCodeReqsBodyModel jsonObject = new ValidationCategoriesProductCodeReqsBodyModel
            {
                categories = new CategoriesProductCodeResBodyModel[]
                {
                    new CategoriesProductCodeResBodyModel
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
