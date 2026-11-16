using System.Security.Cryptography.X509Certificates;

namespace CertAuthSample.Snippets;

public class SampleCertificateThumbprintsValidationService : ICertificateValidationService
{
    private readonly string[] validThumbprints = new[]
    {
        "141594A0AE38CBBECED7AF680F7945CD51D8F28A",
        "0C89639E4E2998A93E423F919B36D4009A0F9991",
        "BA9BF91ED35538A01375EFC212A2F46104B33A44"
    };

    public bool ValidateCertificate(X509Certificate2 clientCertificate)
        => validThumbprints.Contains(clientCertificate.Thumbprint);
}
