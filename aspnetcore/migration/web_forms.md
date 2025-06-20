---
title: Learn to upgrade from ASP.NET Web Forms to ASP.NET Core
description: Learn how to upgrade an ASP.NET Web Forms project to ASP.NET Core
author: rick-anderson
ms.author: riande
ms.date: 3/1/2025
uid: migration/web_forms
---
# Upgrade an ASP.NET Framework Web Forms app to ASP.NET Core

 :::moniker range=">= aspnetcore-7.0"

---
title: Migrate ASP.NET Web Forms to ASP.NET Core
description: Choose between incremental and full migration approaches for ASP.NET Framework Web Forms applications based on complexity and business requirements.
author: rick-anderson
ms.author: riande
ms.date: 6/20/2025
uid: migration/web_forms
---
# Migrate ASP.NET Framework Web Forms to ASP.NET Core

 :::moniker range=">= aspnetcore-7.0"

Web Forms applications require careful migration planning due to their stateful, page-based architecture. This guide helps you choose between incremental and complete migration approaches based on your application's complexity and business requirements.

## Choose your migration approach

### Incremental migration (recommended for complex Web Forms apps)

**Use incremental migration for Web Forms applications when:**
- Complex business logic is embedded in code-behind files
- Custom user controls require gradual migration and testing
- Authentication and session state cannot be interrupted
- View state and post-back functionality needs preservation during transition
- Large applications where complete rewrite poses significant business risk

**Key benefits for Web Forms:**
- Preserve existing authentication and user management systems
- Maintain critical business functionality during migration
- Allow gradual learning of modern web development patterns
- Reduce deployment risk through systematic migration

### Full migration to modern patterns

**Consider complete migration when:**
- Application has straightforward page structures with minimal complexity
- You want to modernize completely to Razor Pages or MVC patterns
- Business logic can be extracted and restructured efficiently
- Dedicated migration time is available for comprehensive rewrite

## Incremental migration approach

### Prerequisites and preparation

**Assessment requirements:**
- Identify pages with complex code-behind logic
- Catalog custom user controls and their dependencies
- Document authentication and session state requirements
- Evaluate third-party component dependencies

**Tool installation:**
1. Install the [.NET Upgrade Assistant](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant) Visual Studio extension
2. Upgrade supporting libraries to .NET Standard 2.0 when possible for shared usage

### Step 1: Establish proxy architecture

Create the foundation for incremental migration:

1. Open your ASP.NET Web Forms solution in Visual Studio
2. Right-click the project → **Upgrade** → **Side-by-side incremental project upgrade**
3. Select **New project** for upgrade target
4. Choose **ASP.NET Core** template and complete configuration
5. Select target framework version based on your requirements
6. Complete the wizard to establish YARP proxy connection

The migration wizard creates an ASP.NET Core application that initially proxies all requests to your existing Web Forms application. This enables gradual migration while maintaining production availability.

### Step 2: Configure System.Web adapters for Web Forms

Web Forms applications require specific adapter configuration to preserve stateful functionality:

**ASP.NET Core project setup:**

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure System.Web adapters for Web Forms compatibility
builder.Services.AddSystemWebAdapters()
    .AddProxySupport(options => options.UseForwardedHeaders = true)
    .AddRemoteAppAuthentication(isDefault: true)
    .AddRemoteAppSession(isDefault: true)
    .AddJsonSessionSerializer(options =>
    {
        // Register Web Forms-specific session objects
        options.RegisterKey<UserProfile>("UserProfile");
        options.RegisterKey<ViewStateData>("ViewState");
    });

builder.Services.AddRazorPages(); // Target architecture for Web Forms migration

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapRazorPages();
app.MapFallbackToRemoteApp(); // Proxy to Web Forms application

app.Run();
```

### Step 3: Migrate pages incrementally

Start with simple pages and progress to complex business logic:

#### Simple page migration example

**Original Web Forms page (Default.aspx):**
```aspx
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product Catalog</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Products</h1>
            <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
