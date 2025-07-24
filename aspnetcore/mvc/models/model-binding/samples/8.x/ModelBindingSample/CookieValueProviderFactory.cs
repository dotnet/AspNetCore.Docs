using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingSample;

public class CookieValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        _ = context ?? throw new ArgumentNullException(nameof(context));

        var cookies = context.ActionContext.HttpContext.Request.Cookies;
        if (cookies is not null && cookies.Count > 0)
        {
            var valueProvider = new CookieValueProvider(
                BindingSource.ModelBinding,
                cookies,
                CultureInfo.InvariantCulture);

            context.ValueProviders.Add(valueProvider);
        }

        return Task.CompletedTask;
    }
}
