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
* Monitoring and logging of configuration data use is required
* Reducing latency, providing automatic scaling, and providing redundancy for configuration data
* Requirement for FIPS 140-2 Level 2 validated Hardware Security Modules (HSM's) when storing configuration data

## Package
To include the configuration provider in your project, add a reference to the `Microsoft.Extensions.Configuration.AzureKeyVault` package. The provider is available for projects that target .NETFramework 4.5.1 or .NETStandard 1.5 or higher.

## Application configuration
You can explore the Azure Key Vault Configuration Provider with the [sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/sample). Once you've established a key vault and created a pair of secrets in the vault, the sample app will securely load the secret values into its configuration and display them in a webpage.

The provider is added to the `ConfigurationBuilder` with the `AddAzureKeyVault()` extension. In the sample application, the extension uses three configuration values loaded from the *appsettings.json* file: `Vault`, `ClientId`, and `ClientSecret`.

App Setting | Description | Example
--- | --- | ---
`Vault` | Azure Key Vault vault name | contosovault
`ClientId` | Azure Active Directory App Id | 627e911e-43cc-61d4-992e-12db9c81b413
`ClientSecret` | Azure Active Directory Key | g58K3dtg59o1Pa+e59v2Tx829w6VxTB2yv9sv/101di=

[!code-csharp[Main](key-vault-configuration/sample/Startup.cs?name=snippet1&highlight=5,10-13)]

`AddAzureKeyVault()` contains an overload that accepts an implementation of `IKeyVaultSecretManager`. For example, the interface can be implemented to load configuration values by environment, where you would prefix environment names to configuration secrets you store in the key vault. For example, key vault secrets `Development-ConnectionString` and `Production-ConnectionString` can be loaded as `ConnectionString`, and app will take its configuration from the secret that matches the application's environment. An example of this implementation is shown below.

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
// in the vault if the environment is Development and Production-ConnectionString in
// the vault if the environment is Production.
```

You can also provide your own `KeyVaultClient` implementation to `AddAzureKeyVault()`, which provides maximum flexibility for how the provider behaves. For more information, see [KeyVaultClient Class](https://msdn.microsoft.com/en-us/library/microsoft.azure.keyvault.keyvaultclient.aspx). 

## Creating key vault secrets and loading configuration values
1. Create a key vault by following the guidance at [Get started with Azure Key Vault](https://azure.microsoft.com/en-us/documentation/articles/key-vault-get-started/). Using the guidance, you will perform the following:
  * Create a key vault. The access policy used to connect to the key vault must have `List` and `Get` permissions to secrets.
  * Add "Manual" secrets to the key vault using Azure PowerShell, API, or the Azure Portal.
    * Hierarchical values (configuration sections) use `--` (double-dash) as a separator.
    * For the sample application, create two secrets with the following name-value pairs:
      * `MySecret`: `secret_value_1`
      * `Section--MySecret`: `secret_value_2`
    * "Certificate" secrets are not supported.
  * Register the sample application in Azure Active Directory.
  * Authorize the application to access to the key vault.
  * Update the *appsettings.json* file with the values of `Vault`, `ClientId`, and `ClientSecret`.
2. Run the sample application. The app obtains configuration values from `IConfigurationRoot` with the same name as the secret name.
  * Non-hierarchical Values: The value for `MySecret` is obtained with `config["MySecret"]`.
  * Hierarchical Values (sections): Use `:` (colon) notation or the `.GetSection()` method.
    * `config["Section:MySecret"]`
    * `config.GetSection("Section")["MySecret"]`

![Browser window showing secret values loaded via the Azure Key Vault Configuration Provider](key-vault-configuration/_static/sample-output.png)

## Reloading secrets
Secrets are cached until `IConfigurationRoot.Reload()` is called. Expired, disabled, and updated secrets are not replaced until `Reload()` is called.

## Disabled secrets
Disabled secrets throw an exception at runtime. Therefore, it's important that you update an application to remove or replace a configuration key (name) before you disable its associated key vault secret. If a secret is disabled and the provider attempts to load it, you will receive a `KeyVaultClientException`:
```
KeyVaultClientException: Operation get is not allowed on a disabled secret during reload
```

## Troubleshooting
When the application fails to load configuration using the provider, the logged error message will indicate the problem. The following general conditions can prevent configuration from loading:
* The application has not been configured correctly in Azure Active Directory.
* The key vault doen't exist in Azure Key Vault.
* The application has not been authorized to access the key vault.
* The access policy doesn't include `Get` and `List` permissions.
* In the key vault, the configuration data (name-value pair) is incorrectly named, missing, or disabled.
* The configuration key (name) is incorrect in the application.

## Additional Resources
* [Configuration](xref:fundamentals/configuration)
* [Microsoft Azure: Key Vault](https://azure.microsoft.com/en-us/services/key-vault/)
* [Microsoft Azure: Key Vault Documentation](https://docs.microsoft.com/en-us/azure/key-vault/)
* [How to generate and transfer HSM-protected keys for Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-hsm-protected-keys)
* [KeyVaultClient Class](https://msdn.microsoft.com/en-us/library/microsoft.azure.keyvault.keyvaultclient.aspx)
