using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery();

var app = builder.Build();

app.MapGet("/", (HttpContext context, IAntiforgery antiforgery) =>
{
    var token = antiforgery.GetAndStoreTokens(context);
    var html = $"""
        <html><body>
           <form action="/todo" method="POST" enctype="multipart/form-data">
               <input name="{token.FormFieldName}" 
                                type="hidden" value="{token.RequestToken}" />
               <input type="text" name="name" />
               <input type="date" name="dueDate" />
               <input type="checkbox" name="isCompleted" />
               <input type="submit" />
           </form>
        </body></html>
    """;
    return Results.Content(html, "text/html");
});

app.MapPost("/todo", async Task<Results<Ok<Todo>, BadRequest<string>>> 
               ([FromForm] Todo todo, HttpContext context, IAntiforgery antiforgery) =>
{
    try
    {
        await antiforgery.ValidateRequestAsync(context);
        return TypedResults.Ok(todo);
    }
    catch (AntiforgeryValidationException e)
    {
        return TypedResults.BadRequest("Invalid anti-forgery token");
    }
});

app.Run();

class Todo
{
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public DateTime DueDate { get; set; } = DateTime.Now.Add(TimeSpan.FromDays(1));
}