```

**Code-behind (Default.aspx.cs):**
```csharp
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProductsGrid.DataSource = GetProducts();
            ProductsGrid.DataBind();
        }
    }
    
    private List<Product> GetProducts()
    {
        // Business logic to retrieve products
        return productService.GetAllProducts();
    }
}
```

**Migrated Razor Page (Pages/Products/Index.cshtml):**
```html
@page
@model ProductsModel

<h1>Products</h1>
<table class="table">
    <thead>
        <tr>
            <th>Product Name</th>
            <th>Price</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var product in Model.Products)
        {
            <tr>
                <td>@product.Name</td>
                <td>@product.Price.ToString("C")</td>
            </tr>
        }
    </tbody>
</table>
```

**Page model (Pages/Products/Index.cshtml.cs):**
```csharp
public class ProductsModel : PageModel
{
    private readonly IProductService _productService;
    
    public ProductsModel(IProductService productService)
    {
        _productService = productService;
    }
    
    public List<Product> Products { get; set; }
    
    public void OnGet()
    {
        Products = _productService.GetAllProducts();
    }
}
```

#### Handling complex Web Forms patterns

**Session state preservation across migration:**

Many Web Forms applications rely heavily on session state. The incremental approach preserves this functionality:

```csharp
// Web Forms code-behind using session state
public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserData"] != null)
        {
            var userData = (UserData)Session["UserData"];
            DisplayUserInfo(userData);
        }
    }
}

// Migrated Razor Page with session state continuity
public class UserProfileModel : PageModel
{
    public UserData UserData { get; set; }
    
    public void OnGet()
    {
        // Access session state through adapters during migration
        if (System.Web.HttpContext.Current.Session["UserData"] != null)
        {
            UserData = (UserData)System.Web.HttpContext.Current.Session["UserData"];
        }
    }
}
```

**Authentication continuity:**

Preserve existing authentication mechanisms during migration:

**ASP.NET Core configuration for Forms Authentication compatibility:**
```csharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppAuthentication(isDefault: true);

// Later, after migration, replace with ASP.NET Core Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

### Step 4: Migrate custom user controls

Web Forms user controls require systematic conversion to Razor components or partial views:

**Original User Control (ProductSummary.ascx):**
```aspx
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSummary.ascx.cs" Inherits="WebFormsApp.Controls.ProductSummary" %>

<div class="product-summary">
    <h3><asp:Label ID="ProductNameLabel" runat="server"></asp:Label></h3>
    <p>Price: <asp:Label ID="PriceLabel" runat="server"></asp:Label></p>
    <asp:Button ID="AddToCartButton" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" />
</div>
```

**Migrated Partial View (_ProductSummary.cshtml):**
```html
@model Product

<div class="product-summary">
    <h3>@Model.Name</h3>
    <p>Price: @Model.Price.ToString("C")</p>
    <form method="post" asp-page-handler="AddToCart">
        <input type="hidden" asp-for="@Model.Id" name="productId" />
        <button type="submit" class="btn btn-primary">Add to Cart</button>
    </form>
</div>
```

### Step 5: Handle postback and view state patterns

Web Forms postback patterns require conversion to modern form handling:

**Original postback pattern:**
```csharp
protected void SubmitButton_Click(object sender, EventArgs e)
{
    if (Page.IsValid)
    {
        var customer = new Customer
        {
            Name = NameTextBox.Text,
            Email = EmailTextBox.Text
        };
        
        customerService.SaveCustomer(customer);
        Response.Redirect("Success.aspx");
    }
}
```

**Modern form handling pattern:**
```csharp
public class CreateCustomerModel : PageModel
{
    private readonly ICustomerService _customerService;
    
    [BindProperty]
    public Customer Customer { get; set; }
    
    public CreateCustomerModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        await _customerService.SaveCustomerAsync(Customer);
        return RedirectToPage("Success");
    }
}
```

### Step 6: Optimize and modernize

After completing page migration, modernize your ASP.NET Core implementation:

