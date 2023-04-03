using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StaticFilesAuth;

var securityScheme = new OpenApiSecurityScheme() {
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        Array.Empty<string>()
    }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => {
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});

var jwtAuthOpts = new JwtAuthenticationOptions();
builder.Configuration.GetSection(JwtAuthenticationOptions.Options).Bind(jwtAuthOpts);

builder.Services.AddAuthentication(o => {
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters {
        ValidIssuer = jwtAuthOpts.ValidIssuer,
        ValidAudience = jwtAuthOpts.ValidAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtAuthOpts.SymmetricSecurityKey)),
        ValidateIssuer = jwtAuthOpts.ValidateIssuer,
        ValidateAudience = jwtAuthOpts.ValidateAudience,
        ValidateLifetime = jwtAuthOpts.ValidateLifetime,
        ValidateIssuerSigningKey = jwtAuthOpts.ValidateIssuerSigningKey
    };
});

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("PrivateFiles", b => b.RequireAuthenticatedUser());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseFileServer();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "PrivateFiles")),
    RequestPath = "/files"
});

var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtAuthOpts.SymmetricSecurityKey));
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
var tokenDescriptor = new SecurityTokenDescriptor {
    Issuer = jwtAuthOpts.ValidIssuer,
    Audience = jwtAuthOpts.ValidAudience,
    SigningCredentials = credentials,
    Expires = DateTime.UtcNow.AddMinutes(jwtAuthOpts.TokenExpirationInMinutes)
};

app.MapGet("/token", (HttpContext context) => {
    var username = context.Request.Headers["username"].ToString();
    var password = context.Request.Headers["password"].ToString();

    
    switch (username)
    {
        case "admin" when password.Equals("admin"):
            tokenDescriptor.Subject = new ClaimsIdentity(new[]
            {
                new Claim("isAdmin", "true")
            });
            break;
        case "user" when password.Equals("user"):
            tokenDescriptor.Subject = new ClaimsIdentity(new[]
            {
                new Claim("alias", username)
            });
            break;
        default:
            return Results.Unauthorized();
    }

    var jwtTokenHandler = new JwtSecurityTokenHandler();
    
    return Results.Ok(new {
        access_token = jwtTokenHandler.WriteToken(jwtTokenHandler.CreateToken(tokenDescriptor))
    });
}).AllowAnonymous();


app.MapGet("/files/{filename}", async (string fileName, HttpContext context) =>
{
    if (context.User.Claims.Any(u => u.Subject.HasClaim("isAdmin", "true")))
    {
        var filePath = Path.Combine(app.Environment.ContentRootPath, "PrivateFiles", "Admin", fileName); 
        
        if (File.Exists(filePath))
            return TypedResults.File(await File.ReadAllBytesAsync(filePath), fileDownloadName: $"{fileName}");
        return TypedResults.NotFound("No file found with the supplied file name");
    }
    else
    {
        var alias = context.User.FindFirstValue("alias");

        if (string.IsNullOrEmpty(alias))
            return Results.Unauthorized();

        var filePath = Path.Combine(app.Environment.ContentRootPath, "PrivateFiles", alias, fileName);

        if (File.Exists(filePath))
            return TypedResults.File(await File.ReadAllBytesAsync(filePath), fileDownloadName: $"{fileName}");
        return TypedResults.NotFound("No file found with the supplied file name");
    }
}).RequireAuthorization("PrivateFiles");

app.MapPost("/files", async (IFormFile file, HttpContext context) =>
    {
        if (context.User.Claims.Any(u => u.Subject.HasClaim("isAdmin", "true")))
        {
            var filePath = Path.Combine(app.Environment.ContentRootPath, "PrivateFiles", "Admin",
                Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName));

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return TypedResults.Ok("File Uploaded Successfully!");
        }
        else
        {
            var alias = context.User.FindFirstValue("alias");

            if (string.IsNullOrEmpty(alias))
                return Results.Unauthorized();

            var directoryPath = Path.Combine(app.Environment.ContentRootPath, "PrivateFiles", alias);
            var filePath = Path.Combine(app.Environment.ContentRootPath, "PrivateFiles", alias,
                Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName));

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return TypedResults.Ok("File Uploaded Successfully!");
        }
    })
    .RequireAuthorization("PrivateFiles")
    .AddEndpointFilter(async (efiContext, next) =>
    {
        var file = efiContext.GetArgument<IFormFile>(0);

        var fileSignatures =
            new Dictionary<string, List<byte[]>>
            {
                {
                    ".jpeg", new List<byte[]>
                    {
                        new byte[] {0xFF, 0xD8, 0xFF, 0xE0},
                        new byte[] {0xFF, 0xD8, 0xFF, 0xE2},
                        new byte[] {0xFF, 0xD8, 0xFF, 0xE3}
                    }
                },
                {
                    ".png", new List<byte[]>
                    {
                        new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}
                    }
                }
            };

        using var reader = new BinaryReader(file.OpenReadStream());

        var signatures = fileSignatures
            .Values
            .SelectMany(x => x)
            .ToList();
        
        var headerBytes = reader.ReadBytes(fileSignatures
            .Max(m => m.Value.Max(n => n.Length)));

        var isValidSignature = signatures
            .Any(signature => headerBytes
                .Take(signature.Length)
                .SequenceEqual(signature));

        if (!isValidSignature)
        {
            return Results.ValidationProblem(new Dictionary<string, string[]>
            {
                {
                    "invalid.extensions", new[]
                    {
                        "only allowed file types are [jpeg, png]"
                    }
                }
            });
        }

        return await next(efiContext);
    });

app.Run();