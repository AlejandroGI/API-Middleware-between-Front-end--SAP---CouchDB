namespace klp_api.Models.Res.Categories
{
    public class CategoriesResBodyModel
    {
        public rowsClass[] rows { get; set; }
    }
    public class rowsClass
    {
        public keyClass key { get; set; }
        public int value { get; set; }
    }
    public class keyClass
    {
        public int code { get; set; }
        public string name { get; set; }

    }
}
