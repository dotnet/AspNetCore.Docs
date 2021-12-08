// <snippet_CreateBuilder>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_CreateBuilder>
