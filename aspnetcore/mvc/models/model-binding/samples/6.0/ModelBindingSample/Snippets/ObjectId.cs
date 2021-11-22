using System.Text.Json.Serialization;

namespace ModelBindingSample.Snippets;

// <snippet_Type>
[JsonConverter(typeof(ObjectIdConverter))]
public record ObjectId(int Id);
// </snippet_Type>
