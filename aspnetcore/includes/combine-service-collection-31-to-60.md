Consider the following `ConfigureServices` method, which registers services and configures options:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.Configure<PositionOptions>(
        Configuration.GetSection(PositionOptions.Position));
    services.Configure<ColorOptions>(
        Configuration.GetSection(ColorOptions.Color));

    services.AddScoped<IMyDependency, MyDependency>();
    services.AddScoped<IMyDependency2, MyDependency2>();

    services.AddRazorPages();
}
```

Related groups of registrations can be moved to an extension method to register services. For example, the configuration services are added to the following class:

```csharp
using ConfigSample.Options;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<PositionOptions>(
                config.GetSection(PositionOptions.Position));
            services.Configure<ColorOptions>(
                config.GetSection(ColorOptions.Color));

            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();
            services.AddScoped<IMyDependency2, MyDependency2>();

            return services;
        }
    }
}
```

The remaining services are registered in a similar class. The following `ConfigureServices` method uses the new extension methods to register the services:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddConfig(Configuration)
            .AddMyDependencyGroup();

    services.AddRazorPages();
}
```

Each `services.Add{GROUP NAME}` extension method adds and potentially configures services. For example, <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> adds the services MVC controllers with views require, and <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A> adds the services Razor Pages requires. We recommend that apps follow the naming convention of creating extension methods in the <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> namespace. Creating extension methods in the `Microsoft.Extensions.DependencyInjection` namespace:

* Encapsulates groups of service registrations.
* Provides convenient [IntelliSense](/visualstudio/ide/using-intellisense) access to the service.
