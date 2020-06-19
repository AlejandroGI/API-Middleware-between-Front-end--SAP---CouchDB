using klp_api.Models.Req;
using klp_api.Models.Res.Products;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<dynamic> RequestProductsAsync(dynamic json, string source)   //Agregar endpoint y petición por SAP
        {
            dynamic jsonOut;
            dynamic ResponseContent;

            StringContent httpContent = new StringContent(json, null, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.PostAsync("http://52.250.109.79:5984/products/_find", httpContent);
                ResponseContent = await httpResponse.Content.ReadAsStringAsync();
                jsonOut = source switch
                {
                    "code" => JsonConvert.DeserializeObject<Models.Res.ProductsCodeBodyResModel>(ResponseContent),
                    "products" => JsonConvert.DeserializeObject<Models.Res.ProductsBodyResModel>(ResponseContent),
                    _ => null,
                };
                var StatusCode = (int)httpResponse.StatusCode;
            }
            return jsonOut;
        }
    }
}
