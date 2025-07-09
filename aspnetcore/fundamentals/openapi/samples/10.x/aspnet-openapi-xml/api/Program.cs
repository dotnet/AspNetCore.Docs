using Api;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Map("/", () => Results.Redirect("/scalar/v1"));
app.MapProjectBoardApis();
app.MapTodoApis();

app.Run();
