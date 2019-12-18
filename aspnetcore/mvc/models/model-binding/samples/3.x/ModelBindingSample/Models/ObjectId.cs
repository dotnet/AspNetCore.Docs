using System.Text.Json.Serialization;
using ModelBindingSample.Converters;

namespace ModelBindingSample.Models
{
    [JsonConverter(typeof(ObjectIdConverter))]
    public struct ObjectId
    {
        public ObjectId(int id) =>
            Id = id;

        public int Id { get; }
    }
}