1. **Remove adapter dependencies**: Replace System.Web context usage with ASP.NET Core patterns
2. **Implement modern authentication**: Migrate to ASP.NET Core Identity
3. **Optimize performance**: Leverage ASP.NET Core performance features
4. **Add modern capabilities**: Implement SignalR, API endpoints, or other modern features

## Alternative: Complete migration approach

For applications suitable for comprehensive rewrite:

### Modern architecture patterns for Web Forms migration

**Razor Pages**: Most similar to Web Forms page-based model
**MVC with Views**: Better for complex applications requiring separation of concerns
**Blazor Server**: For applications requiring rich client interactivity
**API + SPA**: For modern single-page application architecture

### Migration strategy for complete rewrite

1. **Architecture decision**: Choose target pattern (Razor Pages, MVC, Blazor)
2. **Business logic extraction**: Extract and refactor business logic from code-behind
3. **Data access modernization**: Implement Entity Framework Core or modern data patterns
4. **UI conversion**: Convert Web Forms controls to modern HTML and CSS
5. **Authentication modernization**: Implement ASP.NET Core Identity

## Web Forms migration best practices

### Planning phase
- **Page complexity assessment**: Identify pages requiring most migration effort
- **User control inventory**: Catalog and prioritize custom control migration
- **Authentication requirements**: Plan authentication migration strategy
- **Session state evaluation**: Determine session state migration approach

### Implementation phase
- **Start with simple pages**: Build confidence and establish patterns
- **Preserve business logic**: Focus on UI migration while preserving business functionality
- **Test incrementally**: Validate each migrated page thoroughly
- **Monitor user experience**: Ensure no functionality degradation

### Optimization phase
- **Performance validation**: Compare performance with original Web Forms application
- **Modern pattern adoption**: Gradually adopt ASP.NET Core best practices
- **Code cleanup**: Remove adapter dependencies and modernize patterns

## Common Web Forms migration challenges

### View state and postback dependencies
**Challenge**: Web Forms applications rely on view state and postback for stateful behavior
**Solution**: Convert to stateless patterns using proper model binding and form handling

### Server control dependencies
**Challenge**: Complex server controls with postback event handling
**Solution**: Migrate to HTML helpers, tag helpers, or custom Razor components

### Master page hierarchies
**Challenge**: Complex master page inheritance structures
**Solution**: Convert to layout pages with proper hierarchy preservation

### Global application events
**Challenge**: Global.asax event handling for application lifecycle
**Solution**: Migrate to ASP.NET Core startup configuration and middleware

## Migration timeline expectations

### Typical Web Forms incremental migration phases

| Phase | Duration | Key Activities |
|-------|----------|----------------|
| Setup and Assessment | 1-2 weeks | Proxy setup, complexity analysis |
| Simple Page Migration | 2-4 weeks | Basic pages without complex logic |
| Business Logic Migration | 4-8 weeks | Complex pages with significant code-behind |
| User Control Migration | 2-4 weeks | Custom controls and reusable components |
| Authentication Migration | 1-2 weeks | Modern authentication implementation |
| Optimization | 2-3 weeks | Performance tuning, adapter removal |

## Next steps

Choose your implementation approach:

### For incremental migration
- [Detailed incremental migration setup](xref:migration/inc/start)
- [Session state migration for Web Forms](xref:migration/inc/session)
- [Authentication migration strategies](xref:migration/inc/remote-authentication)

### For complete migration
- [Razor Pages migration guide](xref:migration/razor-pages)
- [MVC migration from Web Forms](xref:migration/webforms-to-mvc)
- [Blazor migration considerations](xref:migration/blazor)

### Additional resources
- [Web Forms to ASP.NET Core migration case studies](xref:migration/case-studies/webforms)
- [Migration troubleshooting guide](xref:migration/reference/troubleshooting)
- [Performance optimization after migration](xref:migration/reference/performance)

:::moniker-end

[!INCLUDE[](~/migration/mvc/includes/mvc6.md)]
