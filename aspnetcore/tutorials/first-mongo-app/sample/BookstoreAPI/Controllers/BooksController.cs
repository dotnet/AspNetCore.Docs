using System.Collections.Generic;
using BookMongo.Models;
using BookMongo.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BookMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookService.GetBook(new ObjectId(id));

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Post(Book book)
        {
            _bookService.Create(book);

            return book;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Book p)
        {
            var recId = new ObjectId(id);
            var book = _bookService.GetBook(recId);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(recId, p);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.GetBook(new ObjectId(id));

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return Ok();
        }
    }
}
