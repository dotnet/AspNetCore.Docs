---
title: Learn to upgrade from ASP.NET MVC and Web API to ASP.NET Core MVC
description: Learn how to upgrade an ASP.NET MVC Framework or Web API project to ASP.NET Core MVC
author: rick-anderson
ms.author: riande
ms.date: 03/07/2017
uid: migration/mvc
---
# Upgrade from ASP.NET MVC and Web API to ASP.NET Core MVC

 :::moniker range=">= aspnetcore-7.0"

---
title: Migrate ASP.NET MVC and Web API to ASP.NET Core
description: Choose between incremental and full migration approaches for ASP.NET Framework MVC and Web API applications based on complexity and business requirements.
author: rick-anderson
ms.author: riande
ms.date: 6/20/2025
uid: migration/mvc
---
# Migrate ASP.NET MVC and Web API to ASP.NET Core

 :::moniker range=">= aspnetcore-7.0"

This guide helps you migrate ASP.NET Framework MVC and Web API applications to ASP.NET Core. Choose your migration approach based on application complexity and business constraints.

## Recommended approach: Incremental migration

Most MVC and Web API applications benefit from incremental migration because it:
- Preserves production availability during migration
- Allows gradual team learning of ASP.NET Core patterns
- Maintains existing authentication and session state during transition
- Enables controller-by-controller migration with immediate testing

### When incremental migration works best for MVC/Web API

**Highly recommended for applications with:**
- Complex controller dependencies and business logic
- Custom action filters and authorization patterns
- Extensive use of dependency injection
- Session state requirements
- Custom HTTP modules or handlers
- Authentication integration that cannot be interrupted

**Consider full migration for:**
- Simple API endpoints with minimal dependencies
- Applications where you want to completely modernize architecture
- Small to medium applications with straightforward routing

## Incremental migration setup

### Prerequisites

Prepare your solution for incremental migration:

1. **Upgrade supporting libraries**: Target .NET Standard 2.0 when possible to enable sharing between Framework and Core applications
2. **Install migration tools**: Add the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension

### Step 1: Create proxy architecture

1. Open your ASP.NET MVC or Web API solution in Visual Studio
2. Right-click the project → **Upgrade** → **Side-by-side incremental project upgrade**
3. Select **New project** for upgrade target
4. Choose the appropriate template:
   - **ASP.NET Core Web API** for API-focused projects
   - **ASP.NET Core MVC** for MVC or mixed MVC/API projects
5. Complete the wizard to establish YARP proxy connection

The wizard creates a new ASP.NET Core project that initially proxies all requests to your existing Framework application. You'll gradually migrate controllers to handle requests directly in the Core application.

### Step 2: Configure System.Web adapters

System.Web adapters enable code sharing between Framework and Core applications during migration.

**ASP.NET Core project configuration:**

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add System.Web adapters for gradual migration
builder.Services.AddSystemWebAdapters()
    .AddProxySupport(options => options.UseForwardedHeaders = true)
    .AddRemoteAppAuthentication(isDefault: true)
    .AddRemoteAppSession(isDefault: true);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthentication(); // Before adapters for proper event timing
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapControllers();
app.MapFallbackToRemoteApp(); // Proxy unmigrated routes

app.Run();
```

### Step 3: Migrate controllers incrementally

Start with simple controllers and progress to more complex ones:

#### Example: Simple API controller migration

**Before (ASP.NET Framework):**
```csharp
public class ProductsController : ApiController
{
    public IHttpActionResult Get()
    {
        var products = GetProducts();
        return Ok(products);
    }
    
    public IHttpActionResult Get(int id)
    {
        var product = GetProduct(id);
        return product == null ? NotFound() : Ok(product);
    }
}
```

**After (ASP.NET Core):**
```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = GetProducts();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = GetProduct(id);
        return product == null ? NotFound() : Ok(product);
    }
}
```

Once you add a controller to the ASP.NET Core project, it automatically handles those routes instead of proxying to the Framework application.

#### Managing complex controller dependencies

For controllers with dependencies, use adapters during initial migration:

**Framework controller with dependencies:**
```csharp
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [CustomAuthFilter]
    public ActionResult ProcessOrder(OrderModel model)
    {
        // Business logic using System.Web context
        var userId = HttpContext.Current.User.Identity.Name;
        return View(_orderService.ProcessOrder(model, userId));
    }
}
```

**Initial ASP.NET Core migration with adapters:**
```csharp
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [CustomAuthFilter] // Works with adapters initially
    public IActionResult ProcessOrder(OrderModel model)
    {
        // Adapters enable System.Web context access during migration
        var userId = System.Web.HttpContext.Current.User.Identity.Name;
        return View(_orderService.ProcessOrder(model, userId));
    }
}
```

### Step 4: Handle shared concerns

#### Authentication continuity

Maintain user authentication across Framework and Core applications:

**ASP.NET Core configuration:**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppAuthentication(isDefault: true);
```

