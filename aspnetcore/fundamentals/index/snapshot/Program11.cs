// Initialize a new instance of the WebApplicationBuilder class 
// with preconfigured defaults
var builder = WebApplication.CreateBuilder(args);

// Add services for Blazor (Razor components)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Build the app
var app = builder.Build();

// Use exception-handling middleware and HSTS middleware
// when in the Development environment
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

// Use HTTPS redirection middleware to automatically
// redirect requests from HTTP to HTTPS
app.UseHttpsRedirection();

// Add antiforgery middleware
app.UseAntiforgery();

// Map static assets endpoints
app.MapStaticAssets();

// Map a Minimal API endpoint for requests to '/hi'
app.MapGet("/hi", () => "Hello!");

// Add endpoints for Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run the app
app.Run();
