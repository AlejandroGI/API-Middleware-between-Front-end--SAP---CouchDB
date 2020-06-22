namespace klp_api.Models.Req.Categories
{
    public class ValidationCategoriesProductCodeReqBodyModel
    {
        public CategoriesProductCodeReqBodyModel selector { get; set; }
        public int? limit { get; set; }
        public int? skip { get; set; }
    }
}
