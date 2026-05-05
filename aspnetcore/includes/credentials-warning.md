> [!WARNING]
> In the example code, the certificate password is stored as plain text in the _appsettings.json_ file.
> The `$CREDENTIAL_PLACEHOLDER$` token is used as a placeholder for the certificate password.
> To store certificate passwords securely in development environments, see [Protect secrets in development](xref:security/app-secrets).
> To store certificate passwords securely in production environments, see [Azure Key Vault configuration provider](xref:security/key-vault-configuration).
> It's a best practice to not use development secrets for production or testing.
