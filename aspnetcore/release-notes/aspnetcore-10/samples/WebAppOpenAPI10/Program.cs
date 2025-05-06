var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// <snippet_DefaultOpenApiVersion>
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});
// </snippet_DefaultOpenApiVersion>

var app = builder.Build();

// Configure the HTTP request pipeline.
// <snippet_ConfigOpenApiYAML>
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/{documentName}.yaml");
}
// </snippet_ConfigOpenApiYAML>

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
