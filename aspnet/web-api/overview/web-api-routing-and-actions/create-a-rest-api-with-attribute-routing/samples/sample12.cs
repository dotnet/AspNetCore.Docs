[Route("")]
public IQueryable<BookDto> GetBooks()
{
    // ...
}

[Route("{id:int}")]
[ResponseType(typeof(BookDto))]
public async Task<IHttpActionResult> GetBook(int id)
{
    // ...
}