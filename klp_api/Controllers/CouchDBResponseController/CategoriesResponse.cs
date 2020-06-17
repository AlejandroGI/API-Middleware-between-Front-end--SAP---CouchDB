using klp_api.Controllers.CouchDBControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace klp_api.Controllers.CouchDBResponseController
{
    public class CategoriesResponse
    {
        public async Task ResponseCategoriesAsync(dynamic json, string endpoint)
        {
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.PostAsync("http://52.250.109.79:5984/products/_find", httpContent);
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var statusCode = (int)httpResponse.StatusCode;
                }
            }
        }
    }
}
