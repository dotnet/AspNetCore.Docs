---
title: Safe storage of app secrets in development
author: tdykstra
description: Learn how to store and retrieve sensitive information during the development of an ASP.NET Core app, including the Secret Manager tool.
ms.author: tdykstra
ms.custom: mvc, sfi-ropc-nochange
monikerRange: '>= aspnetcore-3.0'
ms.date: 05/13/2026
uid: security/app-secrets

# customer intent: As an ASP.NET Core developer, I want to store and retrieve sensitive information during development of my app, so I can ensure my app secrets remain secure.
---
<!-- ms.sfi.ropc: t -->
# Safe storage of app secrets in development in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-6.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Kirk Larkin](https://twitter.com/serpent5)

This article explains how to manage sensitive data for an ASP.NET Core app on a development machine. Never store passwords or other sensitive data in source code or configuration files. Production secrets shouldn't be used for development or test. Secrets shouldn't be deployed with the app. Production secrets should be accessed through a controlled means like Azure Key Vault. Azure test and production secrets can be stored and protected with the [Azure Key Vault configuration provider](xref:security/key-vault-configuration).

[View or download the sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/app-secrets/samples) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

For more information on authentication for deployed test and production apps, see [Secure authentication flows](xref:security/index#secure-authentication-flows).

To use user secrets in a .NET console app, see [GitHub dotnet/entityframework.docs issue #3939](https://github.com/dotnet/EntityFramework.Docs/issues/3939#issuecomment-1191978026).

## Work with environment variables

Environment variables are used to avoid storage of app secrets in code or in local configuration files. Environment variables override configuration values for all previously specified configuration sources.

Consider an ASP.NET Core web app in which **Individual Accounts** security is enabled. A default database connection string is included in the project _appsettings.json_ file with the `DefaultConnection` key. The default connection string is for LocalDB, which runs in user mode and doesn't require a password. During app deployment, you can override the `DefaultConnection` key value with the value from an environment variable. The environment variable might store the complete connection string with sensitive credentials.

> [!WARNING]
> Environment variables are commonly stored as plain, unencrypted text. If the machine or process is compromised, environment variables are accessible to untrusted parties. Extra measures to prevent disclosure of user secrets might be required.

[!INCLUDE[](~/includes/environmentVarableColon.md)]

<a name="secret-manager"></a>

## Use the Secret Manager tool

Secret Manager is a tool that stores sensitive data during application development. In this context, a piece of sensitive data is an _app secret_.

- App secrets are stored in a separate location from the project tree.
- They're associated with a specific project or shared across several projects.
- They aren't checked into source control.

> [!WARNING]
> Secret Manager doesn't encrypt the stored secrets and shouldn't be treated as a trusted store. It's for development purposes only. The keys and values are stored in a JSON configuration file in the user profile directory.

Secret Manager hides implementation details, such as where and how the values are stored. You can use the tool without knowing these implementation details. The values are stored in a JSON file in the local machine's user profile folder:

# [Windows](#tab/windows)

File system path:

`%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`

# [Linux / macOS](#tab/linux+macos)

File system path:

`~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`

---

In the file system path, replace the `<user_secrets_id>` portion with the `UserSecretsId` value specified in your project file.

Don't write code that depends on the location or format of data saved with Secret Manager. These implementation details might change. For example, the secret values aren't encrypted.

## Enable secret storage

Secret Manager operates on project-specific configuration settings stored in your user profile.

### Use the CLI

Secret Manager includes an `init` command. To use user secrets, run the following command in the project directory:

```dotnetcli
dotnet user-secrets init
```

This command adds a `UserSecretsId` element within a `PropertyGroup` of the project file. By default, the inner text of `UserSecretsId` is a GUID. The inner text is arbitrary, but is unique to the project. The following example shows a GUID value of `0000a1a1-b2b2-c3c3-d4d4-eeeeee555555`.

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <UserSecretsId>0000a1a1-b2b2-c3c3-d4d4-eeeeee555555</UserSecretsId>
  </PropertyGroup>

</Project>
```

### Use Visual Studio

In Visual Studio, right-click the project in Solution Explorer, and select **Manage User Secrets** from the context menu. This gesture adds a `UserSecretsId` element, populated with a GUID, to the project file.

### If 'GenerateAssemblyInfo' is false

If the generation of assembly info attributes (`GenerateAssemblyInfo`) is disabled (set to `false`), manually add the <xref:Microsoft.Extensions.Configuration.UserSecrets.UserSecretsIdAttribute> in the _AssemblyInfo.cs_ file. For example:

```csharp
[assembly: UserSecretsId("your_user_secrets_id")]
```

When you manually add the `UserSecretsId` attribute to the _AssemblyInfo.cs_ file, the `UserSecretsId` value must match the value in the project file.

## Set a secret

Define an app secret consisting of a key and its value. The secret is associated with the project's `UserSecretsId` value. For example, run the following command from the directory in which the project file exists:

```dotnetcli
dotnet user-secrets set "Movies:ServiceApiKey" "12345"
```

In this example, the colon indicates that `Movies` is an object literal with a `ServiceApiKey` property.

You can also use Secret Manager from other directories. Include the `--project` option to supply the file system path at which the project file exists. For example:

```dotnetcli
dotnet user-secrets set "Movies:ServiceApiKey" "12345" --project "C:\apps\WebApp1\src\WebApp1"
```

### JSON structure flattening in Visual Studio

The Visual Studio **Manage User Secrets** gesture opens a _secrets.json_ file in the text editor. Replace the contents of the _secrets.json_ file with the key-value pairs to store. For example:

```json
{
  "Movies": {
    "ConnectionString": "Server=(localdb)\\mssqllocaldb;Database=Movie-1;Trusted_Connection=True;MultipleActiveResultSets=true",
    "ServiceApiKey": "12345"
  }
}
```

The JSON structure is flattened after modifications via the `dotnet user-secrets remove` or `dotnet user-secrets set` command. For example, running `dotnet user-secrets remove "Movies:ConnectionString"` collapses the `Movies` object literal. The modified file resembles the following JSON:

```json
{
  "Movies:ServiceApiKey": "12345"
}
```

## Set multiple secrets

A batch of secrets can be set by piping JSON to the `set` command. In the following example, the contents of the _input.json_ file is piped to the `set` command.

# [Windows](#tab/windows)

Run the following command:

```dotnetcli
type .\input.json | dotnet user-secrets set
```

# [Linux / macOS](#tab/linux+macos)

Run the following command in a terminal:

```dotnetcli
cat ./input.json | dotnet user-secrets set
```

---

## Access a secret

To access a secret, complete the following steps:

1. [Register the user secrets configuration source](#register-the-user-secrets-configuration-source).

1. [Read the secret via the Configuration API](#read-the-secret-via-the-configuration-api).

### Register the user secrets configuration source

The user secrets [configuration provider](/dotnet/core/extensions/configuration-providers) registers the appropriate configuration source with the .NET [Configuration API](xref:fundamentals/configuration/index).

ASP.NET Core web apps created with the [dotnet new](/dotnet/core/tools/dotnet-new) command or Visual Studio generate the following code:

[!code-csharp[](~/security/app-secrets/samples/6.x/UserSecrets/Program.cs?name=snippet2&highlight=1)]

The [WebApplication.CreateBuilder](xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A) method initializes a new instance of the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> class with preconfigured defaults. The initialized `WebApplicationBuilder` (`builder`) provides default configuration and calls the <xref:Microsoft.Extensions.Configuration.UserSecretsConfigurationExtensions.AddUserSecrets%2A> method when the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName> property is <xref:Microsoft.Extensions.Hosting.EnvironmentName.Development>.

### Read the secret via the Configuration API

The following examples demonstrate how to read the `Movies:ServiceApiKey` key:

**Program.cs file**

[!code-csharp[](~/security/app-secrets/samples/6.x/UserSecrets/Program.cs?name=snippet_s2&highlight=2)]

**Razor Pages page model**

[!code-csharp[](~/security/app-secrets/samples/6.x/UserSecrets/Pages/Index.cshtml.cs?name=snippet_PageModel&highlight=12)]

For more information, see <xref:fundamentals/configuration/index>.

## Map secrets to a POCO

Mapping an entire object literal to a POCO (a simple .NET class with properties) is useful for aggregating related properties.

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

To map the preceding secrets to a POCO, use the .NET Configuration API's [object graph binding](xref:fundamentals/configuration/index#bind-an-array) feature. The following code binds to a custom `MovieSettings` POCO and accesses the `ServiceApiKey` property value:

[!code-csharp[](~/security/app-secrets/samples/3.x/UserSecrets/Startup3.cs?name=snippet_BindToObjectGraph)]

The `Movies:ConnectionString` and `Movies:ServiceApiKey` secrets are mapped to the respective properties in `MovieSettings`:

[!code-csharp[](~/security/app-secrets/samples/3.x/UserSecrets/Models/MovieSettings.cs?name=snippet_MovieSettingsClass)]

## Use string replacement with secrets

Storing passwords in plain text is insecure. Never store secrets in a configuration file such as _appsettings.json_, which might get checked in to a source code repository.

For example, a database connection string stored in an _appsettings.json_ file shouldn't include a password. Instead, store the password as a secret, and include the password in the connection string at runtime. For example:

```dotnetcli
dotnet user-secrets set "DbPassword" "`<secret value>`"
```

Replace the `<secret value>` placeholder in the example with the password value. Set the secret's value on a <xref:System.Data.SqlClient.SqlConnectionStringBuilder> object's <xref:System.Data.SqlClient.SqlConnectionStringBuilder.Password%2A> property to include it as the password value in the connection string:

[!code-csharp[](~/security/app-secrets/samples/6.x/UserSecrets/Program.cs?name=snippet_sql&highlight=5-8)]

## List the secrets

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

Run the following command from the directory in which the project file exists:

```dotnetcli
dotnet user-secrets list
```

The following output appears:

```console
Movies:ConnectionString = Server=(localdb)\mssqllocaldb;Database=Movie-1;Trusted_Connection=True;MultipleActiveResultSets=true
Movies:ServiceApiKey = 12345
```

In the example, a colon (`:`) in the key names denotes the object hierarchy within the _secrets.json_ file.

## Remove a single secret

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

Run the following command from the directory in which the project file exists:

```dotnetcli
dotnet user-secrets remove "Movies:ConnectionString"
```

The application _secrets.json_ file is modified to remove the key-value pair associated with the `Movies:ConnectionString` key:

```json
{
  "Movies": {
    "ServiceApiKey": "12345"
  }
}
```

The `dotnet user-secrets list` command displays the following message:

```console
Movies:ServiceApiKey = 12345
```

## Remove all secrets

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

Run the following command from the directory in which the project file exists:

```dotnetcli
dotnet user-secrets clear
```

All user secrets for the app are deleted from the _secrets.json_ file:

```json
{}
```

Running the `dotnet user-secrets list` command displays the following message:

```console
No secrets configured for this application.
```

## Manage user secrets with Visual Studio

To manage user secrets in Visual Studio, right-click the project in Solution Explorer and select **Manage User Secrets**:

:::image type="content" source="~/security/app-secrets/_static/usvs.png" alt-text="Screenshot shows how to select the Manage User Secrets option in Visual Studio.":::

## Migrate user secrets from ASP.NET Framework to ASP.NET Core

You can migrate your stored user secrets from ASP.NET Framework to ASP.NET Core. For more information, see [GitHub dotnet/aspnetcore.docs issue #27611](https://github.com/dotnet/AspNetCore.Docs/issues/27611) - _User Secrets documentation doesn't mention incompatibility with AssemblyInfo.cs_.

## Work with user secrets in nonweb applications 

Projects that target `Microsoft.NET.Sdk.Web` automatically include support for user secrets. For projects that target `Microsoft.NET.Sdk`, such as console applications, install the configuration extension and user secrets NuGet packages explicitly.

# [Azure PowerShell](#tab/azure-powershell)

```powershell
Install-Package Microsoft.Extensions.Configuration
Install-Package Microsoft.Extensions.Configuration.UserSecrets
```

# [.NET CLI](#tab/net-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```

---

After you install the packages, [initialize the project](#enable-secret-storage) and [set secrets](#set-a-secret) the same way as for a web app. The following example shows a console application that retrieves the value of a secret set with the `AppSecret` key:

```csharp
using Microsoft.Extensions.Configuration;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        Console.WriteLine(config["AppSecret"]);
    }
}
```

## Related content

* [GitHub dotnet/aspnetcore.docs issue #30378 (Debugging under Internet Information Services (IIS))](https://github.com/dotnet/AspNetCore.Docs/issues/30378)
* [GitHub dotnet/aspnetcore.docs issue #16328 (Running in IIS)](https://github.com/dotnet/AspNetCore.Docs/issues/16328)
* <xref:fundamentals/configuration/index>
* <xref:security/key-vault-configuration>

:::moniker-end

[!INCLUDE[](~/security/app-secrets/includes/app-secrets-3-5.md)]
