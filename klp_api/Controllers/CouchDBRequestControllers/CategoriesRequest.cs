using klp_api.Models.BodyRequest.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace klp_api.Controllers.CouchDBControllers
{
    class CategoriesRequest
    {
        public dynamic RequestBody(string code, string name)
        {
             ValidationSelectorModel jsonObject = new ValidationSelectorModel();
            jsonObject.selector = new SelectorModel()
            {
                code = new CodeClass()
                {
                    regex = code
                },
                or = new OrClass()
                {
                    name = new NameClass()
                    {
                        regex = name
                    }
                }
            };
            jsonObject.field = new List<string> { "code", "name" };
            jsonObject.limit = 10;
            jsonObject.skip = 0;
            dynamic  json = JsonConvert.SerializeObject(jsonObject);
            return json;
        }
    }
}
