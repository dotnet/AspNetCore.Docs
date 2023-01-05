#region snippet_NewUsings
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
#endregion
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region snippet_builderservices
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureADB2C"));

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to 
    // the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages(options => {
    options.Conventions.AllowAnonymousToPage("/Index");
})
.AddMvcOptions(options => { })
.AddMicrosoftIdentityUI();
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

#region snippet_app
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
#endregion

app.Run();
