---
title: Azure Key Vault Configuration Provider | Microsoft Docs
author: guardrex
description: How to configure an application using name-value pairs read at runtime from Azure Key Vault.
keywords: ASP.NET Core, configuration, Azure Key Vault
ms.author: riande
manager: wpickett
ms.date: 1/14/2017
ms.topic: article
ms.assetid: 0292bdae-b3ed-4637-bd67-19b9bb8b65cb
ms.prod: aspnet-core
uid: security/key-vault-configuration
---
# Azure Key Vault Configuration Provider

By [Luke Latham](https://github.com/GuardRex) and [Andrew Stanton-Nurse](https://github.com/anurse)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/sample)

This document provides details on ...
* Key Vault is a way to securely store secrets in Azure
* AzureKeyVault configuration provider adds support for reading configuration values out of Azure Key Vault

## Package
`Microsoft.Extensions.Configuration.AzureKeyVault`

## Application configuration
Note sample here.
* `AddAzureKeyVault()`
* Basic configuration (simple implementation using `appsettings.json` file)
* Use of `EnvironmentSecretManager` (described but not in sample)
* Use of `KeyVaultClient` (described but not in sample)

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
