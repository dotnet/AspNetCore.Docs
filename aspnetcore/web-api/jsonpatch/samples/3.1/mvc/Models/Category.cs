using Newtonsoft.Json;

namespace JsonPatchSample.Models
{
    [JsonConverter(typeof(ProductCategoryConverter))]
    public class Category
    {
        public string CategoryName { get; set; }
    }
}
