using klp_api.Models.Res.Categories;
using klp_api.Models.Res.Products;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace klp_api.Controllers
{
    public class EndpointSAPAndCouchDB
    {
        public async Task<dynamic> RequestProductsAsync(dynamic json, string source)   //Agregar endpoint y petición por SAP
        {
            dynamic jsonOut;
            dynamic responseContent;
            dynamic statusCode;
            string dataSource;
            dynamic httpResponse;
            string endpoint = "http://142.93.60.130:5984/products/_find";
            dynamic httpResponseCouchDB;
            List<dynamic> JsonAndStatusCode = new List<dynamic>();
            StringContent httpContent = new StringContent(json, null, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                httpResponseCouchDB = await httpClient.PostAsync(endpoint, httpContent);
                httpResponse = httpResponseCouchDB;     //Validar origen de SAP o Coach cuando exista SAP
                responseContent = await httpResponse.Content.ReadAsStringAsync();
                jsonOut = source switch
                {
                    "products" => JsonConvert.DeserializeObject<ValidationProductsResBodyModel>(responseContent),
                    "productsCode" => JsonConvert.DeserializeObject<EndpointValidationProductsCodeResBodyModel>(responseContent),
                    "categories" => JsonConvert.DeserializeObject<ValidationCategoriesResBodyModel>(responseContent),
                    _ => null,
                };
                //if (jsonOut.Bookmark == "nil")
                //{
                //    jsonOut = null;
                //}
                statusCode = (int)httpResponse.StatusCode;
                JsonAndStatusCode.Add(jsonOut);
                JsonAndStatusCode.Add("CouchDB");       //Modificar el origen de datos
            }
            return JsonAndStatusCode;
        }
    }
}
