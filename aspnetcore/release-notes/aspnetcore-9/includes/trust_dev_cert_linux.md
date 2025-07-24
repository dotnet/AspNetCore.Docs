#### Trust the ASP.NET Core HTTPS development certificate on Linux

On Ubuntu and Fedora based Linux distros, `dotnet dev-certs https --trust` now configures ASP.NET Core HTTPS development certificate as a trusted certificate for:

* Chromium browsers, for example, Google Chrome, Microsoft Edge, and Chromium.
* Mozilla Firefox and Mozilla derived browsers.
* .NET APIs, for example, [HttpClient](/dotnet/api/system.net.http.httpclient)

Previously, `--trust` only worked on Windows and macOS. Certificate trust is applied per-user.

To establish trust in OpenSSL, the `dev-certs` tool:

* Puts the certificate in `~/.aspnet/dev-certs/trust`
* Runs a simplified version of OpenSSL's [c_rehash tool](https://docs.openssl.org/1.0.2/man1/c_rehash/) on the directory.
* Asks the user to update the `SSL_CERT_DIR` environment variable.

To establish trust in dotnet, the tool puts the certificate in the `My/Root` certificate store.

To establish trust in [NSS databases](https://docs.redhat.com/en/documentation/red_hat_enterprise_linux/6/html/developer_guide/che-nsslib), if any, the tool searches the home directory for Firefox profiles, `~/.pki/nssdb`, and `~/snap/chromium/current/.pki/nssdb`. For each directory found, the tool adds an entry to the `nssdb`.
