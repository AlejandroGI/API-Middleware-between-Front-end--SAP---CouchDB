using klp_api.Models.Res;
using klp_api.Models.Res.Categories;
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
            string endpoint = null;
            dynamic httpResponseCouchDB;
            List<dynamic> JsonAndStatusCode = new List<dynamic>();
            StringContent httpContent = new StringContent(json, null, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                switch (source)
                {
                    case "products":
                        endpoint = "http://52.250.109.79:5984/products/_find";
                        break;
                }
                if (source == "category")
                {
                    httpResponseCouchDB = await httpClient.GetAsync(endpoint); //agregar endpoint de CouchDB a appsetings.
                }
                else
                {
                    httpResponseCouchDB = await httpClient.PostAsync(endpoint, httpContent);
                }
                httpResponse = httpResponseCouchDB;     //Validar origen de SAP o Coach cuando exista SAP
                responseContent = await httpResponse.Content.ReadAsStringAsync();
                jsonOut = source switch
                {
                    "products" => JsonConvert.DeserializeObject<ProductsBodyResModel>(responseContent),
                    _ => null,
                };
                if (jsonOut.bookmark == "nil")
                {
                    jsonOut = null;
                }
                statusCode = (int)httpResponse.StatusCode;
                JsonAndStatusCode.Add(jsonOut);
                JsonAndStatusCode.Add("CouchDB");       //Modificar el origen de datos
            }
            return JsonAndStatusCode;
        }
    }
}
