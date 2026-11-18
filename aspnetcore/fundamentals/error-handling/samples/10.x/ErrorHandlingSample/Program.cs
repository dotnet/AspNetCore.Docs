// <snippet_RegisterIExceptionHandler>
using ErrorHandlingSample;

// <snippet_AddDatabaseDeveloperPageExceptionFilter>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
// </snippet_AddDatabaseDeveloperPageExceptionFilter>
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// <snippet_UseExceptionHandler>
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// </snippet_UseExceptionHandler>

// Remaining Program.cs code omitted for brevity
// </snippet_RegisterIExceptionHandler>

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
