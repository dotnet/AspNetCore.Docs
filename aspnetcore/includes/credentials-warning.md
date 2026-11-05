> [!WARNING]
> In the example code, the certificate password is stored as plain text in the _appsettings.json_ file.
> The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for the certificate password.
> To store certificate passwords securely in development environments, see [Protect secrets in development](../security/app-secrets.md).
> To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](../security/key-vault-configuration.md).
> It's a best practice to not use development secrets for production or testing.
