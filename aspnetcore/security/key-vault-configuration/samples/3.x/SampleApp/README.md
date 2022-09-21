# Key Vault Configuration Provider Sample App

This sample illustrates the use of the Azure Key Vault Configuration Provider.

The sample runs in one of two modes determined by the `#define` statement at the top of the `Program.cs` file. For instructions, see [Preprocessor directives in sample code](https://learn.microsoft.com/aspnet/core#preprocessor-directives-in-sample-code):

* `Certificate`: Demonstrates the use of an Azure Key Vault Client ID and X.509 certificate to access secrets stored in Azure Key Vault. This version of the sample can be run from any location, deployed to Azure App Service or any host capable of serving an ASP.NET Core app.
* `Managed`: Demonstrates how to use Azure's [managed identity](https://learn.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview) to authenticate the app to Azure Key Vault with Azure AD authentication without credentials in the app's code or configuration. An Azure AD Client ID and Secret aren't required for the app to authenticate with Azure Key Vault. This sample must be deployed to Azure App Service to explore the managed identity scenario.

For more information, see [Azure Key Vault Configuration Provider](https://learn.microsoft.com/aspnet/core/security/key-vault-configuration).
