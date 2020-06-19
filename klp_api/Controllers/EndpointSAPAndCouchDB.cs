using klp_api.Models.Res;
using klp_api.Models.Res.Prices;
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
            List<dynamic> JsonAndStatusCode = new List<dynamic>();
            StringContent httpContent = new StringContent(json, null, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                //var httpResponseSAP = await httpClient.PostAsync("http://sap.examplesap", httpContent); //agregar endpoint de SAP a appsetings.
                var httpResponseCouchDB = await httpClient.PostAsync("http://52.250.109.79:5984/prices/_find", httpContent); //agregar endpoint de CouchDB a appsetings.
                httpResponse = httpResponseCouchDB;     //Validar origen de SAP o Coach cuando exista SAP
                responseContent = await httpResponse.Content.ReadAsStringAsync();
                jsonOut = source switch
                {
                    "code" => JsonConvert.DeserializeObject<ProductsCodeBodyResModel>(responseContent),
                    "products" => JsonConvert.DeserializeObject<ProductsBodyResModel>(responseContent),
                    "pricesProduct" => JsonConvert.DeserializeObject<PricesProductResBodyModel>(responseContent),   //AREGLAR AQUÍ
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
