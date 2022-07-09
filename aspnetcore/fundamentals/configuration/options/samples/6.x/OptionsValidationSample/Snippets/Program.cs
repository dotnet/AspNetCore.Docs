using OptionsValidationSample.Configuration;

namespace OptionsValidationSample.Snippets;

public static class Program
{
    public static void ValidateOnStart(WebApplicationBuilder builder)
    {
        // <snippet_ValidateOnStart>
        builder.Services.AddOptions<MyConfigOptions>()
            .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        // </snippet_ValidateOnStart>
    }
}
