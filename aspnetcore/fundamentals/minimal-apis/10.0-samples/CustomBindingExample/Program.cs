
// <snippet_IBindableFromHttpContext>
using CustomBindingExample;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

// Basic endpoint to test the application
app.MapGet("/", () => "Hello, IBindableFromHttpContext example!");

// Endpoint using the CustomBoundParameter
app.MapGet("/custom-binding", (CustomBoundParameter param) =>
{
    return $"Value from custom binding: {param.Value}";
});

// Endpoint showing how to combine with other parameters
app.MapGet("/combined/{id}", (int id, CustomBoundParameter param) =>
{
    return $"ID: {id}, Custom Value: {param.Value}";
});

// Endpoint showing validation example
app.MapGet("/validated", (ValidatedParameter param) =>
{
    if (string.IsNullOrEmpty(param.Value))
    {
        return Results.BadRequest("Value cannot be empty");
    }
    
    return Results.Ok($"Validated value: {param.Value}");
});
// <//snippet_IBindableFromHttpContext>

app.Run();