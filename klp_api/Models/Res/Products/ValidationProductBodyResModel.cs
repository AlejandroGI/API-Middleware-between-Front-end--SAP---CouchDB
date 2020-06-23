namespace klp_api.Models.Res
{
    public class ValidationProductsBodyResModel
    {
        public string rut { get; set; }
        public Docs[] products { get; set; }
        public string origin { get; set; }
    }
}
