---
title: Share cookies among apps with ASP.NET and ASP.NET Core
author: damienbod
description: Learn how to write Middleware to validate remote IP addresses
ms.author: tdykstra
ms.custom: mvc
ms.date: 01/31/2018
uid: security/ip-safelist
---
# IP-Safelist Middleware in ASP.NET Core

By [Damien Bowden](https://twitter.com/damien_bod) and [Tom Dykstra](https://github.com/tdykstra)
 
This help article shows how a client safe-list could be implemented using ASP.NET Core middleware checking the Remote IP address of the request. If the client IP is on the safe-list, no restrictions exist.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/ip-safelist/samples/2.x/ClientIpAspNetCore) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample illustrates middleware which validtes the remote IPof every client request.

* ASP.NET Core 2.x Middleware which checks the remote IP (IP4, IP6) and validates this uses a safe-list of IPs from the app.settings.


The middleware uses an admin white-list parameter from the constructor to compare with the remote IP address from the HttpContext Connection property. This is different to previous versions of .NET. In the example, all GET requests are allowed. If any other request method is used, the remote IP is used to check if it exists in the safe-list. If it does not exist, a 403 is returned.

```csharp
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ClientIpAspNetCore
{
    public class AdminSafeListMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AdminSafeListMiddleware> _logger;
        private readonly string _adminSafeList;

        public AdminSafeListMiddleware(RequestDelegate next, ILogger<AdminSafeListMiddleware> logger, string adminWhiteList)
        {
            _adminSafeList = adminWhiteList;
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method != "GET")
            {
                var remoteIp = context.Connection.RemoteIpAddress;
                _logger.LogDebug($"Request from Remote IP address: {remoteIp}");

                string[] ip = _adminSafeList.Split(';');

                var bytes = remoteIp.GetAddressBytes();
                var badIp = true;
                foreach (var address in ip)
                {
                    var testIp = IPAddress.Parse(address);
                    if(testIp.GetAddressBytes().SequenceEqual(bytes))
                    {
                        badIp = false;
                        break;
                    }
                }

                if(badIp)
                {
                    _logger.LogInformation($"Forbidden Request from Remote IP address: {remoteIp}");
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return;
                }
            }

            await _next.Invoke(context);

        }
    }
}
```

The safe-list is configured in the appsettings.config. This is a ';' separated list which is split in the middleware class.

```csharp
{
  "AdminSafeList": "127.0.0.1;192.168.1.5;::1",
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }
}
```

In the startup class, the AdminSafeListMiddleware type is added using the appsettings configuration.

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
	...

	app.UseStaticFiles();

	app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);
	app.UseMvc();
}
```

If a request is sent, other that a GET method, and it is not in the safe-list, the 403 response is returned to the client and logged.

```
2017-09-31 16:45:42.8891|0|ClientIpAspNetCore.AdminWhiteListMiddleware|INFO|  Request from Remote IP address: 192.168.1.4 
2016-09-31 16:45:42.9031|0|ClientIpAspNetCore.AdminWhiteListMiddleware|INFO|  Forbidden Request from Remote IP address: 192.168.1.4 
```

An ActionFilter could also be used to implement this, for example if more specific logic is required. 

```csharp
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ClientIpAspNetCore.Filters
{
    public class ClientIdCheckFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ClientIdCheckFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ClassConsoleLogActionOneFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Remote IpAddress: {context.HttpContext.Connection.RemoteIpAddress}");

            // TODO implement some business logic for this...

            base.OnActionExecuting(context);
        }
    }
}
```

The ActionFilter can be added to the services.

```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddScoped<ClientIdCheckFilter>();

	services.AddMvc();
}
```

And can be used specifically on any controller as required.

```csharp
[ServiceFilter(typeof(ClientIdCheckFilter))]
[Route("api/[controller]")]
public class ValuesController : Controller
```

## Links:

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware
