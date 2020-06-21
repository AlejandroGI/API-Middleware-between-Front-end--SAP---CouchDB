using klp_api.Models.Req.Categories;
using Newtonsoft.Json;

namespace klp_api.Controllers.CouchDBControllers
{
    public class CategoriesRequest
    {
        public dynamic RequestCategoriesBody(int? groupCode, int? limit, int? skip)
        {
            if (groupCode == null)
            {
                groupCode = 101;
            }
            if (limit == null | skip == null)
            {
                limit = 10;
                skip = 0;
            }
            ValidationCategoriesProductCodeReqBodyModel jsonObject = new ValidationCategoriesProductCodeReqBodyModel
            {
                selector = new CategoriesProductCodeReqBodyModel
                {
                    groupCode = new GroupCodeClass
                    {
                        eq = groupCode
                    }
                },
                limit = limit,
                skip = skip
            };
            dynamic json = JsonConvert.SerializeObject(jsonObject);
            return json;
        }
    }
}

