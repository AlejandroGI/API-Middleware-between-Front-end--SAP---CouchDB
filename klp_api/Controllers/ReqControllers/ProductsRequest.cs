using klp_api.Models.Req.Products;
using Newtonsoft.Json;

namespace klp_api.Controllers.CouchDBControllers
{
    public class ProductsRequest
    {
        private ValidationProductsReqBodyModel _jsonObject;
        public dynamic RequestProductsBody(string code, string name, int? limit, int? skip, string rut)
        {
            if (name == null)
            {
                name = "";
            }
            if (code == null)
            {
                code = "";
            }
            if (limit == null | skip == null)
            {
                limit = 10;
                skip = 0;
            }
            if (rut == null | rut == "")
            {
                _jsonObject = new ValidationProductsReqBodyModel
                {
                    Selector = new Models.Req.ProductReqModel
                    {
                        Or = new Models.Req.OrClass[]
                        {
                            new Models.Req.OrClass
                            {
                                Code = new Models.Req.CodeClass
                                {
                                    Regex = code
                                },
                                Name = new Models.Req.NameClass
                                {
                                    Regex = name
                                }
                            }
                        }
                    },
                    Fields = new string[] { "code","name","stock" },
                    Limit = limit,
                    Skip = skip
                };
            }
            else
            {
                _jsonObject = new ValidationProductsReqBodyModel
                {
                    Selector = new Models.Req.ProductReqModel
                    {
                        Or = new Models.Req.OrClass[]
                        {
                            new Models.Req.OrClass
                            {
                                Code = new Models.Req.CodeClass
                                {
                                    Regex = code
                                },
                                Name = new Models.Req.NameClass
                                {
                                    Regex = code
                                }
                            }
                        },
                        And = new Models.Req.AndClass[]
                        {
                            new Models.Req.AndClass
                            {
                                Rut = new Models.Req.RutClass
                                {
                                    Eq = rut
                                }
                            }
                        }
                    },
                    Fields = new string[] { "code", "name", "stock" },
                    Limit = limit,
                    Skip = skip
                };
            }
            dynamic json = JsonConvert.SerializeObject(_jsonObject);
            return json;
        }

        //public dynamic RequestProductsCodeBody(string code)
        //{
        //    if (code == null)
        //    {
        //        code = "";
        //    }

        //    dynamic json = JsonConvert.SerializeObject(jsonObject);
        //    return json;
        //}
    }
}
