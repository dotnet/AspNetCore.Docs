[Route("api/books/date/{pubdate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
public IQueryable<BookDto> GetBooks(DateTime pubdate)
{
    // ...
}