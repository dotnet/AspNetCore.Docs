#if NEVER
#region snippet
using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<SchoolContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var myMaxModelBindingCollectionSize = Convert.ToInt32(
           builder.Configuration["MyMaxModelBindingCollectionSize"] ?? "100");

builder.Services.Configure<MvcOptions>(options =>
       options.MaxModelBindingCollectionSize = myMaxModelBindingCollectionSize);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion
#endif