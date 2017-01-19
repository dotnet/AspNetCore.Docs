[Route("{id:int}/details")]
[ResponseType(typeof(BookDetailDto))]
public async Task<IHttpActionResult> GetBookDetail(int id)
{
    var book = await (from b in db.Books.Include(b => b.Author)
                where b.AuthorId == id
                select new BookDetailDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    PublishDate = b.PublishDate,
                    Price = b.Price,
                    Description = b.Description,
                    Author = b.Author.Name
                }).FirstOrDefaultAsync();

    if (book == null)
    {
        return NotFound();
    }
    return Ok(book);
}