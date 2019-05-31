using BooksApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BooksApi.Data
{
    public class BookstoreContext
    {
        public BookstoreContext(IOptions<BookstoreDatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var database = client.GetDatabase(options.Value.DatabaseName);

            Books = database.GetCollection<Book>(options.Value.BooksCollectionName);
        }

        public IMongoCollection<Book> Books { get; }
    }
}
