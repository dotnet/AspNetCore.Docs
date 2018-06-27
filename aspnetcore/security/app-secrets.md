---
title: Safe storage of app secrets in development in ASP.NET Core
author: rick-anderson
description: Learn how to store and retrieve sensitive information as app secrets during the development of an ASP.NET Core app.
ms.author: scaddie
ms.custom: mvc
ms.date: 06/21/2018
uid: security/app-secrets
---
# Safe storage of app secrets in development in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Daniel Roth](https://github.com/danroth27), and [Scott Addie](https://github.com/scottaddie)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/app-secrets/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

This document explains techniques for storing and retrieving sensitive data during the development of an ASP.NET Core app. You should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development or test mode. You can store and protect Azure test and production secrets with the [Azure Key Vault configuration provider](xref:security/key-vault-configuration).

## Environment variables

Environment variables are used to avoid storage of app secrets in code or in local configuration files. Environment variables override configuration values for all previously specified configuration sources.

::: moniker range="<= aspnetcore-1.1"
Configure the reading of environment variable values by calling [AddEnvironmentVariables](/dotnet/api/microsoft.extensions.configuration.environmentvariablesextensions.addenvironmentvariables) in the `Startup` constructor:

[!code-csharp[](app-secrets/samples/1.x/UserSecrets/Startup.cs?name=snippet_StartupConstructor&highlight=10)]
::: moniker-end

Consider an ASP.NET Core web app in which **Individual User Accounts** security is enabled. A default database connection string is included in the project's *appsettings.json* file with the key `DefaultConnection`. The default connection string is for LocalDB, which runs in user mode and doesn't require a password. During app deployment, the `DefaultConnection` key value can be overridden with an environment variable's value. The environment variable may store the complete connection string with sensitive credentials.

> [!WARNING]
> Environment variables are generally stored in plain, unencrypted text. If the machine or process is compromised, environment variables can be accessed by untrusted parties. Additional measures to prevent disclosure of user secrets may be required.

## Secret Manager

The Secret Manager tool stores sensitive data during the development of an ASP.NET Core project. In this context, a piece of sensitive data is an app secret. App secrets are stored in a separate location from the project tree. The app secrets are associated with a specific project or shared across several projects. The app secrets aren't checked into source control.

> [!WARNING]
> The Secret Manager tool doesn't encrypt the stored secrets and shouldn't be treated as a trusted store. It's for development purposes only. The keys and values are stored in a JSON configuration file in the user profile directory.

## How the Secret Manager tool works

The Secret Manager tool abstracts away the implementation details, such as where and how the values are stored. You can use the tool without knowing these implementation details. The values are stored in a JSON configuration file in a system-protected user profile folder on the local machine:

# [Windows](#tab/windows)

File system path:

`%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`

# [macOS](#tab/macos)

File system path:

`~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`

# [Linux](#tab/linux)

File system path:

`~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`

---

In the preceding file paths, replace `<user_secrets_id>` with the `UserSecretsId` value specified in the *.csproj* file.

Don't write code that depends on the location or format of data saved with the Secret Manager tool. These implementation details may change. For example, the secret values aren't encrypted, but could be in the future.

::: moniker range="<= aspnetcore-2.0"
## Install the Secret Manager tool

The Secret Manager tool is bundled with the .NET Core CLI as of .NET Core SDK 2.1.300. For .NET Core SDK versions before 2.1.300, tool installation is necessary.

> [!TIP]
> Run `dotnet --version` from a command shell to see the installed .NET Core SDK version number.

A warning is displayed if the .NET Core SDK being used includes the tool:

```console
The tool 'Microsoft.Extensions.SecretManager.Tools' is now included in the .NET Core SDK. Information on resolving this warning is available at (https://aka.ms/dotnetclitools-in-box).
```

