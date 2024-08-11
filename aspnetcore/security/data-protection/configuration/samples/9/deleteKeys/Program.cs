using Microsoft.AspNetCore.DataProtection.KeyManagement;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapDelete("/api/keys/cleanup-old-keys", (IServiceProvider services) =>
{
    var keyManager = services.GetService<IKeyManager>();
    if (keyManager is IDeletableKeyManager deletableKeyManager)
    {
        var utcNow = DateTimeOffset.UtcNow;
        var yearAgo = utcNow.AddYears(-1);
        if (!deletableKeyManager.DeleteKeys(key => key.ExpirationDate < yearAgo))
        {
            throw new InvalidOperationException("Failed to delete keys.");
        }
    }

    return Results.Ok("Old keys deleted successfully.");
});

app.Run();
