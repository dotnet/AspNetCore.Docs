[Route("date/{pubdate:datetime}")]
public IQueryable<BookDto> GetBooks(DateTime pubdate)
{
    return db.Books.Include(b => b.Author)
        .Where(b => DbFunctions.TruncateTime(b.PublishDate)
            == DbFunctions.TruncateTime(pubdate))
        .Select(AsBookDto);
}