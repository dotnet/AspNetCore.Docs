// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    // <snippet_BookName>
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string BookName { get; set; } = null!;
    // </snippet_BookName>

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
}
