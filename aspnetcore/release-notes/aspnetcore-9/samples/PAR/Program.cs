using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// <snippet_1>
 builder.Services
     .AddAuthentication(options =>
     {
         options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
         options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
     })
     .AddCookie()
     .AddOpenIdConnect("oidc", oidcOptions =>
     {
         // Other provider-specific configuration goes here.
 
         // The default value is PushedAuthorizationBehavior.UseIfAvailable.
 
         // 'OpenIdConnectOptions' does not contain a definition for 'PushedAuthorizationBehavior'
         // and no accessible extension method 'PushedAuthorizationBehavior' accepting a first argument
         // of type 'OpenIdConnectOptions' could be found
         oidcOptions.PushedAuthorizationBehavior = PushedAuthorizationBehavior.Disable;
     });
// </snippet_1>

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