Install the [Microsoft.Extensions.SecretManager.Tools](https://www.nuget.org/packages/Microsoft.Extensions.SecretManager.Tools/) NuGet package in your ASP.NET Core project. For example:

[!code-xml[](app-secrets/samples/1.x/UserSecrets/UserSecrets.csproj?name=snippet_CsprojFile&highlight=13-14)]

Execute the following command in a command shell to validate the tool installation:

```console
dotnet user-secrets -h
```

The Secret Manager tool displays sample usage, options, and command help:

```console
Usage: dotnet user-secrets [options] [command]

Options:
  -?|-h|--help                        Show help information
  --version                           Show version information
  -v|--verbose                        Show verbose output
  -p|--project <PROJECT>              Path to project. Defaults to searching the current directory.
  -c|--configuration <CONFIGURATION>  The project configuration to use. Defaults to 'Debug'.
  --id                                The user secret ID to use.

Commands:
  clear   Deletes all the application secrets
  list    Lists all the application secrets
  remove  Removes the specified user secret
  set     Sets the user secret to the specified value

Use "dotnet user-secrets [command] --help" for more information about a command.
```

> [!NOTE]
> You must be in the same directory as the *.csproj* file to run tools defined in the *.csproj* file's `DotNetCliToolReference` elements.
::: moniker-end

## Set a secret

The Secret Manager tool operates on project-specific configuration settings stored in your user profile. To use user secrets, define a `UserSecretsId` element within a `PropertyGroup` of the *.csproj* file. The value of `UserSecretsId` is arbitrary, but is unique to the project. Developers typically generate a GUID for the `UserSecretsId`.

::: moniker range="<= aspnetcore-1.1"
[!code-xml[](app-secrets/samples/1.x/UserSecrets/UserSecrets.csproj?name=snippet_PropertyGroup&highlight=3)]
::: moniker-end
::: moniker range=">= aspnetcore-2.0"
[!code-xml[](app-secrets/samples/2.x/UserSecrets/UserSecrets.csproj?name=snippet_PropertyGroup&highlight=3)]
::: moniker-end

> [!TIP]
> In Visual Studio, right-click the project in Solution Explorer, and select **Manage User Secrets** from the context menu. This gesture adds a `UserSecretsId` element, populated with a GUID, to the *.csproj* file. Visual Studio opens a *secrets.json* file in the text editor. Replace the contents of *secrets.json* with the key-value pairs to be stored. For example:
> [!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file.md)]

Define an app secret consisting of a key and its value. The secret is associated with the project's `UserSecretsId` value. For example, run the following command from the directory in which the *.csproj* file exists:

```console
dotnet user-secrets set "Movies:ServiceApiKey" "12345"
```

In the preceding example, the colon denotes that `Movies` is an object literal with a `ServiceApiKey` property.

The Secret Manager tool can be used from other directories too. Use the `--project` option to supply the file system path at which the *.csproj* file exists. For example:

```console
dotnet user-secrets set "Movies:ServiceApiKey" "12345" --project "C:\apps\WebApp1\src\WebApp1"
```

## Set multiple secrets

A batch of secrets can be set by piping JSON to the `set` command. In the following example, the *input.json* file's contents are piped to the `set` command.

# [Windows](#tab/windows)

Open a command shell, and execute the following command:

  ```console
  type .\input.json | dotnet user-secrets set
  ```

# [macOS](#tab/macos)

Open a command shell, and execute the following command:

  ```console
  cat ./input.json | dotnet user-secrets set
  ```

# [Linux](#tab/linux)

Open a command shell, and execute the following command:

  ```console
  cat ./input.json | dotnet user-secrets set
  ```

---

## Access a secret

::: moniker range="<= aspnetcore-1.1"
The [ASP.NET Core Configuration API](xref:fundamentals/configuration/index) provides access to Secret Manager secrets. Install the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) NuGet package.

Add the user secrets configuration source with a call to [AddUserSecrets](/dotnet/api/microsoft.extensions.configuration.usersecretsconfigurationextensions.addusersecrets) in the `Startup` constructor:

[!code-csharp[](app-secrets/samples/1.x/UserSecrets/Startup.cs?name=snippet_StartupConstructor&highlight=5-8)]
::: moniker-end
::: moniker range=">= aspnetcore-2.0"
The [ASP.NET Core Configuration API](xref:fundamentals/configuration/index) provides access to Secret Manager secrets. If your project targets the .NET Framework, install the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) NuGet package.