**ASP.NET Framework configuration (Global.asax.cs):**
```csharp
protected void Application_Start()
{
    SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
        .AddAuthentication();
}
```

This ensures users remain authenticated when navigating between migrated and non-migrated parts of your application.

#### Session state preservation

Share session data between applications during migration:

**ASP.NET Core session configuration:**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppSession(isDefault: true)
    .AddJsonSessionSerializer(options =>
    {
        // Register types stored in session
        options.RegisterKey<UserProfile>("UserProfile");
        options.RegisterKey<ShoppingCart>("Cart");
    });
```

#### Custom filters and middleware

Existing action filters work with adapters during migration:

```csharp
public class AuditActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Works in both Framework and Core with adapters
        var httpContext = System.Web.HttpContext.Current;
        var userAgent = httpContext.Request.UserAgent;
        
        // Log audit information
        LogAuditEvent(context.ActionDescriptor.DisplayName, userAgent);
        
        base.OnActionExecuting(context);
    }
}
```

### Step 5: Optimize and remove adapters

After completing controller migration, gradually modernize your ASP.NET Core implementation:

1. **Replace System.Web.HttpContext** with ASP.NET Core's HttpContext
2. **Migrate custom filters** to ASP.NET Core patterns
3. **Update dependency injection** patterns
4. **Remove adapter packages** once migration is complete

**Modernized controller example:**
```csharp
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [ModernAuthFilter] // Native ASP.NET Core filter
    public IActionResult ProcessOrder(OrderModel model)
    {
        // Use ASP.NET Core HttpContext
        var userId = HttpContext.User.Identity.Name;
        return View(_orderService.ProcessOrder(model, userId));
    }
}
```

## Alternative: Full migration approach

For applications suited to complete rewrite:

### When to choose full migration

- **Simple applications** with minimal business logic complexity
- **Clean architecture goals** where you want to modernize patterns completely
- **Adequate migration time** with dedicated development windows
- **Minimal System.Web dependencies**

### Full migration process

1. **Create new ASP.NET Core project**: Start with appropriate template
2. **Port controllers systematically**: Migrate routing, model binding, and action results
3. **Update authentication**: Implement ASP.NET Core Identity or external providers
4. **Migrate configuration**: Replace Web.config with appsettings.json
5. **Test comprehensively**: Validate all functionality before deployment

**Full migration resources:**
- [Configuration migration guide](xref:migration/configuration)
- [Identity migration guide](xref:migration/identity)
- [HTTP modules to middleware](xref:migration/http-modules)

## Migration best practices

### Planning phase
- **Assess controller complexity**: Start with simple controllers, progress to complex ones
- **Inventory dependencies**: Catalog third-party packages and custom components
- **Plan authentication strategy**: Determine shared vs. migrated authentication approach

### Implementation phase
- **Test incrementally**: Verify each migrated controller thoroughly
- **Monitor performance**: Track response times during proxy operation
- **Maintain documentation**: Record migration decisions and patterns

### Optimization phase
- **Remove adapter dependencies**: Gradually eliminate System.Web references
- **Modernize patterns**: Adopt ASP.NET Core best practices
- **Performance tune**: Optimize for ASP.NET Core capabilities

## Troubleshooting common issues

### Routing conflicts
**Problem**: Routes not matching after migration
**Solution**: Verify route templates and attribute routing syntax

### Authentication failures
**Problem**: Users losing authentication between applications
**Solution**: Check shared authentication configuration and cookie settings

### Session state issues
**Problem**: Session data not persisting across applications
**Solution**: Verify session serialization configuration and data types

## Next steps

Choose your implementation path:

### For incremental migration
- [Session state migration details](xref:migration/inc/session)
- [Authentication migration specifics](xref:migration/inc/remote-authentication)
- [A/B testing during migration](xref:migration/inc/ab-testing)

### For full migration
- [Complete configuration migration](xref:migration/configuration)
- [HTTP modules to middleware migration](xref:migration/http-modules)
- [Identity system migration](xref:migration/identity)

### Additional resources
- [Migration troubleshooting guide](xref:migration/reference/troubleshooting)
- [eShop migration case study](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop)

:::moniker-end

[!INCLUDE[](~/migration/mvc/includes/mvc6.md)]
