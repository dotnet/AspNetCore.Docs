#define AFTER // FIRST JWT1 JWT2 AFTER
#if NEVER
#elif FIRST
// <snippet_1>
var builder = WebApplication.CreateBuilder(args);
// Requires Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
// </snippet_1>
#elif JWT1
// <snippet_jwt1>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddJwtBearer();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
// </snippet_jwt1>
#elif JWT2
// <snippet_jwt2>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
// </snippet_jwt2>
#elif AFTER
// <snippet_after>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");
app.Run();
// </snippet_after>
#endif
