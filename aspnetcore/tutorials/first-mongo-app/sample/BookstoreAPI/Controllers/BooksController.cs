using System.Collections.Generic;
using BookMongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BookMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataAccess objds;

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
        public ActionResult<Book> Get(string id)
        {
            var book = objds.GetBook(new ObjectId(id));

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Post(Book p)
        {
            objds.Create(p);

            return p;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Book p)
        {
            var recId = new ObjectId(id);
            var book = objds.GetBook(recId);

            if (book == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = objds.GetBook(new ObjectId(id));

            if (book == null)
            {
                return NotFound();
            }

            objds.Remove(book.Id);

            return Ok();
        }
    }
}
