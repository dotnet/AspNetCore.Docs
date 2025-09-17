// <snippet_UsingModels>
using BookStoreApi.Models;
// </snippet_UsingModels>
// <snippet_UsingServices>
using BookStoreApi.Services;
// </snippet_UsingServices>
// <snippet_UsingJsonSerialization>
using System.Text.Json.Serialization;
// </snippet_UsingJsonSerialization>

// <snippet_AddControllers>
// <snippet_BooksService>
// <snippet_BookStoreDatabaseSettings>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));
// </snippet_BookStoreDatabaseSettings>

builder.Services.AddSingleton<BooksService>();
// </snippet_BooksService>

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.TypeInfoResolverChain.Insert(0, BookStoreJsonSerializerContext.Default);
    });
// </snippet_AddControllers>

builder.Services.AddOpenApi();

// <snippet_UseSwagger>
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}
// </snippet_UseSwagger>

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// <snippet_JsonSerializerContext>
[JsonSerializable(typeof(List<Book>))]
[JsonSerializable(typeof(Book))]
internal partial class BookStoreJsonSerializerContext : JsonSerializerContext
{
}
// </snippet_JsonSerializerContext>
