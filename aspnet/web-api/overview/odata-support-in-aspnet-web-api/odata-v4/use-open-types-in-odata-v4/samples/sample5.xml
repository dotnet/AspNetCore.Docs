using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace MyApp.Controllers
{
    public class BooksController : ODataController
    {
        private IList<Book> _books = new List<Book>
        {
            new Book
            {
                ISBN = "978-0-7356-8383-9",
                Title = "SignalR Programming in Microsoft ASP.NET",
                Press = new Press
                {
                    Name = "Microsoft Press",
                    Category = Category.Book
                }
            },

            new Book
            {
                ISBN = "978-0-7356-7942-9",
                Title = "Microsoft Azure SQL Database Step by Step",
                Press = new Press
                {
                    Name = "Microsoft Press",
                    Category = Category.EBook,
                    DynamicProperties = new Dictionary<string, object>
                    {
                        { "Blog", "http://blogs.msdn.com/b/microsoft_press/" },
                        { "Address", new Address { 
                              City = "Redmond", Street = "One Microsoft Way" }
                        }
                    }
                },
                Properties = new Dictionary<string, object>
                {
                    { "Published", new DateTimeOffset(2014, 7, 3, 0, 0, 0, 0, new TimeSpan(0))},
                    { "Authors", new [] { "Leonard G. Lobel", "Eric D. Boyd" }},
                    { "OtherCategories", new [] {Category.Book, Category.Magazine}}
                }
            }
        };

        [EnableQuery]
        public IQueryable<Book> Get()
        {
            return _books.AsQueryable();
        }

        public IHttpActionResult Get([FromODataUri]string key)
        {
            Book book = _books.FirstOrDefault(e => e.ISBN == key);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        public IHttpActionResult Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            // For this sample, we aren't enforcing unique keys.
            _books.Add(book);
            return Created(book);
        }
    }
}