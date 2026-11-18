using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// <snippet_Upgrade>
app.Map("/upgrade", async (HttpContext context) =>
{
    var upgradeFeature = context.Features
        .Get<Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature>();
    if (upgradeFeature is not null &&
        upgradeFeature.IsUpgradableRequest &&
        context.Request.Headers.Upgrade.Any(h =>
            h?.Contains("custom-protocol",
                StringComparison.OrdinalIgnoreCase) == true))
    {
        // Specify the upgraded protocol on the response before upgrading:
        context.Response.Headers.Upgrade = "custom-protocol";
        await using Stream stream = await upgradeFeature.UpgradeAsync();
        // Read and write directly to the upgraded transport stream...
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});
// </snippet_Upgrade>

app.Run();
