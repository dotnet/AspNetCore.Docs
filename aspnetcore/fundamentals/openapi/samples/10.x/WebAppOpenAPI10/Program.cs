#define SCHEMA_IN_TRANSFORMER_EXAMPLE     //YAML_EXAMPLE   //SCHEMA_IN_TRANSFORMER_EXAMPLE
#if YAML_EXAMPLE

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// <snippet_DefaultOpenApiVersion>
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_1;
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

#elif SCHEMA_IN_TRANSFORMER_EXAMPLE

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// <snippet_Generate_OpenApiSchemas_for_type>
builder.Services.AddOpenApi(options =>
{
    options.AddOperationTransformer(async (operation, context, cancellationToken) =>
    {
        // Generate schema for error responses
        var errorSchema = await context.GetOrCreateSchemaAsync(typeof(ProblemDetails), null, cancellationToken);
        context.Document?.AddComponent("Error", errorSchema);

        operation.Responses ??= new OpenApiResponses();
        // Add a "4XX" response to the operation with the newly created schema
        operation.Responses["4XX"] = new OpenApiResponse
        {
            Description = "Bad Request",
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/problem+json"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchemaReference("Error", context.Document)
                }
            }
        };
    });
});
// </snippet_Generate_OpenApiSchemas_for_type>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/{documentName}.yaml");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endif
