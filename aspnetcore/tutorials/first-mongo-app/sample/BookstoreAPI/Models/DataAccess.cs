
#if DataAccess
#region snippet_1
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMongo.Models
{
    public class DataAccess
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("BookstoreDb");
        }

        public IEnumerable<Book> GetBooks()
        {
            return _db.GetCollection<Book>("Books").Find(m => true).ToList();
        }


        public Book GetBook(ObjectId id)
        {
            return _db.GetCollection<Book>("Books").Find<Book>(m => m.Id == id).FirstOrDefault();
        }

        public Book Create(Book p)
        {
            _db.GetCollection<Book>("Books").InsertOne(p);
            return p;
        }

        public void Update(ObjectId id, Book p)
        {
            _db.GetCollection<Book>("Books").ReplaceOne(m => m.Id == id, p);
        }

        public void Remove(ObjectId id)
        {
            var operation = _db.GetCollection<Book>("Books").DeleteOne(m => m.Id == id);
        }
    }
}



#endregion
#endif
