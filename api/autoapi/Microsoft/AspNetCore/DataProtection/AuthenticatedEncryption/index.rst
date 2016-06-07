

Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption Namespace
=====================================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/AuthenticatedEncryptionSettings/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/CngCbcAuthenticatedEncryptionSettings/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/CngGcmAuthenticatedEncryptionSettings/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/EncryptionAlgorithm/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/IAuthenticatedEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ManagedAuthenticatedEncryptionSettings/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/AuthenticatedEncryption/ValidationAlgorithm/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption


    .. rubric:: Classes


    class :dn:cls:`AuthenticatedEncryptionSettings`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings

        
        Settings for configuring authenticated encryption algorithms.


    class :dn:cls:`CngCbcAuthenticatedEncryptionSettings`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings

        
        Settings for configuring an authenticated encryption mechanism which uses
        Windows CNG algorithms in CBC encryption + HMAC authentication modes.


    class :dn:cls:`CngGcmAuthenticatedEncryptionSettings`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings

        
        Settings for configuring an authenticated encryption mechanism which uses
        Windows CNG algorithms in GCM encryption + authentication modes.


    class :dn:cls:`ManagedAuthenticatedEncryptionSettings`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings

        
        Settings for configuring an authenticated encryption mechanism which uses
        managed SymmetricAlgorithm and KeyedHashAlgorithm implementations.


    .. rubric:: Enumerations


    enum :dn:enum:`EncryptionAlgorithm`
        .. object: type=enum name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm

        
        Specifies a symmetric encryption algorithm to use for providing confidentiality
        to protected payloads.


    enum :dn:enum:`ValidationAlgorithm`
        .. object: type=enum name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm

        
        Specifies a message authentication algorithm to use for providing tamper-proofing
        to protected payloads.


    .. rubric:: Interfaces


    interface :dn:iface:`IAuthenticatedEncryptor`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor

        
        The basic interface for providing an authenticated encryption and decryption routine.


