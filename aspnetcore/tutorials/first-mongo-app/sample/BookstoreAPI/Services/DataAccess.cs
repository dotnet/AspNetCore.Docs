#region snippet_DataAccessClass
using System.Collections.Generic;
using System.Linq;
using BookMongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookMongo.Services
{
    public class BookService
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;

        #region snippet_DataAccessConstructor
        public BookService()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("BookstoreDb");
        }
        #endregion

        public IEnumerable<Book> GetBooks()
        {
            return _db.GetCollection<Book>("Books").Find(m => true).ToList();
        }

        public Book GetBook(ObjectId id)
        {
            return _db.GetCollection<Book>("Books")
                      .Find<Book>(m => m.Id == id)
                      .FirstOrDefault();
        }

        public Book Create(Book book)
        {
            _db.GetCollection<Book>("Books").InsertOne(book);
            return book;
        }

        public void Update(ObjectId id, Book book)
        {
            _db.GetCollection<Book>("Books").ReplaceOne(m => m.Id == id, book);
        }

        public void Remove(ObjectId id)
        {
            var operation = _db.GetCollection<Book>("Books")
                               .DeleteOne(m => m.Id == id);
        }
    }
}
#endregion
