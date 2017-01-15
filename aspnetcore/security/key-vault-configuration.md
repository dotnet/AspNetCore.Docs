---
title: Azure Key Vault Configuration Provider | Microsoft Docs
author: guardrex
description: How to use the Azure Key Vault Configuration Provider to configure an application using name-value pairs loaded at runtime.
keywords: ASP.NET Core, configuration, Azure Key Vault
ms.author: riande
manager: wpickett
ms.date: 1/15/2017
ms.topic: article
ms.assetid: 0292bdae-b3ed-4637-bd67-19b9bb8b65cb
ms.prod: aspnet-core
uid: security/key-vault-configuration
---
# Azure Key Vault Configuration Provider

By [Luke Latham](https://github.com/GuardRex) and [Andrew Stanton-Nurse](https://github.com/anurse)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/sample)

This document provides details on how to use the Azure Key Vault Configuration Provider to configure an application using values loaded from Key Vault Secrets at runtime. [Microsoft Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/) is a cloud-based service that helps you safeguard cryptographic keys and secrets used by applications and services.

## When to use the Azure Key Vault Configuration Provider
Use the Azure Key Vault Configuration Provider when your application is accessible to Azure services and requires encrypted values for configuration. Common scenarios for using encrypted storage of configuration data with Key Vault include:
* Strict control over sensitive configuration data
* When monitoring and logging of configuration data use is required
* To limited the exposure to security threats that compromise application services
* To reduce latency, provide automatic scaling, and provide redundancy for the storage and access of configuration data
* Requirement for FIPS 140-2 Level 2 validated Hardware Security Modules (HSM's)

## Package
To include the configuration provider in your project, add a reference to the `Microsoft.Extensions.Configuration.AzureKeyVault` package. The provider is available for projects that target .NETFramework 4.5.1 or .NETStandard 1.5 or higher.

## Application configuration
You can experience the use of the Azure Key Vault Configuration Provider with the [sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/sample). Once you have established a key vault and created a pair of secrets in the vault, the sample will securely load the secret values into its configuration and display them in a webpage.

The provider is added to the `ConfigurationBuilder` with the `AddAzureKeyVault()` extension. The extension uses three configuration values loaded from the *appsettings.json* file in the sample application: `Vault`, `ClientId`, and `ClientSecret`.

[!code-json[Main](key-vault-configuration/sample/appsettings.json)]

[!code-csharp[Main](key-vault-configuration/sample/Startup.cs?name=snippet1)]

`AddAzureKeyVault()` contains an overload that accepts an implementation of `IKeyVaultSecretManager`. For example, the interface could be implemented to read configuration values by environment, where you would prefix the environment names to the configuration names you store in Key Vault (`Development-ConnectionString` and `Production-ConnectionString`).

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

You can also provide your own `KeyVaultClient` implementation to `AddAzureKeyVault()`, which provides maximum flexibility for how the provider acts.

## Creating key vault secrets and loading/reading configuration
1. Create a key vault by following the guidance at [Get started with Azure Key Vault](https://azure.microsoft.com/en-us/documentation/articles/key-vault-get-started/). Using the guidance, you will perform the following:
  * Create a key vault. The access policy used to connect to the key vault must have `List` and `Get` permissions to secrets.
  * Add "Manual" secrets to the key vault using Azure PowerShell, API, or the Azure Portal.
    * Hierarchical values (configuration sections) use `--` (double-dash) as a separator.
    * For the sample applicaiton, create two secrets with the following values:
      * `MySecret`: `secret_value_1`
      * `Section--MySecret`: `secret_value_2`
    * "Certificate" secrets are not supported.
  * Register the sample application in Azure Active Directory.
  * Authorize the application to access to the key vault.
  * Update the *appsettings.json* file with the values of `Vault`, `ClientId`, and `ClientSecret`.
2. Run the sample application. You obtain a configuration value out of `IConfiguration` with the same name as the secret name.
  * Non-hierarchial Values: The value for `MySecret` is obtained with `config["MySecret"]`.
  * Hierarchical Values (sections): Use `:` (colon) notation or the `.GetSection()` method.
    * `config["Section:MySecret"]`
    * `config.GetSection("Section")["MySecret"]`

![Browser window showing secret values loaded via the Azure Key Vault Configuration Provider](key-vault-configuration/_static/sample-output.png)

## Reloading secrets
Secrets are cached until `IConfigurationRoot.Reload()` is called. Expired, disabled, and updated secrets are not replaced until `Reload()` is called.

## Disabled secrets
Disabled secrets throw an exception at runtime. Therefore, it's important that you update an application to remove or replace a configuration name before you disable a key vault secret.
```
KeyVaultClientException: Operation get is not allowed on a disabled secret during reload
```

## Troubleshooting
* Checking values from Azure (AD & Key Vault)
* Confirm `Get` and `List` permissions for the access policy
* Using PS to make sure the app has access to key vault if `Access Denied` is the error

## Additional Resources
* [Configuration](xref:fundamentals/configuration)
* [Microsoft Azure: Key Vault](https://azure.microsoft.com/en-us/services/key-vault/)
* [Microsoft Azure: Key Vault Documentation](https://docs.microsoft.com/en-us/azure/key-vault/)
* [How to generate and transfer HSM-protected keys for Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-hsm-protected-keys)
