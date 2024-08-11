using Microsoft.AspNetCore.DataProtection.KeyManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataProtection();

var app = builder.Build();

app.MapGet("/delete-old-keys", (IServiceProvider services) =>
{
    var keyManager = services.GetService<IKeyManager>();

    if (keyManager is IDeletableKeyManager deletableKeyManager)
    {
        var utcNow = DateTimeOffset.UtcNow;
        var yearAgo = utcNow.AddYears(-1);

        if (!deletableKeyManager.DeleteKeys(key => key.ExpirationDate < yearAgo))
        {
            // Log the error or handle it appropriately
            return Results.BadRequest("Failed to delete keys.");
        }

        return Results.Ok("Old keys deleted successfully.");
    }
    else
    {
        return Results.StatusCode(500); // Or another appropriate status code
    }
});

app.Run();
