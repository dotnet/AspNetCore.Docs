using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ModelBindingSample
{
    public class CookieValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var cookies = context.ActionContext.HttpContext.Request.Cookies;
            if (cookies != null && cookies.Count > 0)
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
}
