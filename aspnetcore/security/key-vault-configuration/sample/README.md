# Key Vault Configuration Provider sample application

This sample illustrates the use of the Azure Key Vault Configuration Provider.

## Using the sample
1. Following the guidance in [Get started with Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-get-started):
  * Create a key vault
  * Create key vault secrets
    - `MySecret`: `secret_value_1`
    - `Section--MySecret`: `secret_value_2`
  * Register the application with Azure Active Directory
  * Authorize the application to use the secrets
2. Provide the configuration data to the `appsettings.json` file of the sample:
  * `Vault`: Azure Key Vault Name
  * `ClientId`: Azure AD Application Id
  * `ClientSecret`: Azure AD Application Key
3. Restore, build, and run the application
