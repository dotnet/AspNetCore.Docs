---
title: Safe storage of app secrets during developmentin ASP.NET Core
author: rick-anderson
description: Shows how to safely store secrets during development
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 7/14/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/app-secrets
---
# Safe storage of app secrets during development in ASP.NET Core

<a name=security-app-secrets></a>

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Daniel Roth](https://github.com/danroth27), and [Scott Addie](https://scottaddie.com) 

This document shows how you can use the Secret Manager tool in development to keep secrets out of your code. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode. You can instead use the [configuration](../fundamentals/configuration.md) system to read these values from environment variables or from values stored using the Secret Manager tool. The Secret Manager tool helps prevent sensitive data from being checked into source control. The [configuration](../fundamentals/configuration.md) system can read secrets stored with the Secret Manager tool described in this article.

The Secret Manager tool is used only in development. You can safeguard Azure test and production secrets with the [Microsoft Azure Key Vault](https://azure.microsoft.com/services/key-vault/) configuration provider. See [Azure Key Vault configuration provider](https://docs.microsoft.com/aspnet/core/security/key-vault-configuration) for more information.

## Environment variables

To avoid storing app secrets in code or in local configuration files, you store secrets in environment variables. You can setup the [configuration](../fundamentals/configuration.md) framework to read values from environment variables by calling `AddEnvironmentVariables`. You can then use environment variables to override configuration values for all previously specified configuration sources.

For example, if you create a new ASP.NET Core web app with individual user accounts, it will add a default connection string to the *appsettings.json* file in the project with the key `DefaultConnection`. The default connection string is setup to use LocalDB, which runs in user mode and doesn't require a password. When you deploy your application to a test or production server, you can override the `DefaultConnection` key value with an environment variable setting that contains the connection string (potentially with sensitive credentials) for a test or production database server.

>[!WARNING]
> Environment variables are generally stored in plain text and are not encrypted. If the machine or process is compromised, then environment variables can be accessed by untrusted parties. Additional measures to prevent disclosure of user secrets may still be required.

## Secret Manager

The Secret Manager tool stores sensitive data for development work outside of your project tree. The Secret Manager tool is a project tool that can be used to store secrets for a [.NET Core](https://www.microsoft.com/net/core) project during development. With the Secret Manager tool, you can associate app secrets with a specific project and share them across multiple projects.

>[!WARNING]
> The Secret Manager tool does not encrypt the stored secrets and should not be treated as a trusted store. It is for development purposes only. The keys and values are stored in a JSON configuration file in the user profile directory.

### Visual Studio 2017: Installing the Secret Manager tool

Right-click the project in Solution Explorer, and select **Edit \<project_name\>.csproj** from the context menu. 
Add the highlighted line to the *.csproj* file, and save to restore the associated NuGet package:

[!code-xml[Main](app-secrets/sample/UserSecrets/UserSecrets.csproj?highlight=21)]

Right-click the project in Solution Explorer, and select **Manage User Secrets** from the context menu. This gesture adds a new `UserSecretsId` node within a `PropertyGroup` of the *.csproj* file. It also opens a `secrets.json` file in the text editor.

Add the following to `secrets.json`:

```json
{
    "MySecret": "ValueOfMySecret"
}
```

### Visual Studio 2015: Installing the Secret Manager tool

Open the project's `project.json` file. Add a reference to `Microsoft.Extensions.SecretManager.Tools` within the `tools` property, and save to restore the associated NuGet package:

```json
"tools": {
    "Microsoft.Extensions.SecretManager.Tools": "1.0.0-preview2-final",
    "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.0.0-preview2-final"
},
```

Right-click the project in Solution Explorer, and select **Manage User Secrets** from the context menu. This gesture adds a new `userSecretsId` property to `project.json`. It also opens a `secrets.json` file in the text editor.

Add the following to `secrets.json`:

```json
{
    "MySecret": "ValueOfMySecret"
}
```

### Visual Studio Code or Command Line: Installing the Secret Manager tool

Add `Microsoft.Extensions.SecretManager.Tools` to the *.csproj* file and run `dotnet restore`.

[!code-xml[Main](app-secrets/sample/UserSecrets/UserSecrets.csproj?highlight=21)]

Test the Secret Manager tool by running the following command:

```console
dotnet user-secrets -h
```

The Secret Manager tool will display usage, options and command help.

> [!NOTE]
> You must be in the same directory as the *.csproj* file to run tools defined in the *.csproj* file's `DotNetCliToolReference` nodes.

The Secret Manager tool operates on project-specific configuration settings that are stored in your user profile. To use user secrets, the project must specify a `UserSecretsId` value in its *.csproj* file. The value of `UserSecretsId` is arbitrary, but is generally unique to the project. Developers typically generate a GUID for the `UserSecretsId`.

Add a `UserSecretsId` for your project in the *.csproj* file:

[!code-xml[Main](app-secrets/sample/UserSecrets/UserSecrets.csproj?range=7-9&highlight=2)]

Use the Secret Manager tool to set a secret. For example, in a command window from the project directory, enter the following:

```console
dotnet user-secrets set MySecret ValueOfMySecret
```

You can run the Secret Manager tool from other directories, but you must use the `--project` option to pass in the path to the *.csproj* file:
 
```console
dotnet user-secrets set MySecret ValueOfMySecret --project c:\work\WebApp1\src\webapp1
```

You can also use the Secret Manager tool to list, remove and clear app secrets.

## Accessing user secrets via configuration

You access Secret Manager secrets through the configuration system. Add the `Microsoft.Extensions.Configuration.UserSecrets` package and run `dotnet restore`.

Add the user secrets configuration source to the `Startup` method:

[!code-csharp[Main](app-secrets/sample/UserSecrets/Startup.cs?highlight=16-19)]

You can access user secrets via the configuration API:

[!code-csharp[Main](app-secrets/sample/UserSecrets/Startup.cs?highlight=26-29)]

## How the Secret Manager tool works

The Secret Manager tool abstracts away the implementation details, such as where and how the values are stored. You can use the tool without knowing these implementation details. In the current version, the values are stored in a [JSON](http://json.org/) configuration file in the user profile directory:

* Windows: `%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json`

* Linux: `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`

* Mac: `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`

The value of `userSecretsId` comes from the value specified in *.csproj* file.

You should not write code that depends on the location or format of the data saved with the Secret Manager tool, as these implementation details might change. For example, the secret values are currently *not* encrypted today, but could be someday.

## Additional Resources

* [Configuration](../fundamentals/configuration.md)
