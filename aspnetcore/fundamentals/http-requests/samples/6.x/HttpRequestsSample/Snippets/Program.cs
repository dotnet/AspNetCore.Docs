using HttpRequestsSample.GitHub;
using Polly;

namespace HttpRequestsSample.Snippets;

public static class Program
{
    private static void Snippet1(WebApplicationBuilder builder)
    {
        // <snippet_AddHttpClientTypedInline>
        builder.Services.AddHttpClient<GitHubService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://api.github.com/");

            // ...
        });
        // </snippet_AddHttpClientTypedInline>
    }

    private static void Snippet2(WebApplicationBuilder builder)
    {
        // <snippet_AddHttpClientPollyRegistry>
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
            TimeSpan.FromSeconds(10));
        var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
            TimeSpan.FromSeconds(30));

        var policyRegistry = builder.Services.AddPolicyRegistry();

        policyRegistry.Add("Regular", timeoutPolicy);
        policyRegistry.Add("Long", longTimeoutPolicy);

        builder.Services.AddHttpClient("PollyRegistryRegular")
            .AddPolicyHandlerFromRegistry("Regular");

        builder.Services.AddHttpClient("PollyRegistryLong")
            .AddPolicyHandlerFromRegistry("Long");
        // </snippet_AddHttpClientPollyRegistry>
    }

    private static void Snippet3(WebApplicationBuilder builder)
    {
        // <snippet_AddHttpClientHeaderPropagation>
        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddHttpClient("PropagateHeaders")
            .AddHeaderPropagation();

        builder.Services.AddHeaderPropagation(options =>
        {
            options.Headers.Add("X-TraceId");
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.UseHeaderPropagation();

        app.MapControllers();
        // </snippet_AddHttpClientHeaderPropagation>
    }
}
