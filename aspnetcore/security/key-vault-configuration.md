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

`AddAzureKeyVault()` contains an overload that accepts an implementation of `IKeyVaultSecretManager`. For example, the interface could be implemented to read configuration values by environment, where you would prefix the environment names to the configuration names. The following example would distinguish `Development-ConnectionString` from `Production-ConnectionString` by merely loading the value using `ConnectionString` from configuration.

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

## Creating and loading secrets
* Create a Key Vault
  * https://azure.microsoft.com/en-us/documentation/articles/key-vault-get-started/
  * The Configuration Provider requires that the access policy used to connect to the Key Vault has `List` and `Get` permissions to secrets
  * App in Azure AD must have access to the key vault
  * Add "Manual" secrets to the key vault using Azure PowerShell, API, or Portal
    * Hierarchical values (sections) use `--` as a separator.
    * Test secrets
      * `MySecret`: `Secret_Value_1`
      * `Section--MySecret`: `Secret_Value_2`
    * "Certificate" secrets are not supported
* Getting a configuration setting out of `IConfiguration` with the same name.
  * `MySecret` and an `IConfiguration` or `IConfigurationRoot` instance `config`: `config["MySecret"]`
  * Hierarchical Values (sections)
    * `config["Section:MySecret"]`
    * `config.GetSection("Section")["MySecret"]`
?name=snippet1&highlight=2

[!code-csharp[Main](key-vault-configuration/sample/Startup.cs)]

![Browser window showing secret values loaded via the Azure Key Vault Configuration Provider](key-vault-configuration/_static/sample-output.png)

## Reloading secrets
Secrets are cached until `IConfigurationRoot.Reload()` is called. Expired/disabled/updated secrets are not replaced until `IConfigurationRoot.Reload()` is called.

## Disabled secrets
Disabled secrets throw `KeyVaultClientException: Operation get is not allowed on a disabled secret during reload`.

## Troubleshooting
* Checking values from Azure (AD & Key Vault)
* Confirm `Get` and `List` permissions for the access policy
* Using PS to make sure the app has access to key vault if `Access Denied` is the error

## Additional Resources
* [Configuration](xref:fundamentals/configuration)
* [Microsoft Azure: Key Vault](https://azure.microsoft.com/en-us/services/key-vault/)
* [Microsoft Azure: Key Vault Documentation](https://docs.microsoft.com/en-us/azure/key-vault/)
* [How to generate and transfer HSM-protected keys for Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-hsm-protected-keys)
