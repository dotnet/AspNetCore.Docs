---
title: Key storage providers in ASP.NET Core
author: rick-anderson
description: Learn about key storage providers in ASP.NET Core and how to configure key storage locations.
ms.author: riande
ms.date: 12/05/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/implementation/key-storage-providers
---
# Key storage providers in ASP.NET Core

The data protection system [employs a discovery mechanism by default](xref:security/data-protection/configuration/default-settings) to determine where cryptographic keys should be persisted. The developer can override the default discovery mechanism and manually specify the location.

> [!WARNING]
> If you specify an explicit key persistence location, the data protection system deregisters the default key encryption at rest mechanism, so keys are no longer encrypted at rest. It's recommended that you additionally [specify an explicit key encryption mechanism](xref:security/data-protection/implementation/key-encryption-at-rest) for production deployments.

## File system

To configure a file system-based key repository, call the <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.PersistKeysToFileSystem%2A> configuration routine as shown below. Provide a <xref:System.IO.DirectoryInfo> pointing to the repository where keys should be stored:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"c:\temp-keys\"));
}
```

The `DirectoryInfo` can point to a directory on the local machine, or it can point to a folder on a network share. If pointing to a directory on the local machine (and the scenario is that only apps on the local machine require access to use this repository), consider using [Windows DPAPI](xref:security/data-protection/implementation/key-encryption-at-rest) (on Windows) to encrypt the keys at rest. Otherwise, consider using an [X.509 certificate](xref:security/data-protection/implementation/key-encryption-at-rest) to encrypt keys at rest.

## Azure Storage

The [Azure.Extensions.AspNetCore.DataProtection.Blobs](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs) package allows storing data protection keys in Azure Blob Storage. Keys can be shared across several instances of a web app. Apps can share authentication cookies or CSRF protection across multiple servers.

To configure the Azure Blob Storage provider, call one of the <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.PersistKeysToAzureBlobStorage%2A> overloads.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToAzureBlobStorage(new Uri("<blob URI including SAS token>"));
}
```

If the web app is running as an Azure service, connection string can be used to authenticate to Azure storage by using [Azure.Storage.Blobs](xref:Azure.Storage.Blobs.BlobContainerClient).

```csharp
string connectionString = "<connection_string>";
string containerName = "my-key-container";
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

// optional - provision the container automatically
await container.CreateIfNotExistsAsync();

services.AddDataProtection()
    .PersistKeysToAzureBlobStorage(container, "keys.xml");
```

> [!NOTE]
> The connection string to your storage account can be found in the Azure Portal under the "Access Keys" section or by running the following CLI command: 
> ```bash
> az storage account show-connection-string --name <account_name> --resource-group <resource_group>
> ```

## Redis

:::moniker range=">= aspnetcore-2.2"

The [Microsoft.AspNetCore.DataProtection.StackExchangeRedis](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.StackExchangeRedis/) package allows storing data protection keys in a Redis cache. Keys can be shared across several instances of a web app. Apps can share authentication cookies or CSRF protection across multiple servers.

:::moniker-end

:::moniker range="< aspnetcore-2.2"

The [Microsoft.AspNetCore.DataProtection.Redis](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Redis/) package allows storing data protection keys in a Redis cache. Keys can be shared across several instances of a web app. Apps can share authentication cookies or CSRF protection across multiple servers.

:::moniker-end

:::moniker range=">= aspnetcore-2.2"

To configure on Redis, call one of the <xref:Microsoft.AspNetCore.DataProtection.StackExchangeRedisDataProtectionBuilderExtensions.PersistKeysToStackExchangeRedis%2A> overloads:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    var redis = ConnectionMultiplexer.Connect("<URI>");
    services.AddDataProtection()
        .PersistKeysToStackExchangeRedis(redis, "DataProtection-Keys");
}
```

:::moniker-end

:::moniker range="< aspnetcore-2.2"

To configure on Redis, call one of the <xref:Microsoft.AspNetCore.DataProtection.RedisDataProtectionBuilderExtensions.PersistKeysToRedis%2A> overloads:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    var redis = ConnectionMultiplexer.Connect("<URI>");
    services.AddDataProtection()
        .PersistKeysToRedis(redis, "DataProtection-Keys");
}
```

:::moniker-end

For more information, see the following topics:

* [StackExchange.Redis ConnectionMultiplexer](https://github.com/StackExchange/StackExchange.Redis/blob/main/docs/Basics.md)
* [Azure Redis Cache](/azure/redis-cache/cache-dotnet-how-to-use-azure-redis-cache#connect-to-the-cache)
* [ASP.NET Core DataProtection samples](https://github.com/dotnet/AspNetCore/tree/2.2.0/src/DataProtection/samples)

## Registry

**Only applies to Windows deployments.**

Sometimes the app might not have write access to the file system. Consider a scenario where an app is running as a virtual service account (such as *w3wp.exe*'s app pool identity). In these cases, the administrator can provision a registry key that's accessible by the service account identity. Call the <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.PersistKeysToRegistry%2A> extension method as shown below. Provide a <xref:Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.RegistryKey%2A> pointing to the location where cryptographic keys should be stored:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToRegistry(Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Sample\keys", true));
}
```

> [!IMPORTANT]
> We recommend using [Windows DPAPI](xref:security/data-protection/implementation/key-encryption-at-rest) to encrypt the keys at rest.

:::moniker range=">= aspnetcore-2.2"

## Entity Framework Core

The [Microsoft.AspNetCore.DataProtection.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.EntityFrameworkCore/) package provides a mechanism for storing data protection keys to a database using Entity Framework Core. The `Microsoft.AspNetCore.DataProtection.EntityFrameworkCore` NuGet package must be added to the project file, it's not part of the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).

With this package, keys can be shared across multiple instances of a web app.

To configure the EF Core provider, call the <xref:Microsoft.AspNetCore.DataProtection.EntityFrameworkCoreDataProtectionExtensions.PersistKeysToDbContext%2A> method:

[!code-csharp[Main](key-storage-providers/sample/Startup.cs?name=snippet&highlight=13-20)]

[!INCLUDE[about the series](~/includes/code-comments-loc.md)]

The generic parameter, `TContext`, must inherit from <xref:Microsoft.EntityFrameworkCore.DbContext> and implement <xref:Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.IDataProtectionKeyContext>:

[!code-csharp[Main](key-storage-providers/sample/MyKeysContext.cs)]

Create the `DataProtectionKeys` table.

# [Visual Studio](#tab/visual-studio)

Execute the following commands in the **Package Manager Console** (PMC) window:

```powershell
Add-Migration AddDataProtectionKeys -Context MyKeysContext
Update-Database -Context MyKeysContext
```

# [.NET Core CLI](#tab/netcore-cli)

Execute the following commands in a command shell:

```dotnetcli
dotnet ef migrations add AddDataProtectionKeys --context MyKeysContext
dotnet ef database update --context MyKeysContext
```

---

`MyKeysContext` is the `DbContext` defined in the preceding code sample. If you're using a `DbContext` with a different name, substitute your `DbContext` name for `MyKeysContext`.

The `DataProtectionKeys` class/entity adopts the structure shown in the following table.

| Property/Field | CLR Type | SQL Type              |
| -------------- | -------- | --------------------- |
| `Id`           | `int`    | `int`, PK, `IDENTITY(1,1)`, not null   |
| `FriendlyName` | `string` | `nvarchar(MAX)`, null |
| `Xml`          | `string` | `nvarchar(MAX)`, null |

:::moniker-end

## Custom key repository

If the in-box mechanisms aren't appropriate, the developer can specify their own key persistence mechanism by providing a custom <xref:Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository>.
