using HttpRequestsSample.GitHub;
using HttpRequestsSample.Handlers;
using HttpRequestsSample.Models;
using Microsoft.Net.Http.Headers;
using Polly;
using Refit;

#region snippet_AddHttpClientBasic
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
#endregion

builder.Services.AddRazorPages();

#region snippet_AddHttpClientNamed
builder.Services.AddHttpClient("GitHub", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");

    // using Microsoft.Net.Http.Headers;
    // The GitHub API requires two headers.
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/vnd.github.v3+json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "HttpRequestsSample");
});
#endregion

#region snippet_AddRefitClient
builder.Services.AddRefitClient<IGitHubClient>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://api.github.com/");

        // using Microsoft.Net.Http.Headers;
        // The GitHub API requires two headers.
        httpClient.DefaultRequestHeaders.Add(
            HeaderNames.Accept, "application/vnd.github.v3+json");
        httpClient.DefaultRequestHeaders.Add(
            HeaderNames.UserAgent, "HttpRequestsSample");
    });
#endregion

#region snippet_AddHttpMessageHandler
builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.AddHttpClient("HttpMessageHandler")
    .AddHttpMessageHandler<ValidateHeaderHandler>();
#endregion

#region snippet_AddHttpMessageHandlerMultiple
builder.Services.AddTransient<SampleHandler1>();
builder.Services.AddTransient<SampleHandler2>();

builder.Services.AddHttpClient("MultipleHttpMessageHandlers")
    .AddHttpMessageHandler<SampleHandler1>()
    .AddHttpMessageHandler<SampleHandler2>();
#endregion

#region snippet_OperationScoped
builder.Services.AddScoped<IOperationScoped, OperationScoped>();
#endregion

builder.Services.AddTransient<OperationHandler>();
builder.Services.AddTransient<OperationResponseHandler>();

builder.Services.AddHttpClient("Operation")
    .AddHttpMessageHandler<OperationHandler>()
    .AddHttpMessageHandler<OperationResponseHandler>()
    .SetHandlerLifetime(TimeSpan.FromSeconds(5));

#region snippet_AddHttpClientTyped
builder.Services.AddHttpClient<GitHubService>();
#endregion

#region snippet_AddHttpClientPollyWaitAndRetry
builder.Services.AddHttpClient("PollyWaitAndRetry")
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));
#endregion

#region snippet_AddHttpClientPollyDynamic
var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));
var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(30));

builder.Services.AddHttpClient("PollyDynamic")
    .AddPolicyHandler(httpRequestMessage =>
        httpRequestMessage.Method == HttpMethod.Get ? timeoutPolicy : longTimeoutPolicy);
#endregion

#region snippet_AddHttpClientPollyMultiple
builder.Services.AddHttpClient("PollyMultiple")
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.RetryAsync(3))
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
#endregion

#region snippet_AddHttpClientHandlerLifetime
builder.Services.AddHttpClient("HandlerLifetime")
    .SetHandlerLifetime(TimeSpan.FromMinutes(5));
#endregion

#region snippet_AddHttpClientConfigureHttpMessageHandler
builder.Services.AddHttpClient("ConfiguredHttpMessageHandler")
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            AllowAutoRedirect = true,
            UseDefaultCredentials = true
        });
#endregion

#region snippet_AddHttpClientNoAutomaticCookies
builder.Services.AddHttpClient("NoAutomaticCookies")
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            UseCookies = false
        });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
