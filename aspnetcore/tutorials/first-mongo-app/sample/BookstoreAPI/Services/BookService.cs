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

        public List<Book> GetBooks()
        {
            return _books.Find(m => true).ToList();
        }

        public Book GetBook(ObjectId id)
        {
            return _books.Find<Book>(m => m.Id == id).FirstOrDefault();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(ObjectId id, Book book)
        {
            _books.ReplaceOne(m => m.Id == id, book);
        }

        public void Remove(ObjectId id)
        {
            _books.DeleteOne(m => m.Id == id);
        }
    }
}
#endregion
