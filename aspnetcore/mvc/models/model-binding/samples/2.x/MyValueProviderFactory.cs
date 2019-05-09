using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace ModelBindingSample
{
    public class MyValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return AddValueProviderAsync(context);
        }

        private static async Task AddValueProviderAsync(ValueProviderFactoryContext context)
        {
            var valueProvider = new MyValueProvider(BindingSource.ModelBinding);

            context.ValueProviders.Add(valueProvider);
        }
    }
}
