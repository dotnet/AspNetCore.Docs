
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(jwtOptions =>
            {
                jwtOptions.Authority = "https://{--your-authority--}";
                jwtOptions.Audience = "https://{--your-audience--}";
            });

        builder.Services.AddAuthentication()
            .AddJwtBearer("some-scheme", jwtOptions =>
            {
                jwtOptions.MetadataAddress = builder.Configuration["Api:MetadataAddress"]!;
                jwtOptions.Authority = builder.Configuration["Api:Authority"];
                jwtOptions.Audience = builder.Configuration["Api:Audience"];
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudiences = builder.Configuration.GetSection("Api:ValidAudiences").Get<string[]>(),
                    ValidIssuers = builder.Configuration.GetSection("Api:ValidIssuers").Get<string[]>()
                };

                jwtOptions.MapInboundClaims = false;
                jwtOptions.TokenValidationParameters.ValidTypes = ["at+jwt"];
            });

        var requireAuthPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();

        builder.Services.AddAuthorizationBuilder()
            .SetFallbackPolicy(requireAuthPolicy);

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
