using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
// <snippet_NewtonsoftJsonImport>
using Newtonsoft.Json;
// </snippet_NewtonsoftJsonImport>

namespace BooksApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // <snippet_BookNameProperty>
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }
        // </snippet_BookNameProperty>

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
