
#if DataAccess
#region snippet_1
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace BookMongo.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("BookstoreDb");
        }
        public IEnumerable<Book> GetBooks()
        {
            return _db.GetCollection<Book>("Books").FindAll();
        }

        public Book GetBook(ObjectId id)
        {
            var res = Query<Book>.EQ(p => p.Id, id);
            return _db.GetCollection<Book>("Books").FindOne(res);
        }
        public Book Create(Book p)
        {
            _db.GetCollection<Book>("Books").Save(p);
            return p;
        }
        public void Update(ObjectId id, Book p)
        {
            p.Id = id;
            var res = Query<Book>.EQ(pd => pd.Id, id);
            var operation = Update<Book>.Replace(p);
            _db.GetCollection<Book>("Books").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<Book>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Book>("Books").Remove(res);
        }
    }
}

#endregion
#endif
