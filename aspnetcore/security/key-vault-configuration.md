---
title: Azure Key Vault Configuration Provider | Microsoft Docs
author: guardrex
description: How to use the Azure Key Vault Configuration Provider to configure an application using name-value pairs loaded at runtime.
keywords: ASP.NET Core, configuration, Azure Key Vault
ms.author: riande
manager: wpickett
ms.date: 1/16/2017
ms.topic: article
ms.assetid: 0292bdae-b3ed-4637-bd67-19b9bb8b65cb
ms.prod: aspnet-core
uid: security/key-vault-configuration
---
# Azure Key Vault Configuration Provider

By [Luke Latham](https://github.com/GuardRex) and [Andrew Stanton-Nurse](https://github.com/anurse)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/sample)

This document explains how to use the Azure Key Vault Configuration Provider to load application configuration values from Azure Key Vault. [Microsoft Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/) is a cloud-based service that helps you safeguard cryptographic keys and secrets used by applications and services.

## When to use the provider
Use the provider when your application has access to Azure services and requires encrypted storage of its configuration data. Common scenarios include:
* Controlling access to sensitive configuration data
* Monitoring and logging of configuration data use
* Reducing latency, providing automatic scaling, and providing redundancy of configuration data
* Requirement for FIPS 140-2 Level 2 validated Hardware Security Modules (HSM's) when storing configuration data

## Package
To use the provider, add a reference to the `Microsoft.Extensions.Configuration.AzureKeyVault` package. The provider is available for projects that target .NETFramework 4.5.1 or .NETStandard 1.5 or higher.

## Application configuration
You can explore the provider with the [sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/sample). Once you've established a key vault and created a pair of secrets in the vault by [following the guidance below](#creating-key-vault-secrets-and-loading-configuration-values), the sample application will securely load the secret values into its configuration and display them in a webpage.

The provider is added to the `ConfigurationBuilder` with the `AddAzureKeyVault()` extension. In the sample application, the extension uses three configuration values loaded from the *appsettings.json* file.

App Setting | Description | Example
--- | --- | ---
`Vault` | Azure Key Vault name | contosovault
`ClientId` | Azure Active Directory App Id | 627e911e-43cc-61d4-992e-12db9c81b413
`ClientSecret` | Azure Active Directory App Key | g58K3dtg59o1Pa+e59v2Tx829w6VxTB2yv9sv/101di=

[!code-csharp[Main](key-vault-configuration/sample/Startup.cs?name=snippet1&highlight=5,10-13)]

`AddAzureKeyVault()` contains an overload that accepts an implementation of `IKeyVaultSecretManager`. For example, the interface can be implemented to load configuration values by environment, where you would prefix environment names to configuration secrets you've stored in the key vault. Key vault secrets `Development-ConnectionString` and `Production-ConnectionString` can be loaded from configuration as `ConnectionString`, and the application will take its configuration for the connection string from the secret that matches the application's environment. An example of this implementation is shown below.

```csharp
public class EnvironmentSecretManager : IKeyVaultSecretManager
{
    private readonly string _environmentPrefix;

    public EnvironmentSecretManager(string environment)
    {
        _environmentPrefix = environment + "-";
    }

    public bool Load(SecretItem secret)
    {
        return secret.Identifier.Name.StartsWith(_environmentPrefix);
    }

    public string GetKey(SecretBundle secret)
    {
        return secret.SecretIdentifier.Name.Substring(_environmentPrefix.Length);
    }
}
```

```csharp
builder.AddAzureKeyVault(
    $"https://{config["Vault"]}.vault.azure.net/",
    config["ClientId"],
    config["ClientSecret"],
    new EnvironmentSecretManager(config["ASPNETCORE_ENVIRONMENT"]));
    
Configuration = builder.Build();

// Configuration["ConnectionString"] will be loaded from Development-ConnectionString
// if the environment is Development and Production-ConnectionString if the environment 
// is Production.
```

You can also provide your own `KeyVaultClient` implementation to `AddAzureKeyVault()`. For more information, see [KeyVaultClient Class](https://msdn.microsoft.com/en-us/library/microsoft.azure.keyvault.keyvaultclient.aspx). 

## Creating key vault secrets and loading configuration values
1. Create a key vault and setup Azure Active Directory (Azure AD) for the application following the guidance in [Get started with Azure Key Vault](https://azure.microsoft.com/en-us/documentation/articles/key-vault-get-started/).
  * Create a key vault. The access policy used to connect to the key vault must have `List` and `Get` permissions to secrets.
  * Add "Manual" secrets to the key vault using Azure PowerShell, API, or the Azure Portal.
    * Hierarchical values (configuration sections) use `--` (double-dash) as a separator.
    * "Certificate" secrets are not supported.
    * For the sample application, create two secrets with the following name-value pairs:
      * `MySecret`: `secret_value_1`
      * `Section--MySecret`: `secret_value_2`
  * Register the sample application with Azure Active Directory.
  * Authorize the application to access the key vault.
2. Update the application's *appsettings.json* file with the values of `Vault`, `ClientId`, and `ClientSecret`.
3. Run the sample application, which obtains its configuration values from `IConfigurationRoot` with the same name as the secret name.
  * Non-hierarchical Values: The value for `MySecret` is obtained with `config["MySecret"]`.
  * Hierarchical Values (sections): Use `:` (colon) notation or the `.GetSection()` method.
    * `config["Section:MySecret"]`
    * `config.GetSection("Section")["MySecret"]`

![Browser window showing secret values loaded via the Azure Key Vault Configuration Provider](key-vault-configuration/_static/sample-output.png)

## Reloading secrets
Secrets are cached until `IConfigurationRoot.Reload()` is called. Expired, disabled, and updated secrets are not effective until `Reload()` is executed.

```csharp
Configuration.Reload();
```

## Disabled secrets
Disabled secrets throw an exception at runtime. Therefore, it's important that you update an application to remove or replace a configuration key (name) before you disable its associated key vault secret. If a secret is disabled and the provider attempts to load it, you will receive a `KeyVaultClientException`.

```
KeyVaultClientException: Operation get is not allowed on a disabled secret during reload
```

## Troubleshooting
When the application fails to load configuration using the provider, the logged error message will indicate the problem. The following general conditions can prevent configuration from loading:
* The application has not been configured correctly in Azure Active Directory.
* The key vault doesn't exist in Azure Key Vault.
* The application has not been authorized to access the key vault.
* The access policy doesn't include `Get` and `List` permissions.
* In the key vault, the configuration data (name-value pair) is incorrectly named, missing, disabled, or expired.
* The application has the wrong key vault name (`Vault`), Azure AD App Id (`ClientId`), or Azure AD Key (`ClientSecret`).
* The Azure AD Key (`ClientSecret`) is expired.
* The configuration key (name) is incorrect in the application for the value you're trying to load.

## Additional Resources
* [Configuration](xref:fundamentals/configuration)
* [Microsoft Azure: Key Vault](https://azure.microsoft.com/en-us/services/key-vault/)
* [Microsoft Azure: Key Vault Documentation](https://docs.microsoft.com/en-us/azure/key-vault/)
* [How to generate and transfer HSM-protected keys for Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-hsm-protected-keys)
* [KeyVaultClient Class](https://msdn.microsoft.com/en-us/library/microsoft.azure.keyvault.keyvaultclient.aspx)
