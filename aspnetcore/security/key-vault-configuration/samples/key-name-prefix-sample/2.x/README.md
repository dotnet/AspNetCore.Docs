# Prefix Key Vault Configuration Provider sample application (ASP.NET Core 2.x)

This sample illustrates the use of the Azure Key Vault Configuration Provider for ASP.NET Core 2.x using key name prefixes. For the ASP.NET Core 1.x sample, see [Prefix Key Vault Configuration Provider sample application (ASP.NET Core 1.x)](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/key-vault-configuration/samples/key-name-prefix-sample/1.x).

For more information on how the sample works, see the [Azure Key Vault configuration provider](xref:security/key-vault-configuration) topic.

## Using the sample
1. Create a key vault and set up Azure Active Directory (Azure AD) for the application following the guidance in [Get started with Azure Key Vault](https://azure.microsoft.com/documentation/articles/key-vault-get-started/).
  * Add secrets to the key vault using the Azure PowerShell Module, the Azure Management API, or the Azure Portal. Secrets are created as either *Manual* or *Certificate* secrets. *Certificate* secrets are certificates for use by apps and services but are not supported by the configuration provider. You should use the *Manual* option to create name-value pair secrets for use with the configuration provider.
    * Hierarchical values (configuration sections) use `--` (two dashes) as a separator.
    * For the sample app, create two *Manual* secrets with the following name-value pairs:
      * `5000-AppSecret`: `5.0.0.0_secret_value`
      * `5100-AppSecret`: `5.1.0.0_secret_value`
  * Register the sample app with Azure Active Directory.
  * Authorize the app to access the key vault. When you use the `Set-AzureRmKeyVaultAccessPolicy` PowerShell cmdlet to authorize the app to access the key vault, provide `List` and `Get` access to secrets with `-PermissionsToKeys list,get`.
2. Update the app's *appsettings.json* file with the values of `Vault`, `ClientId`, and `ClientSecret`.
3. Run the sample app, which obtains its configuration values from `IConfigurationRoot` with the same name as the prefixed secret name. In this sample, the prefix is the app's version, which you provided to the `PrefixKeyVaultSecretManager` when you added the Azure Key Vault configuration provider. The value for `AppSecret` is obtained with `config["AppSecret"]`.
4. Change the version of the app assembly in the project file from `5.0.0.0` to `5.1.0.0` and run the app again. This time, the secret value returned is `5.1.0.0_secret_value`.
