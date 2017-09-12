For generating self-signed SSL certificates on Windows, you can use the PowerShell cmdlet [New-SelfSignedCertificate](https://technet.microsoft.com/itpro/powershell/windows/pki/new-selfsignedcertificate). There are also third-party tools that make it easier for you to generate self-signed certificates:

* [SelfCert](https://www.pluralsight.com/blog/software-development/selfcert-create-a-self-signed-certificate-interactively-gui-or-programmatically-in-net)
* [Makecert UI](http://makecertui.codeplex.com/)

On macOS and Linux you can create a self-signed certificate using [OpenSSL](https://www.openssl.org/).

For more information, see [Setting up HTTPS for development](xref:security/https).
