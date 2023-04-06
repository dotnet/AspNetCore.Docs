using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    o.AddPolicy("AuthenticatedUsers", b => b.RequireAuthenticatedUser());
    o.AddPolicy("AdminsOnly", b => b.RequireRole("admin"));
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

var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtAuthOpts.SymmetricSecurityKey));
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
var tokenDescriptor = new SecurityTokenDescriptor {
    Issuer = jwtAuthOpts.ValidIssuer,
    Audience = jwtAuthOpts.ValidAudience,
    SigningCredentials = credentials
};

app.MapGet("/token", (HttpContext context) => {
    var username = context.Request.Headers["username"].ToString();
    var password = context.Request.Headers["password"].ToString();

    var claimsIdentity = new ClaimsIdentity(new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    });
    
    if(username.Equals("admin") && password.Equals("admin"))
    {
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
    }

    tokenDescriptor.Subject = claimsIdentity;
    tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(jwtAuthOpts.TokenExpirationInMinutes);
    
    var jwtTokenHandler = new JwtSecurityTokenHandler();
    
    return Results.Ok(new {
        access_token = jwtTokenHandler.WriteToken(jwtTokenHandler.CreateToken(tokenDescriptor))
    });
}).AllowAnonymous();

string GetOrCreateFilePath(string fileName, string filesDirectory = "PrivateFiles")
{
    var directoryPath = Path.Combine(app.Environment.ContentRootPath, filesDirectory);

    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }

    return Path.Combine(app.Environment.ContentRootPath, directoryPath, fileName);
}

async Task SaveFileWithCustomFileName(IFormFile file, string fileSaveName)
{
    var filePath = GetOrCreateFilePath(fileSaveName);
    await using var fileStream = new FileStream(filePath, FileMode.Create);
    await file.CopyToAsync(fileStream);
}
// <snippet_1>
app.MapGet("/files/{fileName}",  IResult (string fileName) => 
    {
        var filePath = GetOrCreateFilePath(fileName);

        if (File.Exists(filePath))
        {
            return TypedResults.PhysicalFile(filePath, fileDownloadName: $"{fileName}");
        }

        return TypedResults.NotFound("No file found with the supplied file name");
    })
    .WithName("GetFileByName")
    .RequireAuthorization("AuthenticatedUsers");

// IFormFile uses memory buffer for uploading. For handling large file use streaming instead.
// https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads#upload-large-files-with-streaming
app.MapPost("/files", async (IFormFile file, LinkGenerator linker, HttpContext context) =>
    {
        // Don't rely on the file.FileName as it is only metadata that can be manipulated by the end-user
        // Take a look at the `Utilities.IsFileValid` method that takes an IFormFile and validates its signature within the AllowedFileSignatures
        
        var fileSaveName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        await SaveFileWithCustomFileName(file, fileSaveName);
        
        context.Response.Headers.Append("Location", linker.GetPathByName(context, "GetFileByName", new { fileName = fileSaveName}));
        return TypedResults.Ok("File Uploaded Successfully!");
    })
    .RequireAuthorization("AdminsOnly");

app.Run();
// </snippet_1>
