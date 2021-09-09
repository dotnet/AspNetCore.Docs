//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEFConfiguration(
    opt => opt.UseInMemoryDatabase("InMemoryDb"));

var app = builder.Build();

app.Run();
