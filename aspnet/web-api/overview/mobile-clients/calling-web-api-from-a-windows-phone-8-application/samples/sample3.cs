using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BooksController : ApiController
    {
        private BookRepository repository = null;

        // Define the class constructor.
        public BooksController()
        {
            this.repository = new BookRepository();
        }

        /// <summary>
        /// Method to retrieve all of the books in the catalog.
        /// Example: GET api/books
        /// </summary>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            IEnumerable<BookDetails> books = this.repository.ReadAllBooks();
            if (books != null)
            {
                return Request.CreateResponse<IEnumerable<BookDetails>>(HttpStatusCode.OK, books);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Method to retrieve a specific book from the catalog.
        /// Example: GET api/books/5
        /// </summary>
        [HttpGet]
        public HttpResponseMessage Get(String id)
        {
            BookDetails book = this.repository.ReadBook(id);
            if (book != null)
            {
                return Request.CreateResponse<BookDetails>(HttpStatusCode.OK, book);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Method to add a new book to the catalog.
        /// Example: POST api/books
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Post(BookDetails book)
        {
            if ((this.ModelState.IsValid) && (book != null))
            {
                BookDetails newBook = this.repository.CreateBook(book);
                if (newBook != null)
                {
                    var httpResponse = Request.CreateResponse<BookDetails>(HttpStatusCode.Created, newBook);
                    string uri = Url.Link("DefaultApi", new { id = newBook.Id });
                    httpResponse.Headers.Location = new Uri(uri);
                    return httpResponse;
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Method to update an existing book in the catalog.
        /// Example: PUT api/books/5
        /// </summary>
        [HttpPut]
        public HttpResponseMessage Put(String id, BookDetails book)
        {
            if ((this.ModelState.IsValid) && (book != null) && (book.Id.Equals(id)))
            {
                BookDetails modifiedBook = this.repository.UpdateBook(id, book);
                if (modifiedBook != null)
                {
                    return Request.CreateResponse<BookDetails>(HttpStatusCode.OK, modifiedBook);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Method to remove an existing book from the catalog.
        /// Example: DELETE api/books/5
        /// </summary>
        [HttpDelete]
        public HttpResponseMessage Delete(String id)
        {
            BookDetails book = this.repository.ReadBook(id);
            if (book != null)
            {
                if (this.repository.DeleteBook(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}