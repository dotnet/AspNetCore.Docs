var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// <snippet_Middleware>
var app = builder.Build();

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
// </snippet_Middleware>
