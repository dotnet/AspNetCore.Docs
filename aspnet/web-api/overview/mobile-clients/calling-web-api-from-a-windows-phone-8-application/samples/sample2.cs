using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Web;

namespace BookStore.Models
{
    /// <summary>
    /// Define a class that will hold the detailed information for a book.
    /// </summary>
    public class BookDetails
    {
        [Required]
        public String Id { get; set; }
        [Required]
        public String Title { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public Decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public String Description { get; set; }
    }

    /// <summary>
    /// Define an interface which contains the methods for the book repository.
    /// </summary>
    public interface IBookRepository
    {
        BookDetails CreateBook(BookDetails book);
        IEnumerable<BookDetails> ReadAllBooks();
        BookDetails ReadBook(String id);
        BookDetails UpdateBook(String id, BookDetails book);
        Boolean DeleteBook(String id);
    }

    /// <summary>
    /// Define a class based on the book repository interface which contains the method implementations.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private string xmlFilename = null;
        private XDocument xmlDocument = null;

        /// <summary>
        /// Define the class constructor.
        /// </summary>
        public BookRepository()
        {
            try
            {
                // Determine the path to the books.xml file.
                xmlFilename = HttpContext.Current.Server.MapPath("~/app_data/books.xml");
                // Load the contents of the books.xml file into an XDocument object.
                xmlDocument = XDocument.Load(xmlFilename);
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        /// <summary>
        /// Method to add a new book to the catalog.
        /// Defines the implementation of the POST method.
        /// </summary>
        public BookDetails CreateBook(BookDetails book)
        {
            try
            {
                // Retrieve the book with the highest ID from the catalog.
                var highestBook = (
                    from bookNode in xmlDocument.Elements("catalog").Elements("book")
                    orderby bookNode.Attribute("id").Value descending
                    select bookNode).Take(1);
                // Extract the ID from the book data.
                string highestId = highestBook.Attributes("id").First().Value;
                // Create an ID for the new book.
                string newId = "bk" + (Convert.ToInt32(highestId.Substring(2)) + 1).ToString();
                // Verify that this book ID does not currently exist.
                if (this.ReadBook(newId) == null)
                {
                    // Retrieve the parent element for the book catalog.
                    XElement bookCatalogRoot = xmlDocument.Elements("catalog").Single();
                    // Create a new book element.
                    XElement newBook = new XElement("book", new XAttribute("id", newId));
                    // Create elements for each of the book's data items.
                    XElement[] bookInfo = FormatBookData(book);
                    // Add the element to the book element.
                    newBook.ReplaceNodes(bookInfo);
                    // Append the new book to the XML document.
                    bookCatalogRoot.Add(newBook);
                    // Save the XML document.
                    xmlDocument.Save(xmlFilename);
                    // Return an object for the newly-added book.
                    return this.ReadBook(newId);
                }
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
            // Return null to signify failure.
            return null;
        }

        /// <summary>
        /// Method to retrieve all of the books in the catalog.
        /// Defines the implementation of the non-specific GET method.
        /// </summary>
        public IEnumerable<BookDetails> ReadAllBooks()
        {
            try
            {
                // Return a list that contains the catalog of book ids/titles.
                return (
                    // Query the catalog of books.
                    from book in xmlDocument.Elements("catalog").Elements("book")
                    // Sort the catalog based on book IDs.
                    orderby book.Attribute("id").Value ascending
                    // Create a new instance of the detailed book information class.
                    select new BookDetails
                    {
                        // Populate the class with data from each of the book's elements.
                        Id = book.Attribute("id").Value,
                        Author = book.Element("author").Value,
                        Title = book.Element("title").Value,
                        Genre = book.Element("genre").Value,
                        Price = Convert.ToDecimal(book.Element("price").Value),
                        PublishDate = Convert.ToDateTime(book.Element("publish_date").Value),
                        Description = book.Element("description").Value
                    }).ToList();
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        /// <summary>
        /// Method to retrieve a specific book from the catalog.
        /// Defines the implementation of the ID-specific GET method.
        /// </summary>
        public BookDetails ReadBook(String id)
        {
            try
            {
                // Retrieve a specific book from the catalog.
                return (
                    // Query the catalog of books.
                    from book in xmlDocument.Elements("catalog").Elements("book")
                    // Specify the specific book ID to query.
                    where book.Attribute("id").Value.Equals(id)
                    // Create a new instance of the detailed book information class.
                    select new BookDetails
                    {
                        // Populate the class with data from each of the book's elements.
                        Id = book.Attribute("id").Value,
                        Author = book.Element("author").Value,
                        Title = book.Element("title").Value,
                        Genre = book.Element("genre").Value,
                        Price = Convert.ToDecimal(book.Element("price").Value),
                        PublishDate = Convert.ToDateTime(book.Element("publish_date").Value),
                        Description = book.Element("description").Value
                    }).Single();
            }
            catch
            {
                // Return null to signify failure.
                return null;
            }
        }

        /// <summary>
        /// Populates a book BookDetails class with the data for a book.
        /// </summary>
        private XElement[] FormatBookData(BookDetails book)
        {
            XElement[] bookInfo =
            {
                new XElement("author", book.Author),
                new XElement("title", book.Title),
                new XElement("genre", book.Genre),
                new XElement("price", book.Price.ToString()),
                new XElement("publish_date", book.PublishDate.ToString()),
                new XElement("description", book.Description)
            };
            return bookInfo;
        }

        /// <summary>
        /// Method to update an existing book in the catalog.
        /// Defines the implementation of the PUT method.
        /// </summary>
        public BookDetails UpdateBook(String id, BookDetails book)
        {
            try
            {
                // Retrieve a specific book from the catalog.
                XElement updateBook = xmlDocument.XPathSelectElement(String.Format("catalog/book[@id='{0}']", id));
                // Verify that the book exists.
                if (updateBook != null)
                {
                    // Create elements for each of the book's data items.
                    XElement[] bookInfo = FormatBookData(book);
                    // Add the element to the book element.
                    updateBook.ReplaceNodes(bookInfo);
                    // Save the XML document.
                    xmlDocument.Save(xmlFilename);
                    // Return an object for the updated book.
                    return this.ReadBook(id);
                }
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
            // Return null to signify failure.
            return null;
        }

        /// <summary>
        /// Method to remove an existing book from the catalog.
        /// Defines the implementation of the DELETE method.
        /// </summary>
        public Boolean DeleteBook(String id)
        {
            try
            {
                if (this.ReadBook(id) != null)
                {
                    // Remove the specific child node from the catalog.
                    xmlDocument
                        .Elements("catalog")
                        .Elements("book")
                        .Where(x => x.Attribute("id").Value.Equals(id))
                        .Remove();
                    // Save the XML document.
                    xmlDocument.Save(xmlFilename);
                    // Return a success status.
                    return true;
                }
                else
                {
                    // Return a failure status.
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }
    }
}