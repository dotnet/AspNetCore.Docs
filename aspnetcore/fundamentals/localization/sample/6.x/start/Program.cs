#region snippet_full
var builder = WebApplication.CreateBuilder(args);

#region snippet_cultures
builder.Services.AddRequestLocalization(options =>
{
    options.AddSupportedCultures(new[] { "fr-FR", "it-IT", "es-ES" });
    options.AddSupportedUICultures(new[] { "fr-FR", "it-IT", "es-ES" });
});
#endregion

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion