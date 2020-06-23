using klp_api.Models.Res.Categories;

namespace klp_api.Controllers.ResController
{
    public class CategoriesResponse
    {
        public dynamic CategoriesBody(dynamic res, string dataSource, string rut)
        {
            if (rut == null || rut == "")
            {
                rut = "No se agrego rut";
            }
            ValidationCategoriesProductCodeReqsBodyModel jsonObject = new ValidationCategoriesProductCodeReqsBodyModel
            {
                rut = rut,
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
