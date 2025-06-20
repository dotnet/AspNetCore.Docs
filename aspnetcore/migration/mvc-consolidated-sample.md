---
title: Migrate ASP.NET MVC and Web API to ASP.NET Core
description: Learn how to migrate ASP.NET MVC and Web API applications to ASP.NET Core using both incremental and full migration approaches
author: rick-anderson
ms.author: riande
ms.date: 6/20/2025
uid: migration/mvc-consolidated
---

# Migrate ASP.NET MVC and Web API to ASP.NET Core

This guide covers migrating ASP.NET Framework MVC and Web API applications to ASP.NET Core. You can choose between two approaches based on your application's complexity and requirements.

## Choose Your Migration Approach

### 🔄 Incremental Migration (Recommended)

> [!TIP]
> **Best for MVC/Web API when:**
> - Your application has complex business logic in controllers
> - You use custom filters or dependency injection extensively  
> - You cannot afford extended downtime for migration
> - Your team is learning ASP.NET Core while migrating

**Benefits for MVC/Web API:**
- Migrate individual controllers and actions incrementally
- Share authentication and session state during transition
- Maintain existing URL structure and routing
- Use System.Web adapters to minimize initial code changes

**Get started:** [MVC/Web API Incremental Migration](#incremental-migration-setup)

### 🔧 Full Migration

> [!NOTE]
> **Consider full migration when:**
> - Your MVC/Web API app has minimal complexity
> - You want to modernize architecture completely
> - You have dedicated migration time available
> - Your app has few ASP.NET Framework dependencies

**Get started:** [MVC/Web API Full Migration](#full-migration-approach)

---

## Incremental Migration Setup

### Prerequisites

1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant)
2. Upgrade supporting libraries to .NET Standard 2.0 when possible

### Step 1: Create ASP.NET Core Proxy Application

1. Open your ASP.NET MVC or Web API solution in Visual Studio
2. Right-click the project → **Upgrade** → **Side-by-side incremental project upgrade**
3. Select **New project** for the upgrade target
4. Choose the appropriate template:
   - **ASP.NET Core Web API** for API projects
   - **ASP.NET Core MVC** for MVC projects or mixed MVC/API projects
5. Complete the wizard to create the connected ASP.NET Core project

The wizard creates:
- New ASP.NET Core project with YARP proxy configuration
- Connection between Framework and Core projects
- Basic System.Web adapter setup

> [!IMPORTANT]
> After setup, your ASP.NET Core app proxies all requests to the Framework app initially. You'll gradually migrate controllers to handle requests directly in the Core app.

### Step 2: Configure System.Web Adapters

In your ASP.NET Core project's `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add System.Web adapters
builder.Services.AddSystemWebAdapters()
    .AddProxySupport(options => options.UseForwardedHeaders = true)
    .AddRemoteAppAuthentication(isDefault: true)
    .AddRemoteAppSession(isDefault: true);

// Configure MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthentication(); // Before adapters for proper timing
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapControllers();
app.MapFallbackToRemoteApp();

app.Run();
```

### Step 3: Migrate Controllers Incrementally

Start with simple controllers and gradually increase complexity:

#### Example: Migrating a Simple API Controller

**Original ASP.NET Framework Web API Controller:**

```csharp
// ASP.NET Framework
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
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}
```

**Migrated ASP.NET Core Controller:**

```csharp
// ASP.NET Core
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
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}
```

> [!TIP]
> **Incremental Migration Advantage**: You can migrate one controller at a time. Once a controller exists in the ASP.NET Core project, it automatically handles those routes instead of proxying to the Framework app.

#### Example: Migrating MVC Controller with Dependencies

When your controller uses dependency injection or custom filters:

**Original Framework Controller:**

```csharp
public class HomeController : Controller
{
    private readonly IProductService _productService;
    
    public HomeController(IProductService productService)
    {
        _productService = productService;
    }
    
    [CustomActionFilter]
    public ActionResult Index()
    {
        var products = _productService.GetFeaturedProducts();
        return View(products);
    }
}
```

**Migration strategy with adapters:**

```csharp
// ASP.NET Core - Initial migration with adapters
public class HomeController : Controller
{
    private readonly IProductService _productService;
    
    public HomeController(IProductService productService)
    {
        _productService = productService;
    }
    
    [CustomActionFilter] // Can reuse filter with adapters
    public IActionResult Index()
    {
        var products = _productService.GetFeaturedProducts();
        return View(products);
    }
}
```

### Step 4: Handle Complex Scenarios

#### Shared Authentication

> [!NOTE]
> **Incremental Benefit**: Users remain logged in when navigating between migrated and non-migrated parts of your application.

Configure shared authentication in both applications:

**ASP.NET Core (`Program.cs`):**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppAuthentication(isDefault: true);
```

**ASP.NET Framework (`Global.asax.cs`):**
```csharp
protected void Application_Start()
{
    SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
        .AddAuthentication();
}
```

