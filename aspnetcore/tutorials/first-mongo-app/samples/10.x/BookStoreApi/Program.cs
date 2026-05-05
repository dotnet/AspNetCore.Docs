// <snippet_UsingModels>
using BookStoreApi.Models;
// </snippet_UsingModels>
// <snippet_UsingServices>
using BookStoreApi.Services;
// </snippet_UsingServices>

// <snippet_JsonOptions>
// <snippet_BooksService>
// <snippet_BookStoreDatabaseSettings>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));
// </snippet_BookStoreDatabaseSettings>

builder.Services.AddSingleton<BooksService>();
// </snippet_BooksService>

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});
// </snippet_JsonOptions>

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// <snippet_UseSwagger>
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}
// </snippet_UseSwagger>

// <snippet_MapEndpoints>
var booksGroup = app.MapGroup("/books");

booksGroup.MapGet("/", async (BooksService booksService) =>
{
    var books = await booksService.GetAsync();
    return Results.Ok(books);
});

booksGroup.MapGet("/{id:length(24)}", async (string id, BooksService booksService) =>
{
    var book = await booksService.GetAsync(id);

    return book is null ? Results.NotFound() : Results.Ok(book);
});

booksGroup.MapPost("/", async (Book newBook, BooksService booksService) =>
{
    await booksService.CreateAsync(newBook);

    return Results.Created($"/books/{newBook.Id}", newBook);
});

booksGroup.MapPut("/{id:length(24)}", async (string id, Book updatedBook, BooksService booksService) =>
{
    var book = await booksService.GetAsync(id);

    if (book is null)
    {
        return Results.NotFound();
    }

    updatedBook.Id = book.Id;

    await booksService.UpdateAsync(id, updatedBook);

    return Results.NoContent();
});

booksGroup.MapDelete("/{id:length(24)}", async (string id, BooksService booksService) =>
{
    var book = await booksService.GetAsync(id);

    if (book is null)
    {
        return Results.NotFound();
    }

    await booksService.RemoveAsync(id);

    return Results.NoContent();
});
// </snippet_MapEndpoints>

app.Run();
