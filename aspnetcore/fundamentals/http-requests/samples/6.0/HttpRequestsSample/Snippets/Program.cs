using HttpRequestsSample.GitHub;

namespace HttpRequestsSample.Snippets
{
    public static class Program
    {
        private static void Snippet1(WebApplicationBuilder builder)
        {
            #region snippet_AddHttpClientTypedInline
            builder.Services.AddHttpClient<GitHubService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.github.com/");

                // ...
            });
            #endregion
        }

        private static void Snippet2(WebApplicationBuilder builder)
        {
            #region snippet_AddHttpClientHeaderPropagation
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
            #endregion
        }
    }
}
