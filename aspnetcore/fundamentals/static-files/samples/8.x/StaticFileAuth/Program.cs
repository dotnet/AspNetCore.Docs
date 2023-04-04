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

string GetOrCreateFilePath(string nestedFilesDirectory, string fileName, string rootFilesDirectory = "PrivateFiles")
{
    var rootFilesDirectoryPath = Path.Combine(app.Environment.ContentRootPath, rootFilesDirectory);
    
    if (!Directory.Exists(rootFilesDirectoryPath))
        Directory.CreateDirectory(rootFilesDirectoryPath);
    
    var nestedFilesDirectoryPath = Path.Combine(app.Environment.ContentRootPath, rootFilesDirectory, nestedFilesDirectory);
    
    if (!Directory.Exists(nestedFilesDirectoryPath))
        Directory.CreateDirectory(nestedFilesDirectoryPath);

    return Path.Combine(app.Environment.ContentRootPath, rootFilesDirectory, nestedFilesDirectory, fileName);
}

app.MapGet("/files/{filename}", (string fileName, HttpContext context) =>
    {
        if (context.User.Claims.Any(u => u.Subject.HasClaim("isAdmin", "true")))
        {
            var filePath = GetOrCreateFilePath("Admin", fileName);

            if (File.Exists(filePath))
                return TypedResults.PhysicalFile(filePath, fileDownloadName: $"{fileName}");

            return TypedResults.NotFound("No file found with the supplied file name");
        }
        else
        {
            var alias = context.User.FindFirstValue("alias");

            if (string.IsNullOrEmpty(alias))
                return Results.Unauthorized();

            var filePath = GetOrCreateFilePath(alias, fileName);

            if (File.Exists(filePath))
                return TypedResults.PhysicalFile(filePath, fileDownloadName: $"{fileName}");

            return TypedResults.NotFound("No file found with the supplied file name");
        }
    })
    .WithName("GetFileByName")
    .RequireAuthorization("PrivateFiles");

app.MapPost("/files", async (IFormFile file, LinkGenerator linker, HttpContext context) =>
    {
        if (!Utilities.IsFileValid(file))
            return Results.ValidationProblem(new Dictionary<string, string[]>
            {
                {
                    "invalid.extensions", new[]
                    {
                        $"Only allowed file types are [{string.Join(", ", Utilities.AllowedFileSignatures.Keys)}]"
                    }
                }
            });

        var fileSaveName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        
        if (context.User.Claims.Any(u => u.Subject.HasClaim("isAdmin", "true")))
        {
            var filePath =
                GetOrCreateFilePath("Admin", fileSaveName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);

            context.Response.Headers.Add("Location",
                linker.GetPathByName(context, "GetFileByName", new {fileName = fileSaveName}));
            
            return TypedResults.Ok("File Uploaded Successfully!");
        }
        else
        {
            var alias = context.User.FindFirstValue("alias");

            if (string.IsNullOrEmpty(alias))
                return Results.Unauthorized();

            var filePath =
                GetOrCreateFilePath(alias, fileSaveName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);

            context.Response.Headers.Add("Location",
                linker.GetPathByName(context, "GetFileByName", new {fileName = fileSaveName}));
            
            return TypedResults.Ok("File Uploaded Successfully!");
        }
    })
    .RequireAuthorization("PrivateFiles");

app.Run();

