
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
            {
                jwtOptions.Authority = "--your-authority--";
                jwtOptions.Audience = "--your-audience--";
            });

        //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
        //    {
        //        jwtOptions.MetadataAddress = builder.Configuration["Api:MetadataAddress"]!;
        //        jwtOptions.Authority = builder.Configuration["Api:Authority"];
        //        jwtOptions.Audience = builder.Configuration["Api:Audience"];
        //        jwtOptions.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidAudiences = builder.Configuration.GetSection("ApiValidAudiences").Get<string[]>(),
        //            ValidIssuers = builder.Configuration.GetSection("ApiValidIssuers").Get<string[]>()
        //        };
        //    });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers()
            .RequireAuthorization();

        app.Run();
    }
}
