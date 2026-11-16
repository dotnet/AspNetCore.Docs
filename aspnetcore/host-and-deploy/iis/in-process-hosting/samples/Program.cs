using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Server.IIS;

var builder = WebApplication.CreateBuilder(args);

// <snippet_options>
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});
// </snippet_options>

// <snippet_authentication>
builder.Services.AddTransient<IClaimsTransformation, MyClaimsTransformation>();
builder.Services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
// </snippet_authentication>

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
