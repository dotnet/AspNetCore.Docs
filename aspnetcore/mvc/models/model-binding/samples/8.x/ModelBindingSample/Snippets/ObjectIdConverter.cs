using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModelBindingSample.Snippets;

// <snippet_Class>
internal class ObjectIdConverter : JsonConverter<ObjectId>
{
    public override ObjectId Read(
        ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => new(JsonSerializer.Deserialize<int>(ref reader, options));

    public override void Write(
        Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options)
        => writer.WriteNumberValue(value.Id);
}
// </snippet_Class>
