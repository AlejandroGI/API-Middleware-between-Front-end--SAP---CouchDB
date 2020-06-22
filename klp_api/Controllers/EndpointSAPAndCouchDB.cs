using klp_api.Models.Res;
using klp_api.Models.Res.Categories;
using klp_api.Models.Res.Prices;
using klp_api.Models.Res.Stock;
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
                    case "code":
                        endpoint = "http://52.250.109.79:5984/products/_find";
                        break;
                    case "products":
                        endpoint = "http://52.250.109.79:5984/products/_find";
                        break;
                    case "pricesProduct":
                        endpoint = "http://52.250.109.79:5984/prices/_find";
                        break;
                    case "stock":
                        endpoint = "http://52.250.109.79:5984/stock/_find";
                        break;
                    case "categoryCode":
                        endpoint = "http://52.250.109.79:5984/products/_find";
                        break;
                    case "category":
                        endpoint = "http://52.250.109.79:5984/products/_design/categories/_view/categories?group=true";
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
                    "code" => JsonConvert.DeserializeObject<ProductsCodeBodyResModel>(responseContent),
                    "products" => JsonConvert.DeserializeObject<ProductsBodyResModel>(responseContent),
                    "pricesProduct" => JsonConvert.DeserializeObject<PricesProductResBodyModel>(responseContent),
                    "stock" => JsonConvert.DeserializeObject<StockProductResBodyModel>(responseContent),
                    "categoryCode" => JsonConvert.DeserializeObject<CategoriesProductCodeResBodyModel>(responseContent),
                    "category" => JsonConvert.DeserializeObject<CategoriesProductCodeResBodyModel>(responseContent),
                    _ => null,
                };
                statusCode = (int)httpResponse.StatusCode;
                JsonAndStatusCode.Add(jsonOut);
                JsonAndStatusCode.Add("CouchDB");       //Modificar el origen de datos
            }
            return JsonAndStatusCode;
        }
    }
}
