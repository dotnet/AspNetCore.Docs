public IQueryable<Book> GetBooks()
{
    return db.Books;
}