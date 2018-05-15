# Create a new self-signed certificate for IIS Express.
#
# Provides a subjectAltName (SAN) to satisfy Chrome 58 or later.
# See https://bugs.chromium.org/p/chromium/issues/detail?id=308330
#
# Run the script at an administrative PowerShell prompt.
#
# When prompted to trust a new certificate via a Windows dialog,
# select Yes. Otherwise, Visual Studio won't be able to determine 
# the process ID when the web app is launched.
#
# THIS SCRIPT IS UNSUPPORTED BY MICROSOFT AND PROVIDED "AS IS" 
# WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED.

$certificate = New-SelfSignedCertificate `
    -Subject localhost `
    -DnsName localhost `
    -KeyAlgorithm RSA `
    -KeyLength 2048 `
    -NotBefore (Get-Date) `
    -NotAfter (Get-Date).AddYears(5) `
    -CertStoreLocation "cert:CurrentUser\My" `
    -FriendlyName "IIS Express Development Certificate" `
    -HashAlgorithm SHA256 `
    -KeyUsage DigitalSignature, KeyEncipherment, DataEncipherment `
    -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1") 
$certificatePath = 'Cert:\CurrentUser\My\' + ($certificate.ThumbPrint)    

# Export the certificate to a PFX (PKCS #12).
$pfxPassword = ConvertTo-SecureString ([Guid]::NewGuid().ToString()) -Force -AsPlainText
$pfxFilePath =  [system.io.path]::GetTempFileName()
$cerFilePath = [system.io.path]::GetTempFileName()

Export-PfxCertificate -Cert $certificatePath -FilePath $pfxFilePath -Password $pfxPassword
Export-Certificate -Cert $certificatePath -FilePath $cerFilePath

# Now that the certificate has been exported, delete the cert.
Remove-Item $certificatePath

# Add the certificate to the machine personal store, so netsh can bind.
Import-PfxCertificate -FilePath $pfxFilePath Cert:\LocalMachine\My -Password $pfxPassword -Exportable

# Add the certificate to the user root store, so trust is enabled.
# When the prompt appears to trust a new certificate via a Windows dialog,
# select Yes. Otherwise, Visual Studio won't be able to determine the
# process ID when the web app is launched.
Import-Certificate -FilePath $cerFilePath -CertStoreLocation Cert:\CurrentUser\Root

# Bind using netsh. The app ID is the IIS Express app ID.
for ($port = 44300; $port -lt 44400; $port++)
{
    $command = "http delete sslcert ipport=0.0.0.0:$port"
    Write-Output $command
    $command | netsh
    
    $command = "http add sslcert ipport=0.0.0.0:$port certhash="+$($certificate.Thumbprint)+" appid=""{214124cd-d05b-4309-9af9-9caa44b2b74a}"""
    Write-Output $command
    $command | netsh
}

# Clean up the temporary PFX.
Remove-Item $pfxFilePath
Remove-Item $cerFilePath
