[Route("{genre}")]
public IQueryable<BookDto> GetBooksByGenre(string genre)
{
    return db.Books.Include(b => b.Author)
        .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
        .Select(AsBookDto);
}