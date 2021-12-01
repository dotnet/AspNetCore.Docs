using HttpRequestsSample.GitHub;
using HttpRequestsSample.Handlers;
using HttpRequestsSample.Models;
using Microsoft.Net.Http.Headers;
using Polly;
using Refit;

// <snippet_AddHttpClientBasic>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
// </snippet_AddHttpClientBasic>

builder.Services.AddRazorPages();

// <snippet_AddHttpClientNamed>
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
// </snippet_AddHttpClientNamed>

// <snippet_AddRefitClient>
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
// </snippet_AddRefitClient>

// <snippet_AddHttpMessageHandler>
builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.AddHttpClient("HttpMessageHandler")
    .AddHttpMessageHandler<ValidateHeaderHandler>();
// </snippet_AddHttpMessageHandler>

// <snippet_AddHttpMessageHandlerMultiple>
builder.Services.AddTransient<SampleHandler1>();
builder.Services.AddTransient<SampleHandler2>();

builder.Services.AddHttpClient("MultipleHttpMessageHandlers")
    .AddHttpMessageHandler<SampleHandler1>()
    .AddHttpMessageHandler<SampleHandler2>();
// </snippet_AddHttpMessageHandlerMultiple>

// <snippet_OperationScoped>
builder.Services.AddScoped<IOperationScoped, OperationScoped>();
// </snippet_OperationScoped>

builder.Services.AddTransient<OperationHandler>();
builder.Services.AddTransient<OperationResponseHandler>();

builder.Services.AddHttpClient("Operation")
    .AddHttpMessageHandler<OperationHandler>()
    .AddHttpMessageHandler<OperationResponseHandler>()
    .SetHandlerLifetime(TimeSpan.FromSeconds(5));

// <snippet_AddHttpClientTyped>
builder.Services.AddHttpClient<GitHubService>();
// </snippet_AddHttpClientTyped>

// <snippet_AddHttpClientPollyWaitAndRetry>
builder.Services.AddHttpClient("PollyWaitAndRetry")
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.WaitAndRetryAsync(
            3, retryNumber => TimeSpan.FromMilliseconds(600)));
// </snippet_AddHttpClientPollyWaitAndRetry>

// <snippet_AddHttpClientPollyDynamic>
var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
    TimeSpan.FromSeconds(10));
var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
    TimeSpan.FromSeconds(30));

builder.Services.AddHttpClient("PollyDynamic")
    .AddPolicyHandler(httpRequestMessage =>
        httpRequestMessage.Method == HttpMethod.Get ? timeoutPolicy : longTimeoutPolicy);
// </snippet_AddHttpClientPollyDynamic>

// <snippet_AddHttpClientPollyMultiple>
builder.Services.AddHttpClient("PollyMultiple")
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.RetryAsync(3))
    .AddTransientHttpErrorPolicy(policyBuilder =>
        policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
// </snippet_AddHttpClientPollyMultiple>

// <snippet_AddHttpClientHandlerLifetime>
builder.Services.AddHttpClient("HandlerLifetime")
    .SetHandlerLifetime(TimeSpan.FromMinutes(5));
// </snippet_AddHttpClientHandlerLifetime>

// <snippet_AddHttpClientConfigureHttpMessageHandler>
builder.Services.AddHttpClient("ConfiguredHttpMessageHandler")
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            AllowAutoRedirect = true,
            UseDefaultCredentials = true
        });
// </snippet_AddHttpClientConfigureHttpMessageHandler>

// <snippet_AddHttpClientNoAutomaticCookies>
builder.Services.AddHttpClient("NoAutomaticCookies")
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            UseCookies = false
        });
// </snippet_AddHttpClientNoAutomaticCookies>

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
