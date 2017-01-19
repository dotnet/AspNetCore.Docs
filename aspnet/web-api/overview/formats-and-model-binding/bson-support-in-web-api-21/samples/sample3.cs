public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public DateTime PublicationDate { get; set; }
}

public class BooksController : ApiController
{
    public IHttpActionResult GetBook(int id)
    {
        var book = new Book()
        {
            Id = id,
            Author = "Charles Dickens",
            Title = "Great Expectations",
            Price = 9.95M,
            PublicationDate = new DateTime(2014, 1, 20)
        };

        return Ok(book);
    }
}