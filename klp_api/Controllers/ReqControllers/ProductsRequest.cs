using klp_api.Models.Req.Products;
using Newtonsoft.Json;

namespace klp_api.Controllers.CouchDBControllers
{
    public class ProductsRequest
    {
        private ValidationProductsReqBodyModel _jsonObject;
        private ValidationProductsCodeReqBodyModel _jsonObjectCode;

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
                    Fields = new string[] { "code", "name", "stock" },
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
            dynamic json = JsonConvert.SerializeObject(_jsonObject, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return json;
        }

        public dynamic RequestProductsCodeBody(string code, string rut)
        {
            if (code == null)
            {
                code = "";
            }
            if (rut == null | rut == "")
            {
                _jsonObjectCode = new ValidationProductsCodeReqBodyModel
                {
                    Selector = new Models.Req.ProductsCodeModel
                    {
                        Code = new Models.Req.Code
                        {
                            Eq = code
                        },
                    }
                };
            }
            else
            {
                _jsonObjectCode = new ValidationProductsCodeReqBodyModel
                {
                    Selector = new Models.Req.ProductsCodeModel
                    {
                        Code = new Models.Req.Code
                        {
                            Eq = code
                        },
                        Rut = new Models.Req.Rut
                        {
                            Eq = rut
                        }
                    }
                };

            }
            dynamic json = JsonConvert.SerializeObject(_jsonObjectCode, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return json;
        }
    }
}
