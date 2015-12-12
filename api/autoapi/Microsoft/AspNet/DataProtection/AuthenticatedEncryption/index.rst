

Microsoft.AspNet.DataProtection.AuthenticatedEncryption Namespace
=================================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/AuthenticatedEncryptionOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/CngCbcAuthenticatedEncryptionOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/CngGcmAuthenticatedEncryptionOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/EncryptionAlgorithm/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/IAuthenticatedEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/ManagedAuthenticatedEncryptionOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/AuthenticatedEncryption/ValidationAlgorithm/index
   
   











.. dn:namespace:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions`
        Options for configuring authenticated encryption algorithms.


    class :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions`
        Options for configuring an authenticated encryption mechanism which uses
        Windows CNG algorithms in CBC encryption + HMAC authentication modes.


    class :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions`
        Options for configuring an authenticated encryption mechanism which uses
        Windows CNG algorithms in GCM encryption + authentication modes.


    class :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions`
        Options for configuring an authenticated encryption mechanism which uses
        managed SymmetricAlgorithm and KeyedHashAlgorithm implementations.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor`
        The basic interface for providing an authenticated encryption and decryption routine.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm`
        Specifies a symmetric encryption algorithm to use for providing confidentiality
        to protected payloads.


    enum :dn:enum:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm`
        Specifies a message authentication algorithm to use for providing tamper-proofing
        to protected payloads.


