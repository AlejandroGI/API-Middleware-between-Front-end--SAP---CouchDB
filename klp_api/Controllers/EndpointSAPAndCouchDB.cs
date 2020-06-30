using klp_api.Models.Res.Categories;
using klp_api.Models.Res.Products;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace klp_api.Controllers
{
    public class EndpointSAPAndCouchDB
    {
        public async Task<dynamic> RequestProductsAsync(dynamic json, string pathSource, IConfiguration _Configuration)
        {
            dynamic jsonOut;
            dynamic responseContent;
            int statusCode;
            string dataSource;
            dynamic httpResponse;
            List<dynamic> JsonAndStatusCode = new List<dynamic>();
            StringContent httpContent = new StringContent(json, null, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                for (byte i = 0; i <= 1; i++)
                {
                    try
                    {
                        httpResponse = await httpClient.PostAsync(EndpointBuilder(pathSource, i, _Configuration), httpContent);
                        statusCode = (int)httpResponse.StatusCode;
                        if (statusCode == 200)
                        {
                            responseContent = await httpResponse.Content.ReadAsStringAsync();
                            jsonOut = pathSource switch
                            {
                                "products" => JsonConvert.DeserializeObject<ValidationProductsResBodyModel>(responseContent),
                                "productsCode" => JsonConvert.DeserializeObject<EndpointValidationProductsCodeResBodyModel>(responseContent),
                                "categories" => JsonConvert.DeserializeObject<ValidationCategoriesResBodyModel>(responseContent),
                                _ => null,
                            };
                            dataSource = i switch
                            {
                                0 => "SAP",
                                1 => "CouchDB",
                                _ => null,
                            };
                            JsonAndStatusCode.Add(jsonOut);
                            JsonAndStatusCode.Add(dataSource);
                            break;
                        }
                        else
                        {
                            //Manejar 4xx y 5xx
                        }
                    }
                    catch (Exception)
                    {

                        var x = ""; //manejar error en peticiones http
                    }
                }
                //if (jsonOut.Bookmark == "nil")
                //{
                //    jsonOut = null;
                //}
            }
            return JsonAndStatusCode;
        }
        private string EndpointBuilder(string pathSource, int Attempt, IConfiguration _Configuration)
        {
            string path = "unspecified";
            switch (Attempt)
            {
                case 0:
                    path = pathSource switch
                    {
                        //SAP Case
                        "categories" => _Configuration.GetValue<string>("EndpointSettings:Endpoint:SAPEndpoint:Path:Categories"),
                        "products" => _Configuration.GetValue<string>("EndpointSettings:Endpoint:SAPEndpoint:Path:Products"),
                        "productsCode" => _Configuration.GetValue<string>("EndpointSettings:Endpoint:SAPEndpoint:Path:DataProduct"),
                        _ => "unspecified",
                    };
                    if (bool.Parse(_Configuration["EndpointSettings:Consume:SAP"]) == true)

                    {
                        //validar endpoint desde variables de entorno o appsettings
                        if (Environment.GetEnvironmentVariable("EndpointSAP") != "")
                        {
                            string endpoint = $"{Environment.GetEnvironmentVariable("EndpointSAP")}:{_Configuration["EndpointSettings:Endpoint:SAPEndpoint:Port"]}{path}";
                            return endpoint;
                        }
                        else
                        {
                            string endpoint = $"{_Configuration["EndpointSettings:Endpoint:SAPEndpoint:Endpoint"]}:{_Configuration["EndpointSettings:Endpoint:SAPEndpoint:Port"]}{path}";
                            return endpoint;
                        }
                    }
                    break;
                case 1:
                    path = pathSource switch
                    {
                        //CouchDB Case
                        "categories" => _Configuration["EndpointSettings:Endpoint:CouchDBEndpoint:Path:Categories"],
                        "products" => _Configuration["EndpointSettings:Endpoint:CouchDBEndpoint:Path:Products"],
                        "productsCode" => _Configuration["EndpointSettings:Endpoint:CouchDBEndpoint:Path:DataProduct"],
                        _ => "unspecified",
                    };
                    if (bool.Parse(_Configuration["EndpointSettings:Consume:CouchDB"]) == true)
                    {
                        if (Environment.GetEnvironmentVariable("EndpointCouchDB") != "")
                        {
                            string endpoint = $"{Environment.GetEnvironmentVariable("EndpointCouchDB")}:{_Configuration["EndpointSettings:Endpoint:CouchDBEndpoint:Port"]}{path}";
                            return endpoint;
                        }
                        else
                        {
                            string endpoint = $"{_Configuration["EndpointSettings:Endpoint:CouchDBEndpoint:Endpoint"]}:{_Configuration["EndpointSettings:Endpoint:CouchDBEndpoint:Port"]}{path}";
                            return endpoint;
                        }
                    }
                    break;
                default:
                    return "El consumo de datos está deshabilitado desde las configuraciones de la aplicación";
            }
            return "";
        }
    }
}
