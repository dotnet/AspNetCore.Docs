// <snippet_register_IProblemDetailsService_implementation>
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        if (context.ProblemDetails.Status == 400)
        {
            context.ProblemDetails.Title = "Validation error occurred";
            context.ProblemDetails.Extensions["support"] = "Contact support@example.com";
            context.ProblemDetails.Extensions["traceId"] = Guid.NewGuid().ToString();
        }
    };
});
// </snippet_register_IProblemDetailsService_implementation>

var app = builder.Build();

app.UseHttpsRedirection();

// Define endpoints
app.MapGet("/", () => "Hello! Use /products endpoint to test validation with IProblemDetailsService");

// Products endpoint that demonstrates validation
app.MapPost("/products", (Product product) => 
{
    // If validation passes (handled automatically based on DataAnnotations)
    return Results.Ok(product);
})
.Accepts<Product>("application/json")
.Produces<Product>(200)
.ProducesProblem(400);

// Explicitly trigger validation failure for testing
app.MapGet("/products/test-validation-error", () => 
{
    // Manually create an invalid product to see the validation error
    return Results.ValidationProblem(new Dictionary<string, string[]>
    {
        { "Name", new[] { "The Name field is required." } },
        { "Price", new[] { "The field Price must be between 1 and 100." } }
    });
});

app.Run();

// Model with validation attributes
public class Product
{
    [Required(ErrorMessage = "The Name field is required.")]
    public string? Name { get; set; }

    [Range(1, 100, ErrorMessage = "The field Price must be between 1 and 100.")]
    public decimal Price { get; set; }
}
