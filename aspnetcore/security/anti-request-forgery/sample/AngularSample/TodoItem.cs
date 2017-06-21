using Newtonsoft.Json;

namespace AngularSample
{
    public class TodoItem
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
