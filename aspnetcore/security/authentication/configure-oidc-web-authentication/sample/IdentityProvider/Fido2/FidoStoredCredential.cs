using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Fido2NetLib.Objects;

namespace Fido2Identity;

/// <summary>
/// Represents a WebAuthn credential.
/// </summary>
public class FidoStoredCredential
{
    /// <summary>
    /// Gets or sets the primary key for this user.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; set; }

    /// <summary>
    /// Gets or sets the user name for this user.
    /// </summary>
    public virtual string? UserName { get; set; }

    public virtual byte[]? UserId { get; set; }

    /// <summary>
    /// Gets or sets the public key for this user.
    /// </summary>
    public virtual byte[]? PublicKey { get; set; }

    /// <summary>
    /// Gets or sets the user handle for this user.
    /// </summary>
    public virtual byte[]? UserHandle { get; set; }

    public virtual uint SignatureCounter { get; set; }

    public virtual string? CredType { get; set; }

    /// <summary>
    /// Gets or sets the registration date for this user.
    /// </summary>
    public virtual DateTime RegDate { get; set; }

    /// <summary>
    /// Gets or sets the Authenticator Attestation GUID (AAGUID) for this user.
    /// </summary>
    /// <remarks>
    /// An AAGUID is a 128-bit identifier indicating the type of the authenticator.
    /// </remarks>
    public virtual Guid AaGuid { get; set; }

    [NotMapped]
    public PublicKeyCredentialDescriptor? Descriptor
    {
        get { return string.IsNullOrWhiteSpace(DescriptorJson) ? null : JsonSerializer.Deserialize<PublicKeyCredentialDescriptor>(DescriptorJson); }
        set { DescriptorJson = JsonSerializer.Serialize(value); }
    }

    public virtual string? DescriptorJson { get; set; }
}
