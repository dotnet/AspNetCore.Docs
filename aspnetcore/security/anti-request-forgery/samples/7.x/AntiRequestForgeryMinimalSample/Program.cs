using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

#region snippet_AntiforgeryEndpoint
app.MapPost("api/upload", (IFormFile name) => Results.Accepted())
    .RequireAuthorization()
    .ValidateAntifogery();
#endregion

app.Run();

#region snippet_AntiforgeryFilter
internal static class AntiForgeryExtensions
{
    public static TBuilder ValidateAntifogery<TBuilder>(this TBuilder builder) where TBuilder : IEndpointConventionBuilder
    {
        return builder.AddRouteHandlerFilter(routeHandlerFilter: async (context, next) =>
        {
            try
            {
                var antiForgeryService = context.HttpContext.RequestServices.GetRequiredService<IAntiforgery>();
                await antiForgeryService.ValidateRequestAsync(context.HttpContext);
            }
            catch (AntiforgeryValidationException)
            {
                return Results.BadRequest("Antiforgery token validation failed.");
            }

            return await next(context);

        });
    }
}
#endregion