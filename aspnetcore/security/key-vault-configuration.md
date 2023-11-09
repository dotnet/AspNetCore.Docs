---
title: Azure Key Vault configuration provider in ASP.NET Core
author: rick-anderson
description: Learn how to use the Azure Key Vault configuration provider to configure an app using name-value pairs loaded at runtime.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, devx-track-azurecli, contperf-fy21q3
ms.date: 01/07/2022
uid: security/key-vault-configuration
---
# Azure Key Vault configuration provider in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

This article explains how to use the [Azure Key Vault](/azure/key-vault/) configuration provider to load app configuration values from Azure Key Vault secrets. Azure Key Vault is a cloud-based service that helps safeguard cryptographic keys and secrets used by apps and services. Common scenarios for using Azure Key Vault with ASP.NET Core apps include:

* Controlling access to sensitive configuration data.
* Meeting the requirement for FIPS 140-2 Level 2 validated Hardware Security Modules (HSMs) when storing configuration data.

## Packages

Add package references for the following packages:

* [Azure.Extensions.AspNetCore.Configuration.Secrets](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets)
* [Azure.Identity](https://www.nuget.org/packages/Azure.Identity)

## Sample app

The sample app runs in either of two modes determined by the `#define` preprocessor directive at the top of `Program.cs`:

* `Certificate`: Demonstrates using an Azure Key Vault Client ID and X.509 certificate to access secrets stored in Azure Key Vault. This sample can be run from any location, whether deployed to Azure App Service or any host that can serve an ASP.NET Core app.
* `Managed`: Demonstrates how to use [Managed identities for Azure resources](/azure/active-directory/managed-identities-azure-resources/overview). The managed identity authenticates the app to Azure Key Vault with Azure Active Directory (AD) authentication without storing credentials in the app's code or configuration. The `Managed` version of the sample must be deployed to Azure. Follow the guidance in the [Use the managed identities for Azure resources](#use-managed-identities-for-azure-resources) section.

For more information configuring a sample app using preprocessor directives (`#define`), see <xref:index#preprocessor-directives-in-sample-code>.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/key-vault-configuration/samples) ([how to download](xref:index#how-to-download-a-sample))

## Secret storage in the Development environment

Set secrets locally using [Secret Manager](xref:security/app-secrets). When the sample app runs on the local machine in the Development environment, secrets are loaded from the local user secrets store.

Secret Manager requires a `<UserSecretsId>` property in the app's project file. Set the property value (`{GUID}`) to any unique GUID:

```xml
<PropertyGroup>
  <UserSecretsId>{GUID}</UserSecretsId>
</PropertyGroup>
```

Secrets are created as name-value pairs. Hierarchical values (configuration sections) use a `:` (colon) as a separator in [ASP.NET Core configuration](xref:fundamentals/configuration/index) key names.

Secret Manager is used from a command shell opened to the project's [content root](xref:fundamentals/index#content-root), where `{SECRET NAME}` is the name and `{SECRET VALUE}` is the value:

```dotnetcli
dotnet user-secrets set "{SECRET NAME}" "{SECRET VALUE}"
```

Execute the following commands in a command shell from the project's [content root](xref:fundamentals/index#content-root) to set the secrets for the sample app:

```dotnetcli
dotnet user-secrets set "SecretName" "secret_value_1_dev"
dotnet user-secrets set "Section:SecretName" "secret_value_2_dev"
```

When these secrets are stored in Azure Key Vault in the [Secret storage in the Production environment with Azure Key Vault](#secret-storage-in-the-production-environment-with-azure-key-vault) section, the `_dev` suffix is changed to `_prod`. The suffix provides a visual cue in the app's output indicating the source of the configuration values.

## Secret storage in the Production environment with Azure Key Vault

Complete the following steps to create an Azure Key Vault and store the sample app's secrets in it. For more information, see [Quickstart: Set and retrieve a secret from Azure Key Vault using Azure CLI](/azure/key-vault/quick-create-cli).

1. Open Azure Cloud Shell using any one of the following methods in the [Azure portal](https://portal.azure.com/):

   * Select **Try It** in the upper-right corner of a code block. Use the search string "Azure CLI" in the text box.
   * Open Cloud Shell in your browser with the **Launch Cloud Shell** button.
   * Select the **Cloud Shell** button on the menu in the upper-right corner of the Azure portal.

   For more information, see [Azure CLI](/cli/azure/) and [Overview of Azure Cloud Shell](/azure/cloud-shell/overview).

1. If you aren't already authenticated, sign in with the `az login` command.

1. Create a resource group with the following command, where `{RESOURCE GROUP NAME}` is the new resource group's name and `{LOCATION}` is the Azure region:

   ```azurecli
   az group create --name "{RESOURCE GROUP NAME}" --location {LOCATION}
   ```

1. Create a Key Vault in the resource group with the following command, where `{KEY VAULT NAME}` is the new vault's name and `{LOCATION}` is the Azure region:

   ```azurecli
   az keyvault create --name {KEY VAULT NAME} --resource-group "{RESOURCE GROUP NAME}" --location {LOCATION}
   ```

1. Create secrets in the vault as name-value pairs.

   Azure Key Vault secret names are limited to alphanumeric characters and dashes. Hierarchical values (configuration sections) use `--` (two dashes) as a delimiter, as colons aren't allowed in Key Vault secret names. Colons delimit a section from a subkey in [ASP.NET Core configuration](xref:fundamentals/configuration/index). The two-dash sequence is replaced with a colon when the secrets are loaded into the app's configuration.

   The following secrets are for use with the sample app. The values include a `_prod` suffix to distinguish them from the `_dev` suffix values loaded in the Development environment from Secret Manager. Replace `{KEY VAULT NAME}` with the name of the Key Vault you created in the prior step:

   ```azurecli
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "SecretName" --value "secret_value_1_prod"
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "Section--SecretName" --value "secret_value_2_prod"
   ```

## Use Application ID and X.509 certificate for non-Azure-hosted apps

Configure Azure AD, Azure Key Vault, and the app to use an Azure AD Application ID and X.509 certificate to authenticate to a vault **when the app is hosted outside of Azure**. For more information, see [About keys, secrets, and certificates](/azure/key-vault/about-keys-secrets-and-certificates).

> [!NOTE]
> Although using an Application ID and X.509 certificate is supported for apps hosted in Azure, it's not recommended. Instead, use [Managed identities for Azure resources](#use-managed-identities-for-azure-resources) when hosting an app in Azure. Managed identities don't require storing a certificate in the app or in the development environment.

The sample app uses an Application ID and X.509 certificate when the `#define` preprocessor directive at the top of `Program.cs` is set to `Certificate`.

1. Create a PKCS#12 archive (*.pfx*) certificate. Options for creating certificates include [New-SelfSignedCertificate on Windows](/powershell/module/pki/new-selfsignedcertificate) and [OpenSSL](https://www.openssl.org/).
1. Install the certificate into the current user's personal certificate store. Marking the key as exportable is optional. Note the certificate's thumbprint, which is used later in this process.
1. Export the PKCS#12 archive (*.pfx*) certificate as a DER-encoded certificate (*.cer*).
1. Register the app with Azure AD (**App registrations**).
1. Upload the DER-encoded certificate (*.cer*) to Azure AD:
   1. Select the app in Azure AD.
   1. Navigate to **Certificates & secrets**.
   1. Select **Upload certificate** to upload the certificate, which contains the public key. A *.cer*, *.pem*, or *.crt* certificate is acceptable.
1. Store the Key Vault name, Application ID, and certificate thumbprint in the app's `appsettings.json` file.
1. Navigate to **Key Vaults** in the Azure portal.
1. Select the Key Vault you created in the [Secret storage in the Production environment with Azure Key Vault](#secret-storage-in-the-production-environment-with-azure-key-vault) section.
1. Select **Access policies**.
1. Select **Add Access Policy**.
1. Open **Secret permissions** and provide the app with **Get** and **List** permissions.
1. Select **Select principal** and select the registered app by name. Select the **Select** button.
1. Select **OK**.
1. Select **Save**.
1. Deploy the app.

The `Certificate` sample app obtains its configuration values from <xref:Microsoft.Extensions.Configuration.IConfigurationRoot> with the same name as the secret name:

* Non-hierarchical values: The value for `SecretName` is obtained with `config["SecretName"]`.
* Hierarchical values (sections): Use `:` (colon) notation or the <xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A> method. Use either of these approaches to obtain the configuration value:
  * `config["Section:SecretName"]`
  * `config.GetSection("Section")["SecretName"]`

The X.509 certificate is managed by the OS. The app calls <xref:Microsoft.Extensions.Configuration.AzureKeyVaultConfigurationExtensions.AddAzureKeyVault%2A> with values supplied by the `appsettings.json` file:

:::code language="csharp" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Program.cs" id="snippet_Certificate":::

Example values:

* Key Vault name: `contosovault`
* Application ID: `627e911e-43cc-61d4-992e-12db9c81b413`
* Certificate thumbprint: `fe14593dd66b2406c5269d742d04b6e1ab03adb1`

`appsettings.json`:

:::code language="json" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/appsettings.json":::

When you run the app, a webpage shows the loaded secret values. In the Development environment, secret values load with the `_dev` suffix. In the Production environment, the values load with the `_prod` suffix.

## Use managed identities for Azure resources

**An app deployed to Azure** can take advantage of [Managed identities for Azure resources](/azure/active-directory/managed-identities-azure-resources/overview). A managed identity allows the app to authenticate with Azure Key Vault using Azure AD authentication without storing credentials in the app's code or configuration.

The sample app uses a system-assigned managed identity when the `#define` preprocessor directive at the top of `Program.cs` is set to `Managed`. To create a managed identity for an Azure App Service app, see [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity). Once the managed identity has been created, note the app's Object ID shown in the Azure portal on the **Identity** panel of the App Service.

Enter the vault name into the app's `appsettings.json` file. The sample app doesn't require an Application ID and Password (Client Secret) when set to the `Managed` version, so you can ignore those configuration entries. The app is deployed to Azure, and Azure authenticates the app to access Azure Key Vault only using the vault name stored in the `appsettings.json` file.

Deploy the sample app to Azure App Service.

Using Azure CLI and the app's Object ID, provide the app with `list` and `get` permissions to access the vault:

```azurecli
az keyvault set-policy --name {KEY VAULT NAME} --object-id {OBJECT ID} --secret-permissions get list
```

**Restart the app** using Azure CLI, PowerShell, or the Azure portal.

The sample app creates an instance of the <xref:Azure.Identity.DefaultAzureCredential> class. The credential attempts to obtain an access token from environment for Azure resources:

:::code language="csharp" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Program.cs" id="snippet_Managed":::

Key Vault name example value: `contosovault`

`appsettings.json`:

```json
{
  "KeyVaultName": "Key Vault Name"
}
```

For apps that use a user-assigned managed identity, configure the managed identity's Client ID using one of the following approaches:

1. Set the `AZURE_CLIENT_ID` environment variable.
1. Set the <xref:Azure.Identity.DefaultAzureCredentialOptions.ManagedIdentityClientId%2A?displayProperty=nameWithType> property when calling `AddAzureKeyVault`:

   :::code language="csharp" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Snippets/Program.cs" id="snippet_AddAzureKeyVaultManagedIdentityClientId" highlight="5":::

When you run the app, a webpage shows the loaded secret values. In the Development environment, secret values have the `_dev` suffix because they're provided by Secret Manager. In the Production environment, the values load with the `_prod` suffix because they're provided by Azure Key Vault.

If you receive an `Access denied` error, confirm that the app is registered with Azure AD and provided access to the vault. Confirm that you've restarted the service in Azure.

For information on using the provider with a managed identity and Azure Pipelines, see [Create an Azure Resource Manager service connection to a VM with a managed service identity](/azure/devops/pipelines/library/connect-to-azure#create-an-azure-resource-manager-service-connection-to-a-vm-with-a-managed-service-identity).

## Configuration options

`AddAzureKeyVault` can accept an <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions> object:

:::code language="csharp" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Snippets/Program.cs" id="snippet_AddAzureKeyVaultConfigurationOptions":::

The `AzureKeyVaultConfigurationOptions` object contains the following properties:

| Property                                                                                                    | Description                                                                                                                           |
|-------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions.Manager%2A>        | <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager> instance used to control secret loading.               |
| <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions.ReloadInterval%2A> | `TimeSpan` to wait between attempts at polling the vault for changes. The default value is `null` (configuration isn't reloaded). |

## Use a key name prefix

`AddAzureKeyVault` provides an overload that accepts an implementation of <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager>, which allows you to control how Key Vault secrets are converted into configuration keys. For example, you can implement the interface to load secret values based on a prefix value you provide at app startup. This technique allows you, for example, to load secrets based on the version of the app.

> [!WARNING]
> Don't use prefixes on Key Vault secrets to:
>
> * Place secrets for multiple apps into the same vault.
> * Place environmental secrets (for example, *development* versus *production* secrets) into the same vault.
> 
> Different apps and development/production environments should use separate Key Vaults to isolate app environments for the highest level of security.

In the following example, a secret is established in Key Vault (and using Secret Manager for the Development environment) for `5000-AppSecret` (periods aren't allowed in Key Vault secret names). This secret represents an app secret for version 5.0.0.0 of the app. For another version of the app, 5.1.0.0, a secret is added to the vault (and using Secret Manager) for `5100-AppSecret`. Each app version loads its versioned secret value into its configuration as `AppSecret`, removing the version as it loads the secret.

`AddAzureKeyVault` is called with a custom `KeyVaultSecretManager` implementation:

:::code language="csharp" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Snippets/Program.cs" id="snippet_AddAzureKeyVaultSecretManager":::

The implementation reacts to the version prefixes of secrets to load the proper secret into configuration:

* `Load` loads a secret when its name starts with the prefix. Other secrets aren't loaded.
* `GetKey`:
  * Removes the prefix from the secret name.
  * Replaces two dashes in any name with the `KeyDelimiter`, which is the delimiter used in configuration (usually a colon). Azure Key Vault doesn't allow a colon in secret names.

:::code language="csharp" source="key-vault-configuration/samples/6.x/KeyVaultConfigurationSample/Snippets/SamplePrefixKeyVaultSecretManager.cs" id="snippet_Class":::

The `Load` method is called by a provider algorithm that iterates through the vault secrets to find the version-prefixed secrets. When a version prefix is found with `Load`, the algorithm uses the `GetKey` method to return the configuration name of the secret name. It removes the version prefix from the secret's name. The rest of the secret name is returned for loading into the app's configuration name-value pairs.

When this approach is implemented:

1. The app's version specified in the app's project file. In the following example, the app's version is set to `5.0.0.0`:

   ```xml
   <PropertyGroup>
     <Version>5.0.0.0</Version>
   </PropertyGroup>
   ```

1. Confirm that a `<UserSecretsId>` property is present in the app's project file, where `{GUID}` is a user-supplied GUID:

   ```xml
   <PropertyGroup>
     <UserSecretsId>{GUID}</UserSecretsId>
   </PropertyGroup>
   ```

   Save the following secrets locally with [Secret Manager](xref:security/app-secrets):

   ```dotnetcli
   dotnet user-secrets set "5000-AppSecret" "5.0.0.0_secret_value_dev"
   dotnet user-secrets set "5100-AppSecret" "5.1.0.0_secret_value_dev"
   ```

1. Secrets are saved in Azure Key Vault using the following Azure CLI commands:

   ```azurecli
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "5000-AppSecret" --value "5.0.0.0_secret_value_prod"
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "5100-AppSecret" --value "5.1.0.0_secret_value_prod"
   ```

1. When the app is run, the Key Vault secrets are loaded. The string secret for `5000-AppSecret` is matched to the app's version specified in the app's project file (`5.0.0.0`).

1. The version, `5000` (with the dash), is stripped from the key name. Throughout the app, reading configuration with the key `AppSecret` loads the secret value.

1. If the app's version is changed in the project file to `5.1.0.0` and the app is run again, the secret value returned is `5.1.0.0_secret_value_dev` in the Development environment and `5.1.0.0_secret_value_prod` in Production.

> [!NOTE]
> You can also provide your own <xref:Azure.Security.KeyVault.Secrets.SecretClient> implementation to `AddAzureKeyVault`. A custom client permits sharing a single instance of the client across the app.

## Bind an array to a class

The provider can read configuration values into an array for binding to a POCO array.

When reading from a configuration source that allows keys to contain colon (`:`) separators, a numeric key segment is used to distinguish the keys that make up an array (`:0:`, `:1:`, &hellip; `:{n}:`). For more information, see [Configuration: Bind an array to a class](xref:fundamentals/configuration/index#boa).

Azure Key Vault keys can't use a colon as a separator. The approach described in this article uses double dashes (`--`) as a separator for hierarchical values (sections). Array keys are stored in Azure Key Vault with double dashes and numeric key segments (`--0--`, `--1--`, &hellip; `--{n}--`).

Examine the following [Serilog](https://serilog.net/) logging provider configuration provided by a JSON file. There are two object literals defined in the `WriteTo` array that reflect two Serilog *sinks*, which describe destinations for logging output:

```json
"Serilog": {
  "WriteTo": [
    {
      "Name": "AzureTableStorage",
      "Args": {
        "storageTableName": "logs",
        "connectionString": "DefaultEnd...ountKey=Eby8...GMGw=="
      }
    },
    {
      "Name": "AzureDocumentDB",
      "Args": {
        "endpointUrl": "https://contoso.documents.azure.com:443",
        "authorizationKey": "Eby8...GMGw=="
      }
    }
  ]
}
```

The configuration shown in the preceding JSON file is stored in Azure Key Vault using double dash (`--`) notation and numeric segments:

| Key                                           | Value                                     |
|-----------------------------------------------|-------------------------------------------|
| `Serilog--WriteTo--0--Name`                   | `AzureTableStorage`                       |
| `Serilog--WriteTo--0--Args--storageTableName` | `logs`                                    |
| `Serilog--WriteTo--0--Args--connectionString` | `DefaultEnd...ountKey=Eby8...GMGw==`      |
| `Serilog--WriteTo--1--Name`                   | `AzureDocumentDB`                         |
| `Serilog--WriteTo--1--Args--endpointUrl`      | `https://contoso.documents.azure.com:443` |
| `Serilog--WriteTo--1--Args--authorizationKey` | `Eby8...GMGw==`                           |

## Reload secrets

By default, secrets are cached by the configuration provider for the app's lifetime. Secrets that have been subsequently disabled or updated in the vault are ignored by the app.

To reload secrets, call <xref:Microsoft.Extensions.Configuration.IConfigurationRoot.Reload%2A?displayProperty=nameWithType>:

```csharp
config.Reload();
```

To reload secrets periodically, at a specified interval, set the <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions.ReloadInterval%2A?displayProperty=nameWithType> property. For more information, see [Configuration options](#configuration-options).

## Disabled and expired secrets

Expired secrets are included by default in the configuration provider. To exclude values for these secrets in app configuration, update the expired secret or provide the configuration using a custom configuration provider:

```csharp
class SampleKeyVaultSecretManager : KeyVaultSecretManager
{
  public override bool Load(SecretProperties properties) =>
    properties.ExpiresOn.HasValue &&
    properties.ExpiresOn.Value > DateTimeOffset.Now;
}
```

Pass this custom `KeyVaultSecretManager` to `AddAzureKeyVault`:

```csharp
// using Azure.Extensions.AspNetCore.Configuration.Secrets;

builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential(),
    new SampleKeyVaultSecretManager());
```

Disabled secrets cannot be retrieved from Key Vault and are never included.

## Troubleshoot

When the app fails to load configuration using the provider, an error message is written to the [ASP.NET Core Logging infrastructure](xref:fundamentals/logging/index). The following conditions will prevent configuration from loading:

* The app or certificate isn't configured correctly in Azure AD.
* The vault doesn't exist in Azure Key Vault.
* The app isn't authorized to access the vault.
* The access policy doesn't include `Get` and `List` permissions.
* In the vault, the configuration data (name-value pair) is incorrectly named, missing, or disabled.
* The app has the wrong Key Vault name (`KeyVaultName`), Azure AD Application ID (`AzureADApplicationId`), or Azure AD certificate thumbprint (`AzureADCertThumbprint`), or Azure AD Directory ID (`AzureADDirectoryId`).
* When adding the Key Vault access policy for the app, the policy was created, but the **Save** button wasn't selected in the **Access policies** UI.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/key-vault-configuration/samples) ([how to download](xref:index#how-to-download-a-sample))
* <xref:fundamentals/configuration/index>
* [Microsoft Azure: Key Vault Documentation](/azure/key-vault/)
* [How to generate and transfer HSM-protected keys for Azure Key Vault](/azure/key-vault/key-vault-hsm-protected-keys)
* [Quickstart: Set and retrieve a secret from Azure Key Vault by using a .NET web app](/azure/key-vault/quick-create-net)
* [Tutorial: How to use Azure Key Vault with Azure Windows Virtual Machine in .NET](/azure/key-vault/tutorial-net-windows-virtual-machine)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This article explains how to use the [Azure Key Vault](/azure/key-vault/) configuration provider to load app configuration values from Azure Key Vault secrets. Azure Key Vault is a cloud-based service that helps safeguard cryptographic keys and secrets used by apps and services. Common scenarios for using Azure Key Vault with ASP.NET Core apps include:

* Controlling access to sensitive configuration data.
* Meeting the requirement for FIPS 140-2 Level 2 validated Hardware Security Modules (HSMs) when storing configuration data.

## Packages

Add package references for the following packages:

* [Azure.Extensions.AspNetCore.Configuration.Secrets](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets)
* [Azure.Identity](https://www.nuget.org/packages/Azure.Identity)

## Sample app

The sample app runs in either of two modes determined by the `#define` preprocessor directive at the top of `Program.cs`:

* `Certificate`: Demonstrates using an Azure Key Vault Client ID and X.509 certificate to access secrets stored in Azure Key Vault. This sample can be run from any location, whether deployed to Azure App Service or any host that can serve an ASP.NET Core app.
* `Managed`: Demonstrates how to use [Managed identities for Azure resources](/azure/active-directory/managed-identities-azure-resources/overview). The managed identity authenticates the app to Azure Key Vault with Azure Active Directory (AD) authentication without credentials stored in the app's code or configuration. When using managed identities to authenticate, an Azure AD Application ID and Password (Client Secret) aren't required. The `Managed` version of the sample must be deployed to Azure. Follow the guidance in the [Use the managed identities for Azure resources](#use-managed-identities-for-azure-resources) section.

For more information configuring a sample app using preprocessor directives (`#define`), see <xref:index#preprocessor-directives-in-sample-code>.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/key-vault-configuration/samples) ([how to download](xref:index#how-to-download-a-sample))

## Secret storage in the Development environment

Set secrets locally using [Secret Manager](xref:security/app-secrets). When the sample app runs on the local machine in the Development environment, secrets are loaded from the local user secrets store.

Secret Manager requires a `<UserSecretsId>` property in the app's project file. Set the property value (`{GUID}`) to any unique GUID:

```xml
<PropertyGroup>
  <UserSecretsId>{GUID}</UserSecretsId>
</PropertyGroup>
```

Secrets are created as name-value pairs. Hierarchical values (configuration sections) use a `:` (colon) as a separator in [ASP.NET Core configuration](xref:fundamentals/configuration/index) key names.

Secret Manager is used from a command shell opened to the project's [content root](xref:fundamentals/index#content-root), where `{SECRET NAME}` is the name and `{SECRET VALUE}` is the value:

```dotnetcli
dotnet user-secrets set "{SECRET NAME}" "{SECRET VALUE}"
```

Execute the following commands in a command shell from the project's [content root](xref:fundamentals/index#content-root) to set the secrets for the sample app:

```dotnetcli
dotnet user-secrets set "SecretName" "secret_value_1_dev"
dotnet user-secrets set "Section:SecretName" "secret_value_2_dev"
```

When these secrets are stored in Azure Key Vault in the [Secret storage in the Production environment with Azure Key Vault](#secret-storage-in-the-production-environment-with-azure-key-vault) section, the `_dev` suffix is changed to `_prod`. The suffix provides a visual cue in the app's output indicating the source of the configuration values.

## Secret storage in the Production environment with Azure Key Vault

Complete the following steps to create an Azure Key Vault and store the sample app's secrets in it. For more information, see [Quickstart: Set and retrieve a secret from Azure Key Vault using Azure CLI](/azure/key-vault/quick-create-cli).

1. Open Azure Cloud Shell using any one of the following methods in the [Azure portal](https://portal.azure.com/):

   * Select **Try It** in the upper-right corner of a code block. Use the search string "Azure CLI" in the text box.
   * Open Cloud Shell in your browser with the **Launch Cloud Shell** button.
   * Select the **Cloud Shell** button on the menu in the upper-right corner of the Azure portal.

   For more information, see [Azure CLI](/cli/azure/) and [Overview of Azure Cloud Shell](/azure/cloud-shell/overview).

1. If you aren't already authenticated, sign in with the `az login` command.

1. Create a resource group with the following command, where `{RESOURCE GROUP NAME}` is the new resource group's name and `{LOCATION}` is the Azure region:

   ```azurecli
   az group create --name "{RESOURCE GROUP NAME}" --location {LOCATION}
   ```

1. Create a Key Vault in the resource group with the following command, where `{KEY VAULT NAME}` is the new vault's name and `{LOCATION}` is the Azure region:

   ```azurecli
   az keyvault create --name {KEY VAULT NAME} --resource-group "{RESOURCE GROUP NAME}" --location {LOCATION}
   ```

1. Create secrets in the vault as name-value pairs.

   Azure Key Vault secret names are limited to alphanumeric characters and dashes. Hierarchical values (configuration sections) use `--` (two dashes) as a delimiter, as colons aren't allowed in Key Vault secret names. Colons delimit a section from a subkey in [ASP.NET Core configuration](xref:fundamentals/configuration/index). The two-dash sequence is replaced with a colon when the secrets are loaded into the app's configuration.

   The following secrets are for use with the sample app. The values include a `_prod` suffix to distinguish them from the `_dev` suffix values loaded in the Development environment from Secret Manager. Replace `{KEY VAULT NAME}` with the name of the Key Vault you created in the prior step:

   ```azurecli
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "SecretName" --value "secret_value_1_prod"
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "Section--SecretName" --value "secret_value_2_prod"
   ```

## Use Application ID and X.509 certificate for non-Azure-hosted apps

Configure Azure AD, Azure Key Vault, and the app to use an Azure AD Application ID and X.509 certificate to authenticate to a vault **when the app is hosted outside of Azure**. For more information, see [About keys, secrets, and certificates](/azure/key-vault/about-keys-secrets-and-certificates).

> [!NOTE]
> Although using an Application ID and X.509 certificate is supported for apps hosted in Azure, it's not recommended. Instead, use [Managed identities for Azure resources](#use-managed-identities-for-azure-resources) when hosting an app in Azure. Managed identities don't require storing a certificate in the app or in the development environment.

The sample app uses an Application ID and X.509 certificate when the `#define` preprocessor directive at the top of `Program.cs` is set to `Certificate`.

1. Create a PKCS#12 archive (*.pfx*) certificate. Options for creating certificates include [New-SelfSignedCertificate on Windows](/powershell/module/pki/new-selfsignedcertificate) and [OpenSSL](https://www.openssl.org/).
1. Install the certificate into the current user's personal certificate store. Marking the key as exportable is optional. Note the certificate's thumbprint, which is used later in this process.
1. Export the PKCS#12 archive (*.pfx*) certificate as a DER-encoded certificate (*.cer*).
1. Register the app with Azure AD (**App registrations**).
1. Upload the DER-encoded certificate (*.cer*) to Azure AD:
   1. Select the app in Azure AD.
   1. Navigate to **Certificates & secrets**.
   1. Select **Upload certificate** to upload the certificate, which contains the public key. A *.cer*, *.pem*, or *.crt* certificate is acceptable.
1. Store the Key Vault name, Application ID, and certificate thumbprint in the app's `appsettings.json` file.
1. Navigate to **Key Vaults** in the Azure portal.
1. Select the Key Vault you created in the [Secret storage in the Production environment with Azure Key Vault](#secret-storage-in-the-production-environment-with-azure-key-vault) section.
1. Select **Access policies**.
1. Select **Add Access Policy**.
1. Open **Secret permissions** and provide the app with **Get** and **List** permissions.
1. Select **Select principal** and select the registered app by name. Select the **Select** button.
1. Select **OK**.
1. Select **Save**.
1. Deploy the app.

The `Certificate` sample app obtains its configuration values from <xref:Microsoft.Extensions.Configuration.IConfigurationRoot> with the same name as the secret name:

* Non-hierarchical values: The value for `SecretName` is obtained with `config["SecretName"]`.
* Hierarchical values (sections): Use `:` (colon) notation or the <xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A> method. Use either of these approaches to obtain the configuration value:
  * `config["Section:SecretName"]`
  * `config.GetSection("Section")["SecretName"]`

The X.509 certificate is managed by the OS. The app calls <xref:Microsoft.Extensions.Configuration.AzureKeyVaultConfigurationExtensions.AddAzureKeyVault%2A> with values supplied by the `appsettings.json` file:

:::code language="csharp" source="key-vault-configuration/samples/3.x/SampleApp/Program.cs" id="snippet1" highlight="46-49":::

Example values:

* Key Vault name: `contosovault`
* Application ID: `627e911e-43cc-61d4-992e-12db9c81b413`
* Certificate thumbprint: `fe14593dd66b2406c5269d742d04b6e1ab03adb1`

`appsettings.json`:

:::code language="json" source="key-vault-configuration/samples/3.x/SampleApp/appsettings.json" highlight="10-12":::

When you run the app, a webpage shows the loaded secret values. In the Development environment, secret values load with the `_dev` suffix. In the Production environment, the values load with the `_prod` suffix.

## Use managed identities for Azure resources

**An app deployed to Azure** can take advantage of [Managed identities for Azure resources](/azure/active-directory/managed-identities-azure-resources/overview). A managed identity allows the app to authenticate with Azure Key Vault using Azure AD authentication without credentials (Application ID and Password/Client Secret) stored in the app.

The sample app uses managed identities for Azure resources when the `#define` preprocessor directive at the top of `Program.cs` is set to `Managed`.

Enter the vault name into the app's `appsettings.json` file. The sample app doesn't require an Application ID and Password (Client Secret) when set to the `Managed` version, so you can ignore those configuration entries. The app is deployed to Azure, and Azure authenticates the app to access Azure Key Vault only using the vault name stored in the `appsettings.json` file.

Deploy the sample app to Azure App Service.

An app deployed to Azure App Service is automatically registered with Azure AD when the service is created. Obtain the Object ID from the deployment for use in the following command. The Object ID is shown in the Azure portal on the **Identity** panel of the App Service.

Using Azure CLI and the app's Object ID, provide the app with `list` and `get` permissions to access the vault:

```azurecli
az keyvault set-policy --name {KEY VAULT NAME} --object-id {OBJECT ID} --secret-permissions get list
```

**Restart the app** using Azure CLI, PowerShell, or the Azure portal.

The sample app:

* Creates an instance of the <xref:Azure.Identity.DefaultAzureCredential> class. The credential attempts to obtain an access token from environment for Azure resources.
* A new <xref:Azure.Security.KeyVault.Secrets.SecretClient> is created with the `DefaultAzureCredential` instance.
* The `SecretClient` instance is used with a <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager> instance, which loads secret values and replaces double-dashes (`--`) with colons (`:`) in key names.

:::code language="csharp" source="key-vault-configuration/samples/3.x/SampleApp/Program.cs" id="snippet2" highlight="12-14":::

Key Vault name example value: `contosovault`

`appsettings.json`:

```json
{
  "KeyVaultName": "Key Vault Name"
}
```

When you run the app, a webpage shows the loaded secret values. In the Development environment, secret values have the `_dev` suffix because they're provided by Secret Manager. In the Production environment, the values load with the `_prod` suffix because they're provided by Azure Key Vault.

If you receive an `Access denied` error, confirm that the app is registered with Azure AD and provided access to the vault. Confirm that you've restarted the service in Azure.

For information on using the provider with a managed identity and Azure Pipelines, see [Create an Azure Resource Manager service connection to a VM with a managed service identity](/azure/devops/pipelines/library/connect-to-azure#create-an-azure-resource-manager-service-connection-to-a-vm-with-a-managed-service-identity).

## Configuration options

`AddAzureKeyVault` can accept an <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions> object:

```csharp
config.AddAzureKeyVault(
    new SecretClient(
        new Uri("Your Key Vault Endpoint"),
        new DefaultAzureCredential(),
        new AzureKeyVaultConfigurationOptions())
    {
        ...
    });
```

The `AzureKeyVaultConfigurationOptions` object contains the following properties.

| Property                                                                                                    | Description                                                                                                                           |
|-------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions.Manager%2A>        | <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager> instance used to control secret loading.               |
| <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.AzureKeyVaultConfigurationOptions.ReloadInterval%2A> | `TimeSpan` to wait between attempts at polling the vault for changes. The default value is `null` (configuration isn't reloaded). |

## Use a key name prefix

`AddAzureKeyVault` provides an overload that accepts an implementation of <xref:Azure.Extensions.AspNetCore.Configuration.Secrets.KeyVaultSecretManager>, which allows you to control how Key Vault secrets are converted into configuration keys. For example, you can implement the interface to load secret values based on a prefix value you provide at app startup. This technique allows you, for example, to load secrets based on the version of the app.

> [!WARNING]
> Don't use prefixes on Key Vault secrets to:
>
> * Place secrets for multiple apps into the same vault.
> * Place environmental secrets (for example, *development* versus *production* secrets) into the same vault.
> 
> Different apps and development/production environments should use separate Key Vaults to isolate app environments for the highest level of security.

In the following example, a secret is established in Key Vault (and using Secret Manager for the Development environment) for `5000-AppSecret` (periods aren't allowed in Key Vault secret names). This secret represents an app secret for version 5.0.0.0 of the app. For another version of the app, 5.1.0.0, a secret is added to the vault (and using Secret Manager) for `5100-AppSecret`. Each app version loads its versioned secret value into its configuration as `AppSecret`, removing the version as it loads the secret.

`AddAzureKeyVault` is called with a custom `KeyVaultSecretManager` implementation:

:::code language="csharp" source="key-vault-configuration/samples_snapshot/3.x/Program.cs":::

The implementation reacts to the version prefixes of secrets to load the proper secret into configuration:

* `Load` loads a secret when its name starts with the prefix. Other secrets aren't loaded.
* `GetKey`:
  * Removes the prefix from the secret name.
  * Replaces two dashes in any name with the `KeyDelimiter`, which is the delimiter used in configuration (usually a colon). Azure Key Vault doesn't allow a colon in secret names.

:::code language="csharp" source="key-vault-configuration/samples_snapshot/3.x/PrefixKeyVaultSecretManager.cs":::

The `Load` method is called by a provider algorithm that iterates through the vault secrets to find the version-prefixed secrets. When a version prefix is found with `Load`, the algorithm uses the `GetKey` method to return the configuration name of the secret name. It removes the version prefix from the secret's name. The rest of the secret name is returned for loading into the app's configuration name-value pairs.

When this approach is implemented:

1. The app's version specified in the app's project file. In the following example, the app's version is set to `5.0.0.0`:

   ```xml
   <PropertyGroup>
     <Version>5.0.0.0</Version>
   </PropertyGroup>
   ```

1. Confirm that a `<UserSecretsId>` property is present in the app's project file, where `{GUID}` is a user-supplied GUID:

   ```xml
   <PropertyGroup>
     <UserSecretsId>{GUID}</UserSecretsId>
   </PropertyGroup>
   ```

   Save the following secrets locally with [Secret Manager](xref:security/app-secrets):

   ```dotnetcli
   dotnet user-secrets set "5000-AppSecret" "5.0.0.0_secret_value_dev"
   dotnet user-secrets set "5100-AppSecret" "5.1.0.0_secret_value_dev"
   ```

1. Secrets are saved in Azure Key Vault using the following Azure CLI commands:

   ```azurecli
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "5000-AppSecret" --value "5.0.0.0_secret_value_prod"
   az keyvault secret set --vault-name {KEY VAULT NAME} --name "5100-AppSecret" --value "5.1.0.0_secret_value_prod"
   ```

1. When the app is run, the Key Vault secrets are loaded. The string secret for `5000-AppSecret` is matched to the app's version specified in the app's project file (`5.0.0.0`).

1. The version, `5000` (with the dash), is stripped from the key name. Throughout the app, reading configuration with the key `AppSecret` loads the secret value.

1. If the app's version is changed in the project file to `5.1.0.0` and the app is run again, the secret value returned is `5.1.0.0_secret_value_dev` in the Development environment and `5.1.0.0_secret_value_prod` in Production.

> [!NOTE]
> You can also provide your own <xref:Azure.Security.KeyVault.Secrets.SecretClient> implementation to `AddAzureKeyVault`. A custom client permits sharing a single instance of the client across the app.

## Bind an array to a class

The provider can read configuration values into an array for binding to a POCO array.

When reading from a configuration source that allows keys to contain colon (`:`) separators, a numeric key segment is used to distinguish the keys that make up an array (`:0:`, `:1:`, &hellip; `:{n}:`). For more information, see [Configuration: Bind an array to a class](xref:fundamentals/configuration/index#boa).

Azure Key Vault keys can't use a colon as a separator. The approach described in this article uses double dashes (`--`) as a separator for hierarchical values (sections). Array keys are stored in Azure Key Vault with double dashes and numeric key segments (`--0--`, `--1--`, &hellip; `--{n}--`).

Examine the following [Serilog](https://serilog.net/) logging provider configuration provided by a JSON file. There are two object literals defined in the `WriteTo` array that reflect two Serilog *sinks*, which describe destinations for logging output:

```json
"Serilog": {
  "WriteTo": [
    {
      "Name": "AzureTableStorage",
      "Args": {
        "storageTableName": "logs",
        "connectionString": "DefaultEnd...ountKey=Eby8...GMGw=="
      }
    },
    {
      "Name": "AzureDocumentDB",
      "Args": {
        "endpointUrl": "https://contoso.documents.azure.com:443",
        "authorizationKey": "Eby8...GMGw=="
      }
    }
  ]
}
```

The configuration shown in the preceding JSON file is stored in Azure Key Vault using double dash (`--`) notation and numeric segments:

| Key                                           | Value                                     |
|-----------------------------------------------|-------------------------------------------|
| `Serilog--WriteTo--0--Name`                   | `AzureTableStorage`                       |
| `Serilog--WriteTo--0--Args--storageTableName` | `logs`                                    |
| `Serilog--WriteTo--0--Args--connectionString` | `DefaultEnd...ountKey=Eby8...GMGw==`      |
| `Serilog--WriteTo--1--Name`                   | `AzureDocumentDB`                         |
| `Serilog--WriteTo--1--Args--endpointUrl`      | `https://contoso.documents.azure.com:443` |
| `Serilog--WriteTo--1--Args--authorizationKey` | `Eby8...GMGw==`                           |

## Reload secrets

Secrets are cached until <xref:Microsoft.Extensions.Configuration.IConfigurationRoot.Reload%2A?displayProperty=nameWithType> is called. Subsequently disabled or updated secrets in the vault aren't respected by the app until `Reload` is executed.

```csharp
Configuration.Reload();
```

## Disabled and expired secrets

Expired secrets are included by default in the configuration provider. To exclude values for these secrets in app configuration, update the expired secret or provide the configuration using a custom configuration provider:

```csharp
class SampleKeyVaultSecretManager : KeyVaultSecretManager
{
  public override bool Load(SecretProperties properties) =>
    properties.ExpiresOn.HasValue &&
    properties.ExpiresOn.Value > DateTimeOffset.Now;
}
```

Pass this custom `KeyVaultSecretManager` to `AddAzureKeyVault`:

```csharp
// using Azure.Extensions.AspNetCore.Configuration.Secrets;

config.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential(),
    new SampleKeyVaultSecretManager());
```

Disabled secrets cannot be retrieved from Key Vault and are never included.

## Troubleshoot

When the app fails to load configuration using the provider, an error message is written to the [ASP.NET Core Logging infrastructure](xref:fundamentals/logging/index). The following conditions will prevent configuration from loading:

* The app or certificate isn't configured correctly in Azure AD.
* The vault doesn't exist in Azure Key Vault.
* The app isn't authorized to access the vault.
* The access policy doesn't include `Get` and `List` permissions.
* In the vault, the configuration data (name-value pair) is incorrectly named, missing, or disabled.
* The app has the wrong Key Vault name (`KeyVaultName`), Azure AD Application ID (`AzureADApplicationId`), or Azure AD certificate thumbprint (`AzureADCertThumbprint`), or Azure AD Directory ID (`AzureADDirectoryId`).
* When adding the Key Vault access policy for the app, the policy was created, but the **Save** button wasn't selected in the **Access policies** UI.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/key-vault-configuration/samples) ([how to download](xref:index#how-to-download-a-sample))
* <xref:fundamentals/configuration/index>
* [Microsoft Azure: Key Vault Documentation](/azure/key-vault/)
* [How to generate and transfer HSM-protected keys for Azure Key Vault](/azure/key-vault/key-vault-hsm-protected-keys)
* [Quickstart: Set and retrieve a secret from Azure Key Vault by using a .NET web app](/azure/key-vault/quick-create-net)
* [Tutorial: How to use Azure Key Vault with Azure Windows Virtual Machine in .NET](/azure/key-vault/tutorial-net-windows-virtual-machine)

:::moniker-end
