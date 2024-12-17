using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    // ........................................................................
    // The OIDC handler must use a sign-in scheme capable of persisting 
    // user credentials across requests.

    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    // ........................................................................

    // ........................................................................
    // The "openid" and "profile" scopes are required for the OIDC handler 
    // and included by default. 

    //options.Scope.Add("some-scope");
    // ........................................................................

    // ........................................................................
    // The following paths must match the redirect and post logout redirect 
    // paths configured when registering the application with the OIDC provider. 
    // Both the signin and signout paths must be registered as Redirect URIs.
    // The default values are "/signin-oidc" and "/signout-callback-oidc".

    //options.CallbackPath = new PathString("/signin-oidc");
    //options.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
    // ........................................................................

    // ........................................................................
    // The RemoteSignOutPath is the "Front-channel logout URL" for remote single 
    // sign-out. The default value is "/signout-oidc".

    //options.RemoteSignOutPath = new PathString("/signout-oidc");
    // ........................................................................

    var oidcConfig = builder.Configuration.GetSection("OpenIDConnectSettings");
    // ........................................................................
    // Authority is the OIDC provider's base URL. Set the application settings

    options.Authority = oidcConfig["Authority"];
    // ........................................................................

    // ........................................................................
    // Set the Client ID for the app. Set the application settings to
    // the Client ID.

    options.ClientId = oidcConfig["ClientId"];
    // ........................................................................


    options.ClientSecret = oidcConfig["ClientSecret"];

    // ........................................................................
    // Setting ResponseType to "code" configures the OIDC handler to use 
    // authorization code flow. The OIDC handler automatically requests the
    // appropriate tokens using the code returned from the
    // authorization endpoint.

    options.ResponseType = OpenIdConnectResponseType.Code;
    // ........................................................................

    // ........................................................................
    // Set MapInboundClaims to "false" to obtain the original claim types from 
    // the token. Many OIDC servers use "name" and "role"/"roles" rather than 
    // the SOAP/WS-Fed defaults in ClaimTypes. Adjust these values if your 
    // identity provider uses different claim types.

    options.MapInboundClaims = false;
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    // ........................................................................

    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
});

var requireAuthPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(requireAuthPolicy);

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
// Authorization is applied for middleware after the UseAuthorization method
app.UseAuthorization();
app.MapRazorPages();

app.Run();
