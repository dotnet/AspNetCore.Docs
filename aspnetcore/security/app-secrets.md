---
title: Safe storage of app secrets in development in ASP.NET Core
author: rick-anderson
description: Learn how to safely store sensitive information as app secrets during development of an ASP.NET Core app.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 05/15/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: security/app-secrets
---
# Safe storage of app secrets in development in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Daniel Roth](https://github.com/danroth27), and [Scott Addie](https://scottaddie.com)

::: moniker range="<= aspnetcore-1.1"
[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/app-secrets/samples/1.1) ([how to download](xref:tutorials/index#how-to-download-a-sample))
::: moniker-end
::: moniker range=">= aspnetcore-2.0"
[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/app-secrets/samples/2.1) ([how to download](xref:tutorials/index#how-to-download-a-sample))
::: moniker-end

This document demonstrates using the Secret Manager tool in development to keep secrets out of your code. You should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development or test mode. You can instead use the [configuration](xref:fundamentals/configuration/index) system to read these values from environment variables or from values stored using the Secret Manager tool. The Secret Manager tool helps prevent sensitive data from being checked into source control. The [configuration](xref:fundamentals/configuration/index) system can read secrets stored with the Secret Manager tool.

> [!IMPORTANT]
> The Secret Manager tool is used only in development. You can safeguard Azure test and production secrets with the [Azure Key Vault configuration provider](xref:security/key-vault-configuration).

## Environment variables

To avoid storing app secrets in code or in local configuration files, store secrets in environment variables. Environment variables can be used to override configuration values for all previously specified configuration sources.

::: moniker range="<= aspnetcore-1.1"
Configure the reading of environment variable values by calling [AddEnvironmentVariables](/dotnet/api/microsoft.extensions.configuration.environmentvariablesextensions.addenvironmentvariables) in the `Startup` constructor:

[!code-csharp[](app-secrets/samples/1.1/UserSecrets/Startup.cs?name=snippet_StartupConstructor&highlight=10)]
::: moniker-end

Imagine an ASP.NET Core web app with Individual User Accounts enabled. A default connection string is included in the project's *appsettings.json* file with the key `DefaultConnection`. The default connection string is for LocalDB, which runs in user mode and doesn't require a password. During app deployment, the `DefaultConnection` key value can be overridden with an environment variable's value. The environment variable may contain the database connection string with sensitive credentials.

> [!WARNING]
> Environment variables are generally stored in plain, unencrypted text. If the machine or process is compromised, then environment variables can be accessed by untrusted parties. Additional measures to prevent disclosure of user secrets may still be required.

## Secret Manager

The Secret Manager tool stores sensitive data for development work outside of your project tree. The Secret Manager tool is a project tool that can be used to store secrets for a .NET Core project during development. With the Secret Manager tool, app secrets can be associated with a specific project and shared across multiple projects.

> [!WARNING]
> The Secret Manager tool doesn't encrypt the stored secrets and shouldn't be treated as a trusted store. It's for development purposes only. The keys and values are stored in a JSON configuration file in the user profile directory.

## Install the Secret Manager tool

The Secret Manager tool is bundled with the .NET Core CLI as of version 2.1 of the .NET Core SDK. If you're using an earlier version of the .NET Core SDK, install the tool with the following instructions.

# [Visual Studio](#tab/visual-studio/)

* Right-click the project in Solution Explorer, and select **Edit \<project_name\>.csproj** from the context menu.
* Add the highlighted element to the *.csproj* file, and save to restore the [Microsoft.Extensions.SecretManager.Tools](https://www.nuget.org/packages/Microsoft.Extensions.SecretManager.Tools/) NuGet package:

    [!code-xml[](app-secrets/samples/1.1/UserSecrets/UserSecrets-before.csproj?highlight=13-14)]

* Run the following command in the **Package Manager Console** window to validate the tool installation:

    ```console
    dotnet user-secrets -h
    ```

# [Visual Studio Code](#tab/visual-studio-code/)

* Add the highlighted element to the *.csproj* file:

    [!code-xml[](app-secrets/samples/1.1/UserSecrets/UserSecrets-before.csproj?highlight=13-14)]

* Run [dotnet restore](/dotnet/core/tools/dotnet-restore) in the **Integrated Terminal** to install the [Microsoft.Extensions.SecretManager.Tools](https://www.nuget.org/packages/Microsoft.Extensions.SecretManager.Tools/) NuGet package.
* Run the following command in the **Integrated Terminal** to validate the tool installation:

    ```console
    dotnet user-secrets -h
    ```

---

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

## How the Secret Manager tool works

The Secret Manager tool abstracts away the implementation details, such as where and how the values are stored. You can use the tool without knowing these implementation details. The values are stored in a [JSON](https://json.org/) configuration file in a system-protected user profile folder on the local machine:

* Windows: `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`
* Linux & macOS: `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`

In the preceding file paths, replace `<user_secrets_id>` with the `UserSecretsId` value specified in the *.csproj* file.

Don't write code that depends on the location or format of data saved with the Secret Manager tool. These implementation details are subject to change. For example, the secret values aren't encrypted, but could be in the future.

## Set a secret

The Secret Manager tool operates on project-specific configuration settings stored in your user profile. To use user secrets, a `UserSecretsId` element must be defined in the *.csproj* file. The value of `UserSecretsId` is arbitrary, but is unique to the project. Developers typically generate a GUID for the `UserSecretsId`.

# [Visual Studio](#tab/visual-studio/)

Right-click the project in Solution Explorer, and select **Manage User Secrets** from the context menu. This gesture adds a `UserSecretsId` element within a `PropertyGroup` of the *.csproj* file:

  ::: moniker range="<= aspnetcore-1.1"
  [!code-xml[](app-secrets/samples/1.1/UserSecrets/UserSecrets-after.csproj?name=snippet_PropertyGroup&highlight=3)]
  ::: moniker-end
  ::: moniker range=">= aspnetcore-2.0"
  [!code-xml[](app-secrets/samples/2.1/UserSecrets/UserSecrets.csproj?name=snippet_PropertyGroup&highlight=3)]
  ::: moniker-end

Saving the modified *.csproj* file opens a *secrets.json* file in the text editor. Replace the contents of the *secrets.json* file with the following code:

  ```json
  {
    "MySecret": "<secret_value>"
  }
  ```

# [Visual Studio Code](#tab/visual-studio-code/)

Add a `UserSecretsId` element to the *.csproj* file:

  ::: moniker range="<= aspnetcore-1.1"
  [!code-xml[](app-secrets/samples/1.1/UserSecrets/UserSecrets-after.csproj?name=snippet_PropertyGroup&highlight=3)]
  ::: moniker-end
  ::: moniker range=">= aspnetcore-2.0"
  [!code-xml[](app-secrets/samples/2.1/UserSecrets/UserSecrets.csproj?name=snippet_PropertyGroup&highlight=3)]
  ::: moniker-end

Using the **Integrated Terminal**, navigate to the directory in which the *.csproj* file exists. Run the following command to define a secret and its value:

  ```console
  dotnet user-secrets set <secret_name> <secret_value>
  ```

You can run the Secret Manager tool from other directories too. Use the `--project` option to supply the *.csproj* file path. For example:

  ```console
  dotnet user-secrets set <secret_name> <secret_value> --project <folder_path>
  ```

---

## Access a secret

The ASP.NET Core configuration system allows you to access Secret Manager secrets. If targeting .NET Core 1.x or .NET Framework, install the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) NuGet package.

::: moniker range="<= aspnetcore-1.1"
Add the user secrets configuration source to the `Startup` constructor:

[!code-csharp[](app-secrets/samples/1.1/UserSecrets/Startup.cs?name=snippet_StartupConstructor&highlight=5-8)]
::: moniker-end

User secrets can be retrieved via the `Configuration` API:

::: moniker range="<= aspnetcore-1.1"
[!code-csharp[](app-secrets/samples/1.1/UserSecrets/Startup.cs?name=snippet_StartupClass&highlight=21)]
::: moniker-end
::: moniker range=">= aspnetcore-2.0"
[!code-csharp[](app-secrets/samples/2.1/UserSecrets/Startup.cs?name=snippet_StartupClass&highlight=14)]
::: moniker-end

## List the secrets

Assume the app's *secrets.json* file contains the following content:

```json
{
  "MoviesApiKey": "12345",
  "MoviesConnectionString": "Server=(localdb)\\mssqllocaldb;Database=Movie-1;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Run the following command from the directory in which the *.csproj* file exists:

```console
dotnet user-secrets list
```

The following output appears:

```console
MoviesConnectionString = Server=(localdb)\mssqllocaldb;Database=Movie-1;Trusted_Connection=True;MultipleActiveResultSets=true
MoviesApiKey = 12345
```

## Remove a single secret

Run the following command from the directory in which the *.csproj* file exists:

```console
dotnet user-secrets remove MoviesConnectionString
```

The app's *secrets.json* file was modified to remove the key-value pair associated with the `MoviesConnectionString` key:

```json
{
  "MoviesApiKey": "12345"
}
```

Running `dotnet user-secrets list` displays the following message:

```console
MoviesApiKey = 12345
```

## Remove all secrets

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
