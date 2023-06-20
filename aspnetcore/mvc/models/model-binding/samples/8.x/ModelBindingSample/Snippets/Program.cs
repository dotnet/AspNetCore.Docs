using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace ModelBindingSample.Snippets;

public static class Program
{
    public static void AddValueProviderFactory(WebApplicationBuilder builder)
    {
        // <snippet_AddValueProviderFactory>
        builder.Services.AddControllers(options =>
        {
            options.ValueProviderFactories.Add(new CookieValueProviderFactory());
        });
        // </snippet_AddValueProviderFactory>
    }

    public static void ReplaceQueryStringValueProviderFactory(WebApplicationBuilder builder)
    {
        // <snippet_ReplaceQueryStringValueProviderFactory>
        builder.Services.AddControllers(options =>
        {
            var index = options.ValueProviderFactories.IndexOf(
                options.ValueProviderFactories.OfType<QueryStringValueProviderFactory>()
                    .Single());

            options.ValueProviderFactories[index] =
                new CultureQueryStringValueProviderFactory();
        });
        // </snippet_ReplaceQueryStringValueProviderFactory>
    }

    public static void AddXmlSerializerFormatters(WebApplicationBuilder builder)
    {
        // <snippet_AddXmlSerializerFormatters>
        builder.Services.AddControllers()
            .AddXmlSerializerFormatters();
        // </snippet_AddXmlSerializerFormatters>
    }

    public static void ExcludeSuppressModelBinding(WebApplicationBuilder builder)
    {
        // <snippet_ModelMetadataDetailsProviders>
        builder.Services.AddRazorPages()
            .AddMvcOptions(options =>
            {
                options.ModelMetadataDetailsProviders.Add(
                    new ExcludeBindingMetadataProvider(typeof(Version)));
                options.ModelMetadataDetailsProviders.Add(
                    new SuppressChildValidationMetadataProvider(typeof(Guid)));
            });
        // </snippet_ModelMetadataDetailsProviders>
    }
}