In ASP.NET Core 2.0 or later, the user secrets configuration source is automatically added in development mode when the project calls [CreateDefaultBuilder](/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder) to initialize a new instance of the host with preconfigured defaults. `CreateDefaultBuilder` calls [AddUserSecrets](/dotnet/api/microsoft.extensions.configuration.usersecretsconfigurationextensions.addusersecrets) when the [EnvironmentName](/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.environmentname) is [Development](/dotnet/api/microsoft.aspnetcore.hosting.environmentname.development):

[!code-csharp[](app-secrets/samples/2.x/UserSecrets/Program.cs?name=snippet_CreateWebHostBuilder&highlight=2)]

When `CreateDefaultBuilder` isn't called during host construction, add the user secrets configuration source with a call to [AddUserSecrets](/dotnet/api/microsoft.extensions.configuration.usersecretsconfigurationextensions.addusersecrets) in the `Startup` constructor:

[!code-csharp[](app-secrets/samples/1.x/UserSecrets/Startup.cs?name=snippet_StartupConstructor&highlight=5-8)]
::: moniker-end

User secrets can be retrieved via the `Configuration` API:

::: moniker range="<= aspnetcore-1.1"
[!code-csharp[](app-secrets/samples/1.x/UserSecrets/Startup.cs?name=snippet_StartupClass&highlight=23)]
::: moniker-end
::: moniker range=">= aspnetcore-2.0"
[!code-csharp[](app-secrets/samples/2.x/UserSecrets/Startup.cs?name=snippet_StartupClass&highlight=14)]
::: moniker-end

## String replacement with secrets

Storing passwords in plain text is insecure. For example, a database connection string stored in *appsettings.json* may include a password for the specified user:

[!code-json[](app-secrets/samples/2.x/UserSecrets/appsettings-unsecure.json?highlight=3)]

A more secure approach is to store the password as a secret. For example:

```console
dotnet user-secrets set "DbPassword" "pass123"
```

Remove the `Password` key-value pair from the connection string in *appsettings.json*. For example:

[!code-json[](app-secrets/samples/2.x/UserSecrets/appsettings.json?highlight=3)]

The secret's value can be set on a [SqlConnectionStringBuilder](/dotnet/api/system.data.sqlclient.sqlconnectionstringbuilder) object's [Password](/dotnet/api/system.data.sqlclient.sqlconnectionstringbuilder.password) property to complete the connection string:

::: moniker range="<= aspnetcore-1.1"
[!code-csharp[](app-secrets/samples/1.x/UserSecrets/Startup2.cs?name=snippet_StartupClass&highlight=26-29)]
::: moniker-end
::: moniker range=">= aspnetcore-2.0"
[!code-csharp[](app-secrets/samples/2.x/UserSecrets/Startup2.cs?name=snippet_StartupClass&highlight=14-17)]
::: moniker-end

## List the secrets

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

Run the following command from the directory in which the *.csproj* file exists:

```console
dotnet user-secrets list
```

The following output appears:

```console
Movies:ServiceApiKey = 12345
Movies:ConnectionString = Server=(localdb)\mssqllocaldb;Database=Movie-1;Trusted_Connection=True;MultipleActiveResultSets=true
```

In the preceding example, a colon in the key names denotes the object hierarchy within *secrets.json*.

## Remove a single secret

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

Run the following command from the directory in which the *.csproj* file exists:

```console
dotnet user-secrets remove "Movies:ConnectionString"
```

The app's *secrets.json* file was modified to remove the key-value pair associated with the `MoviesConnectionString` key:

```json
{
  "Movies": {
    "ServiceApiKey": "12345"
  }
}
```

Running `dotnet user-secrets list` displays the following message:

```console
Movies:ServiceApiKey = 12345
```

## Remove all secrets

[!INCLUDE[secrets.json file](~/includes/app-secrets/secrets-json-file-and-text.md)]

Run the following command from the directory in which the *.csproj* file exists:

```console
dotnet user-secrets clear
```

All user secrets for the app have been deleted from the *secrets.json* file:

```json
{}
```

Running `dotnet user-secrets list` displays the following message:

```console
No secrets configured for this application.
```

## Additional resources

* <xref:fundamentals/configuration/index>
* <xref:security/key-vault-configuration>
