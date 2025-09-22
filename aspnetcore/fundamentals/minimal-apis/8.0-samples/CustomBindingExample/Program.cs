
// <snippet_IBindableFromHttpContext>
using CustomBindingExample;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello, IBindableFromHttpContext example!");

app.MapGet("/custom-binding", (CustomBoundParameter param) =>
{
    return $"Value from custom binding: {param.Value}";
});

app.MapGet("/combined/{id}", (int id, CustomBoundParameter param) =>
{
    return $"ID: {id}, Custom Value: {param.Value}";
});
// </snippet_IBindableFromHttpContext>
// <snippet_validation>
app.MapGet("/validated", (ValidatedParameter param) =>
{
    if (string.IsNullOrEmpty(param.Value))
    {
        return Results.BadRequest("Value cannot be empty");
    }
    
    return Results.Ok($"Validated value: {param.Value}");
});
// </snippet_validation>

app.Run();