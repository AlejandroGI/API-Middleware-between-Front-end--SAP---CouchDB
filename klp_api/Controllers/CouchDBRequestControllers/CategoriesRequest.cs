using klp_api.Models.Req;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace klp_api.Controllers.CouchDBControllers
{
    public class CategoriesRequest
    {
        public dynamic RequestBody(string code, string name)
        {
            if (code == null | name == null)
            {
                code = "";
                name = "";
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
                limit = 10,
                skip = 0
            };
            dynamic json = JsonConvert.SerializeObject(jsonObject);
            return json;
        }

        public async Task<dynamic> RequestAsync(dynamic json)
        {
            dynamic jsonOut;
            dynamic ResponseContent;

            var httpContent = new StringContent(json, null, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.PostAsync("http://52.250.109.79:5984/products/_find", httpContent);
                ResponseContent = await httpResponse.Content.ReadAsStringAsync();
                jsonOut = JsonConvert.DeserializeObject<klp_api.Models.Res.ProductsBodyResModel>(ResponseContent);
                var StatusCode = (int)httpResponse.StatusCode;
            }
            return jsonOut;
        }
    }
}
