#if BooksController
#region snippet_1
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

using MongoDB.Bson;

namespace BookMongo.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        DataAccess objds;
        public BooksController()
        {
            objds = new DataAccess();
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return objds.GetBooks();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var Book = objds.GetBook(new ObjectId(id));
            if (Book == null)
            {
                return NotFound();
            }
            return new ObjectResult(Book);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Book p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Book p)
        {
            var recId = new ObjectId(id);
            var Book = objds.GetBook(recId);
            if (Book == null)
            {
                return NotFound();
            }
            objds.Update(recId, p);
            return new OkResult();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Book = objds.GetBook(new ObjectId(id));
            if (Book == null)
            {
                return NotFound();
            }
            objds.Remove(Book.Id);
            return new OkResult();
        }
    }
}

#endregion
#endif
