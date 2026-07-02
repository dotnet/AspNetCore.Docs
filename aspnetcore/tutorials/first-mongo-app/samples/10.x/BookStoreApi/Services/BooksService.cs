// <snippet_File>
using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

// <snippet_ctor>
public class BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
{
    private readonly IMongoCollection<Book> _booksCollection = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString)
        .GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName)
        .GetCollection<Book>(bookStoreDatabaseSettings.Value.BooksCollectionName);
// </snippet_ctor>

    public async Task<List<Book>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<Book?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Book newBook) =>
        await _booksCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Book updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}
// </snippet_File>
