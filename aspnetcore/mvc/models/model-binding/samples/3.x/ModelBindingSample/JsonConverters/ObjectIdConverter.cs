using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ModelBindingSample.Models;

namespace ModelBindingSample.Converters
{
    #region snippet_Class
    internal class ObjectIdConverter : JsonConverter<ObjectId>
    {
        public override ObjectId Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new ObjectId(JsonSerializer.Deserialize<int>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Id);
        }
    }
    #endregion
}
