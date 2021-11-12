using System.Text.Json.Serialization;
using ModelBindingSample.Converters;

namespace ModelBindingSample.Models
{
    // <snippet_Class>
    [JsonConverter(typeof(ObjectIdConverter))]
    public struct ObjectId
    {
        public ObjectId(int id) =>
            Id = id;

        public int Id { get; }
    }
    // </snippet_Class>
}
