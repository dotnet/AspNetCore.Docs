// Initialize a new instance of the WebApplicationBuilder class 
// with preconfigured defaults
var builder = WebApplication.CreateBuilder(args);

// Add services for Razor Pages and MVC
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline

// Use exception-handling middleware and HSTS middleware
// when in the Development environment
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Use HTTPS redirection middleware to automatically
// redirect requests from HTTP to HTTPS
app.UseHttpsRedirection();

// Use static files middleware to serve static assets
app.UseStaticFiles();

// Use authorization middleware
app.UseAuthorization();

// Map a Minimal API endpoint for requests to '/hi'
app.MapGet("/hi", () => "Hello!");

// Configures the standard conventional route for MVC
app.MapDefaultControllerRoute();

// Add endpoints for Razor Pages
app.MapRazorPages();

// Run the app
app.Run();