#### Shared Session State

> [!NOTE]
> **Incremental Benefit**: Session data is preserved across Framework and Core parts of your application during migration.

**ASP.NET Core:**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppSession(isDefault: true)
    .AddJsonSessionSerializer(options =>
    {
        // Configure known session types
        options.RegisterKey<UserProfile>("UserProfile");
        options.RegisterKey<ShoppingCart>("Cart");
    });
```

#### Custom Filters Migration

Custom action filters can be shared during incremental migration:

```csharp
// Shared filter working in both Framework and Core
public class CustomActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Access HttpContext through adapters
        var httpContext = System.Web.HttpContext.Current;
        
        // Your existing filter logic
        base.OnActionExecuting(context);
    }
}
```

### Step 5: Gradual Optimization

As you complete migration, gradually remove adapter dependencies:

1. **Replace `System.Web.HttpContext`** with ASP.NET Core's `HttpContext`
2. **Migrate custom filters** to ASP.NET Core patterns
3. **Update dependency injection** patterns
4. **Remove adapter references** once migration is complete

---

## Full Migration Approach

For applications suitable for complete rewrite:

### Step 1: Create New ASP.NET Core Project

Create a new ASP.NET Core project and systematically port functionality:

```bash
dotnet new mvc -n MyApp.Core    # For MVC apps
dotnet new webapi -n MyApp.Core # For API apps
```

### Step 2: Port Controllers Systematically

**ASP.NET Framework Web API → ASP.NET Core API:**

```csharp
// Framework
public class ValuesController : ApiController
{
    public IHttpActionResult Get()
    {
        return Ok(new string[] { "value1", "value2" });
    }
}

// ASP.NET Core
[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public ActionResult<string[]> Get()
    {
        return new string[] { "value1", "value2" };
    }
}
```

### Step 3: Migrate Configuration

Replace `Web.config` with `appsettings.json`:

```xml
<!-- Web.config -->
<appSettings>
  <add key="ConnectionString" value="..." />
</appSettings>
```

```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "..."
  }
}
```

### Step 4: Update Authentication

Migrate from ASP.NET Framework authentication to ASP.NET Core Identity:

```csharp
// Program.cs
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

[Detailed authentication migration guide](xref:migration/identity)

---

## Common Migration Scenarios

### Routing Differences

**ASP.NET Framework (Web API):**
```csharp
[Route("api/products/{id:int}")]
public IHttpActionResult GetProduct(int id) { }
```

**ASP.NET Core:**
```csharp
[HttpGet("api/products/{id:int}")]
public ActionResult<Product> GetProduct(int id) { }
```

### Model Binding

**Framework:**
```csharp
public IHttpActionResult Post([FromBody]Product product) { }
```

**Core:**
```csharp
[HttpPost]
public ActionResult<Product> Post(Product product) { } // FromBody implicit for complex types
```

### Dependency Injection

**Framework (with container):**
```csharp
container.RegisterType<IProductService, ProductService>();
```

**Core (built-in):**
```csharp
builder.Services.AddScoped<IProductService, ProductService>();
```

## Migration Checklist

### Pre-Migration Assessment
- [ ] Identify custom filters and their complexity
- [ ] Document authentication and authorization requirements
- [ ] List third-party dependencies and ASP.NET Core compatibility
- [ ] Assess routing complexity and URL requirements

### During Migration
- [ ] Set up proper error handling and logging
- [ ] Test authentication flows thoroughly
- [ ] Verify API contracts remain consistent
- [ ] Monitor performance during incremental migration
- [ ] Update client applications if needed

### Post-Migration
- [ ] Remove System.Web adapter dependencies (incremental only)
- [ ] Optimize ASP.NET Core-specific features
- [ ] Update deployment and monitoring processes
- [ ] Document new architecture and patterns

## Troubleshooting Common Issues

### Authentication Issues
- Verify shared authentication configuration
- Check cookie settings and domains
- Ensure proper middleware order in ASP.NET Core

### Session State Problems
- Confirm session serialization settings
- Verify session store configuration
- Check session timeout values

### Routing Conflicts
- Review route templates and constraints
- Check controller and action naming
- Verify attribute routing syntax

## Next Steps

### For Incremental Migration
- [Session State Migration](xref:migration/incremental/session-state)
- [Authentication Migration](xref:migration/incremental/authentication)
- [A/B Testing During Migration](xref:migration/incremental/testing)

### For Full Migration
- [Configuration Migration](xref:migration/configuration)
- [Identity Migration](xref:migration/identity)
- [HTTP Modules to Middleware](xref:migration/http-modules)

### Additional Resources
- [Migration Troubleshooting](xref:migration/reference/troubleshooting)
- [Performance Considerations](xref:migration/reference/performance)
- [eShop Migration Example](/dotnet/architecture/porting-existing-aspnet-apps/example-migration-eshop)
