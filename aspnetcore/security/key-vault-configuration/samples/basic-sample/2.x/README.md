# Key Vault Configuration Provider sample application (ASP.NET Core 2.x)

This sample illustrates the use of the Azure Key Vault Configuration Provider for ASP.NET Core 2.x. For the ASP.NET Core 1.x sample, see [Key Vault Configuration Provider sample application (ASP.NET Core 1.x)](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/samples/basic-sample/1.x).

For more information on how the sample works, see the [Azure Key Vault configuration provider](xref:security/key-vault-configuration) topic.

## Using the sample
1. Create a key vault and set up Azure Active Directory (Azure AD) for the application following the guidance in [Get started with Azure Key Vault](https://azure.microsoft.com/documentation/articles/key-vault-get-started/).
  * Add secrets to the key vault using the [AzureRM Key Vault PowerShell Module](/powershell/module/azurerm.keyvault) available from the [PowerShell Gallery](https://www.powershellgallery.com/packages/AzureRM.KeyVault), the [Azure Key Vault REST API](/rest/api/keyvault/), or the [Azure Portal](https://portal.azure.com/). Secrets are created as either *Manual* or *Certificate* secrets. *Certificate* secrets are certificates for use by apps and services but are not supported by the configuration provider. You should use the *Manual* option to create name-value pair secrets for use with the configuration provider.
    * Simple secrets are created as name-value pairs. Azure Key Vault secret names are limited to alphanumeric characters and dashes.
    * Hierarchical values (configuration sections) use `--` (two dashes) as a separator in the sample. Colons, which are normally used to delimit a section from a subkey in [ASP.NET Core configuration](xref:fundamentals/configuration), aren't allowed in secret names. Therefore, two dashes are used and swapped for a colon when the secrets are loaded into the app's configuration.
    * Create two *Manual* secrets with the following name-value pairs. The first secret is a simple name and value, and the second secret creates a secret value with a section and subkey in the secret name:
      * `SecretName`: `secret_value_1`
      * `Section--SecretName`: `secret_value_2`
  * Register the sample app with Azure Active Directory.
  * Authorize the app to access the key vault. When you use the `Set-AzureRmKeyVaultAccessPolicy` PowerShell cmdlet to authorize the app to access the key vault, provide `List` and `Get` access to secrets with `-PermissionsToKeys list,get`.
2. Update the app's *appsettings.json* file with the values of `Vault`, `ClientId`, and `ClientSecret`.
3. Run the sample app, which obtains its configuration values from `IConfigurationRoot` with the same name as the secret name.
  * Non-hierarchical values: The value for `SecretName` is obtained with `config["SecretName"]`.
  * Hierarchical values (sections): Use `:` (colon) notation or the `GetSection` extension method. Use either of these approaches to obtain the configuration value:
    * `config["Section:SecretName"]`
    * `config.GetSection("Section")["SecretName"]`
