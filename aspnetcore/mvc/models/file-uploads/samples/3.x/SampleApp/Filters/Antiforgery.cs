using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp.Filters
{
    #region snippet_GenerateAntiforgeryTokenCookieAttribute
    public class GenerateAntiforgeryTokenCookieAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var antiforgery = context.HttpContext.RequestServices.GetService<IAntiforgery>();

            // Send the request token as a JavaScript-readable cookie
            var tokens = antiforgery.GetAndStoreTokens(context.HttpContext);

            context.HttpContext.Response.Cookies.Append(
                "RequestVerificationToken",
                tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
    #endregion
}

