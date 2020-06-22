using klp_api.Models.Req;
using klp_api.Models.Res.Products;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace klp_api.Controllers.CouchDBControllers
{
    public class ProductsRequest
    {
        public dynamic RequestProductsBody(string code, string name, int? limit, int? skip)
        {
            if (code == null | name == null)
            {
                code = "";
                name = "";
            }
            if (limit == null | skip == null)
            {
                limit = 10;
                skip = 0;
            }
            ValidationProductsReqBodyModel jsonObject = new ValidationProductsReqBodyModel
            {
                selector = new ProductsReqBodyModel()
                {
                    code = new CodeClass()
                    {
                        regex = code
                    },
                    or = new OrClass[]
                    {
                        new OrClass
                        {
                            name = new NameClass
                            {
                                regex = name
                            }
                        }
                    }
                },
                fields = new List<string> { "code", "name" },
                limit = (int)limit,
                skip = (int)skip
            };
            dynamic json = JsonConvert.SerializeObject(jsonObject);
            return json;
        }

        public dynamic RequestProductsCodeBody(string code)
        {
            if (code == null)
            {
                code = "";
            }
            ValidationProductCodeBodyReqModel jsonObject = new ValidationProductCodeBodyReqModel
            {
                selector = new ProductsCodeReqBodyModel
                {
                    code = new ProductCodeClass
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
