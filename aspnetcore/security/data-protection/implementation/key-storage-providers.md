---
title: Key storage providers in ASP.NET Core
author: rick-anderson
description: Learn about key storage providers in ASP.NET Core and how to configure key storage locations.
ms.author: riande
$106/25/2025
uid: security/data-protection/implementation/key-storage-providers
---
<!-- ms.sfi.ropc: t -->
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

The [`Azure.Extensions.AspNetCore.DataProtection.Blobs` NuGet package](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs) provides API for storing data protection keys in Azure Blob Storage. Keys can be shared across several instances of a web app. Apps can share authentication cookies or CSRF protection across multiple servers.

[!INCLUDE[](~/includes/package-reference.md)]

To interact with [Azure Key Vault](https://azure.microsoft.com/services/key-vault/) locally using developer credentials, either sign into your storage account in Visual Studio or sign in with the [Azure CLI](/cli/azure/). If you haven't already installed the Azure CLI, see [How to install the Azure CLI](/cli/azure/install-azure-cli). You can execute the following command in the Developer PowerShell panel in Visual Studio or from a command shell when not using Visual Studio:

```azurecli
az login
```

For more information, see [Sign-in to Azure using developer tooling](/dotnet/azure/sdk/authentication/local-development-dev-accounts#sign-in-to-azure-using-developer-tooling).

Configure Azure Blob Storage to maintain data protection keys:

* Create an Azure storage account.

* Create a container to hold the data protection key file.

* We recommend using Azure Managed Identity and role-based access control (RBAC) to access the key storage blob. ***You don't need to create a key file and upload it to the container of the storage account.*** The framework creates the file for you. To inspect the contents of a key file, use the context menu's **View/edit** command at the end of a key row in the portal.
  
> ![NOTE]
> If you plan to use a blob URI with a shared access signature (SAS) instead of a Managed Identity, use a text editor to create an XML key file on your local machine:
>
>  ```xml
>  <?xml version="1.0" encoding="utf-8"?>
>  <repository>
>  </repository>
>  ```
>
>  Upload the key file to the container of the storage account. Use the context menu's **View/edit** command at the end of the key row in the portal to confirm that the blob contains the preceding content. By creating the file manually, you're able to obtain the blob URI with SAS from the portal for configuring the app in a later step.

* Create an Azure Managed Identity (or add a role to the existing Managed Identity that you plan to use) with the **Storage Blob Data Contributor** role. Assign the Managed Identity to the Azure App Service that's hosting the deployment: **Settings** > **Identity** > **User assigned** > **Add**.

  > [!NOTE]
  > If you also plan to run an app locally with an authorized user for blob access using the [Azure CLI](/cli/azure/) or Visual Studio's Azure Service Authentication, add your developer Azure user account in **Access Control (IAM)** with the **Storage Blob Data Contributor** role. If you want to use the Azure CLI through Visual Studio, execute the `az login` command from the Developer PowerShell panel and follow the prompts to authenticate with the tenant.

To configure the Azure Blob Storage provider, call one of the <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.PersistKeysToAzureBlobStorage%2A> overloads in the app. The following example uses the overload that accepts a blob URI and token credential (<xref:Azure.Core.TokenCredential>), relying on an Azure Managed Identity for role-based access control (RBAC).

Other overloads are based on:

* A blob URI and storage shared key credential (<xref:Azure.Storage.StorageSharedKeyCredential>).
* A blob URI with a shared access signature (SAS).
* A connection string, container name, and blob name.
* A blob client (<xref:Azure.Storage.Blobs.BlobClient>).

For more information on the Azure SDK's API and authentication, see [Authenticate .NET apps to Azure services using the Azure Identity library](/dotnet/azure/sdk/authentication/). For logging guidance, see [Logging with the Azure SDK for .NET: Logging without client registration](/dotnet/azure/sdk/logging#logging-without-client-registration). For apps using dependency injection, an app can call <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClientsCore%2A>, passing `true` for `enableLogForwarding`, to create and wire up the logging infrastructure.

:::moniker range=">= aspnetcore-6.0"

In the `Program` file where services are registered:

```csharp
TokenCredential? credential;

if (builder.Environment.IsProduction())
{
    credential = new ManagedIdentityCredential("{MANAGED IDENTITY CLIENT ID}");
}
else
{
    // Local development and testing only
    DefaultAzureCredentialOptions options = new()
    {
        // Specify the tenant ID to use the dev credentials when running the app locally
        // in Visual Studio.
        VisualStudioTenantId = "{TENANT ID}",
        SharedTokenCacheTenantId = "{TENANT ID}"
    };

    credential = new DefaultAzureCredential(options);
}

builder.Services.AddDataProtection()
    .SetApplicationName("{APPLICATION NAME}")
    .PersistKeysToAzureBlobStorage(new Uri("{BLOB URI}"), credential);
```

`{MANAGED IDENTITY CLIENT ID}`: The Azure Managed Identity Client ID (GUID).

`{TENANT ID}`: Tenant ID.

`{APPLICATION NAME}`: <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetApplicationName%2A> sets the unique name of this app within the data protection system. The value should match across deployments of the app.

`{BLOB URI}`: Full URI to the key file. The URI is generated by Azure Storage when you create the key file. Do not use a SAS.

**Alternative shared-access signature (SAS) approach**: As an alternative to using a Managed Identity for access to the key blob in Azure Blob Storage, you can call the <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.PersistKeysToAzureBlobStorage%2A> overload that accepts a blob URI with a SAS token:

```csharp
builder.Services.AddDataProtection()
    .SetApplicationName("{APPLICATION NAME}")
    .PersistKeysToAzureBlobStorage(new Uri("{BLOB URI WITH SAS}"));
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices`:

```csharp
TokenCredential? credential;

if (_env.IsProduction())
{
    credential = new ManagedIdentityCredential("{MANAGED IDENTITY CLIENT ID}");
}
else
{
    // Local development and testing only
    DefaultAzureCredentialOptions options = new()
    {
        // Specify the tenant ID to use the dev credentials when running the app locally
        // in Visual Studio.
        VisualStudioTenantId = "{TENANT ID}",
        SharedTokenCacheTenantId = "{TENANT ID}"
    };

    credential = new DefaultAzureCredential(options);
}

services.AddDataProtection()
    .SetApplicationName("{APPLICATION NAME}")
    .PersistKeysToAzureBlobStorage(new Uri("{BLOB URI}"), credential);
```

`{MANAGED IDENTITY CLIENT ID}`: The Azure Managed Identity Client ID (GUID).

`{TENANT ID}`: Tenant ID.

`{APPLICATION NAME}`: <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetApplicationName%2A> sets the unique name of this app within the data protection system. The value should match across deployments of the app.

`{BLOB URI}`: Full URI to the key file. The URI is generated by Azure Storage when you create the key file. Do not use a SAS.

Example:

> :::no-loc text="https://contoso.blob.core.windows.net/data-protection/keys.xml":::

**Alternative shared-access signature (SAS) approach**: As an alternative to using a Managed Identity for access to the key blob in Azure Blob Storage, you can call the <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.PersistKeysToAzureBlobStorage%2A> overload that accepts a blob URI with a SAS token:

```csharp
services.AddDataProtection()
    .SetApplicationName("{APPLICATION NAME}")
    .PersistKeysToAzureBlobStorage(new Uri("{BLOB URI WITH SAS}"));
```

:::moniker-end

`{APPLICATION NAME}`: <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetApplicationName%2A> sets the unique name of this app within the data protection system. The value should match across deployments of the app.

`{BLOB URI WITH SAS}`: The full URI where the key file should be stored with the SAS token as a query string parameter. The URI is generated by Azure Storage when you request a SAS for the uploaded key file. In the following example, the container name is `data-protection`, and the storage account name is `contoso`. The key file is named `keys.xml`. The shared access signature (SAS) query string is at the end of the URI (`{SHARED ACCESS SIGNATURE}` placeholder).

Example:

> :::no-loc text="https://contoso.blob.core.windows.net/data-protection/keys.xml{SHARED ACCESS SIGNATURE}":::

If the web app is running as an Azure service, a connection string can be used to authenticate to Azure Storage using <xref:Azure.Storage.Blobs.BlobContainerClient>, as seen in the following example.

[!INCLUDE [managed-identities](~/includes/managed-identities-conn-strings.md)]

The optional call to <xref:Azure.Storage.Blobs.BlobContainerClient.CreateIfNotExistsAsync%2A> provisions the container automatically if it doesn't exist.

The connection string (`{CONNECTION STRING}` placeholder) to the storage account can be found in the Entra or Azure portal under the "Access Keys" section or by running the following Azure CLI command:

```azurecli
az storage account show-connection-string --name <account_name> --resource-group <resource_group>
```

:::moniker range=">= aspnetcore-6.0"

In the `Program` file where services are registered:

```csharp
string connectionString = "{CONNECTION STRING}";
string containerName = "{CONTAINER NAME}";
string blobName = "keys.xml";
var container = new BlobContainerClient(connectionString, containerName);
await container.CreateIfNotExistsAsync();
BlobClient blobClient = container.GetBlobClient(blobName);

builder.Services.AddDataProtection().PersistKeysToAzureBlobStorage(blobClient);
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices`:

```csharp
string connectionString = "{CONNECTION STRING}";
string containerName = "{CONTAINER NAME}";
string blobName = "keys.xml";
var container = new BlobContainerClient(connectionString, containerName);
await container.CreateIfNotExistsAsync();
BlobClient blobClient = container.GetBlobClient(blobName);

services.AddDataProtection().PersistKeysToAzureBlobStorage(blobClient);
```

:::moniker-end

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
* [Azure Redis Cache](/azure/redis/dotnet-how-to-use-azure-redis-cache)
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

# [.NET CLI](#tab/net-cli)

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
