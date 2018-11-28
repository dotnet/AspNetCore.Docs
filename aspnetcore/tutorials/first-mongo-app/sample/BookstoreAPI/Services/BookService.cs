#region snippet_BookServiceClass
using System.Collections.Generic;
using System.Linq;
using BookMongo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookMongo.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        #region snippet_BookServiceConstructor
        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _books = database.GetCollection<Book>("Books");
        }
        #endregion

        public List<Book> Get()
        {
            return _books.Find(book => true).ToList();
        }

        public Book Get(string id)
        {
            var docId = new ObjectId(id);

            return _books.Find<Book>(book => book.Id == docId).FirstOrDefault();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn)
        {
            var docId = new ObjectId(id);

            _books.ReplaceOne(book => book.Id == docId, bookIn);
        }

        public void Remove(Book bookIn)
        {
            _books.DeleteOne(book => book.Id == bookIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}
#endregion
