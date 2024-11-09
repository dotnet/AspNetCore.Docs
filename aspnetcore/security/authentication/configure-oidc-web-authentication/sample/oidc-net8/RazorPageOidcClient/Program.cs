using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    var oidcConfig = builder.Configuration.GetSection("OpenIDConnectSettings");
    options.Authority = oidcConfig["Authority"];
    options.ClientId = oidcConfig["ClientId"];
    options.ClientSecret = oidcConfig["ClientSecret"];

    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.ResponseType = OpenIdConnectResponseType.Code;

    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name"
    };
});

builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build());

builder.Services.AddRazorPages();

var app = builder.Build();

//IdentityModelEventSource.ShowPII = true;
JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// Authorization is required for middleware after the UseAuthorization method
app.UseAuthorization();
app.MapRazorPages();

app.Run();
