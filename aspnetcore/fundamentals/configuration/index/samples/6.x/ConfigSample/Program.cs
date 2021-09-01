
using ConfigSample.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//var Configuration = 

//builder.Services.Configure<PositionOptions>(Configuration.GetSection(
//                                                PositionOptions.Position));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{ 
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
