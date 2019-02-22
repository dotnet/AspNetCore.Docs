## Enable local HTTPS

Trust the HTTPS development certificate:

# [Windows](#tab/windows)

```console
dotnet dev-certs https --trust
```

The preceding command displays the following dialog:

![Security warning dialog](~/getting-started/_static/cert.png)

Select **Yes** if you agree to trust the development certificate.

# [macOS](#tab/macos)

```console
dotnet dev-certs https --trust
```

The preceding command displays the following message:

*Trusting the HTTPS development certificate was requested. If the certificate is not already trusted we will run the following command:* `'sudo security add-trusted-cert -d -r trustRoot -k /Library/Keychains/System.keychain <<certificate>>'`.  
*This command might prompt you for your password to install the certificate on the system keychain.

Password:*

Enter your password if you agree to trust the development certificate.

# [Linux](#tab/linux)

See the documentation for your Linux distribution on how to trust the HTTPS development certificate.

---