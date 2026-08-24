using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ticketer.Services;
using Ticketer;

JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();
// WARNING: This ephemeral key is regenerated on every app restart, which invalidates all previously issued tokens.
// In production, load a stable key from secure configuration (e.g. Azure Key Vault, environment variable, or appsettings.json).
SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());

string GenerateJwtToken(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        throw new InvalidOperationException("Name is not specified.");
    }

    var claims = new[] { new Claim(ClaimTypes.Name, name) };
    var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken("ExampleServer", "ExampleClients", claims, expires: DateTime.Now.AddSeconds(60), signingCredentials: credentials);
    return JwtTokenHandler.WriteToken(token);
}

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<TicketRepository>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireClaim(ClaimTypes.Name);
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                // WARNING: The following three validations are disabled only because this sample self-issues tokens
                // using a hardcoded issuer ("ExampleServer"), audience ("ExampleClients"), and an ephemeral in-memory signing key.
                // In a real application you MUST enable these and configure ValidIssuer, ValidAudience, and a stable IssuerSigningKey.
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateLifetime = true,
                IssuerSigningKey = SecurityKey
            };
});

var app = builder.Build();

IWebHostEnvironment env = app.Environment;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
app.MapGrpcService<TicketerService>();

app.MapGet("/generateJwtToken", context =>
{
    return context.Response.WriteAsync(GenerateJwtToken(context.Request.Query["name"]));
});


app.Run();


