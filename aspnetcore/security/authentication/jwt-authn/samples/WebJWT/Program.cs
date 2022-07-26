using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// reqires Microsoft.AspNetCore.Authentication.JwtBearer NuGet package.
builder.Services.AddAuthentication("Bearer");
builder.Authentication.AddJwtBearer();

var app = builder.Build();

app.MapGet("/", () => "Hello, World!");
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. This is a secret!")
    .RequireAuthorization();

app.Run();
