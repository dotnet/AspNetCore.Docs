// <snippet_AddDatabaseDeveloperPageExceptionFilter>
using ErrorHandlingSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
// </snippet_AddDatabaseDeveloperPageExceptionFilter>

// <snippet_UseExceptionHandler>
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// </snippet_UseExceptionHandler>

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
