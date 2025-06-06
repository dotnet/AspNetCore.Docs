## `UserManager` and `SignInManager`

Set the user identifier claim type when a Server app requires:

* <xref:Microsoft.AspNetCore.Identity.UserManager%601> or <xref:Microsoft.AspNetCore.Identity.SignInManager%601> in an API endpoint.
* <xref:Microsoft.AspNetCore.Identity.IdentityUser> details, such as the user's name, email address, or lockout end time.

In `Program.cs` for ASP.NET Core in .NET 6 or later:

```csharp
using System.Security.Claims;

...

builder.Services.Configure<IdentityOptions>(options => 
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
```

In `Startup.ConfigureServices` for .NET 5 or earlier:

```csharp
using System.Security.Claims;

...

services.Configure<IdentityOptions>(options => 
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
```

The following `WeatherForecastController` logs the <xref:Microsoft.AspNetCore.Identity.IdentityUser%601.UserName> when the `Get` method is called.

> [!NOTE]
> The following example uses:
>
> * A [file-scoped namespace](/dotnet/csharp/language-reference/keywords/namespace), which is a C# 10 or later (.NET 6 or later) feature.
> * A [primary constructor](/dotnet/csharp/whats-new/tutorials/primary-constructors), which is a C# 12 or later (.NET 8 or later) feature.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using BlazorSample.Server.Models;
using BlazorSample.Shared;

namespace BlazorSample.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger, 
        UserManager<ApplicationUser> userManager) : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", 
        "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var rng = new Random();

        var user = await userManager.GetUserAsync(User);

        if (user != null)
        {
            logger.LogInformation("User.Identity.Name: {UserIdentityName}", user.UserName);
        }

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
```

In the preceding example:

* The **`Server`** project's namespace is `BlazorSample.Server`.
* The **`Shared`** project's namespace is `BlazorSample.Shared`.
