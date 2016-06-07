

Microsoft.AspNetCore.DataProtection.XmlEncryption Namespace
===========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/CertificateResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/CertificateXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/DpapiNGProtectionDescriptorFlags/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/DpapiNGXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/DpapiNGXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/DpapiXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/DpapiXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/EncryptedXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/EncryptedXmlInfo/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/ICertificateResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/IXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/IXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/NullXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/DataProtection/XmlEncryption/NullXmlEncryptor/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.DataProtection.XmlEncryption


    .. rubric:: Classes


    class :dn:cls:`CertificateResolver`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateResolver

        
        A default implementation of :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver` that looks in the current user
        and local machine certificate stores.


    class :dn:cls:`CertificateXmlEncryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` that can perform XML encryption by using an X.509 certificate.


    class :dn:cls:`DpapiNGXmlDecryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlDecryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.


    class :dn:cls:`DpapiNGXmlEncryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGXmlEncryptor

        
        A class that can encrypt XML elements using Windows DPAPI:NG.


    class :dn:cls:`DpapiXmlDecryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlDecryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor`\.


    class :dn:cls:`DpapiXmlEncryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiXmlEncryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML by using Windows DPAPI.


    class :dn:cls:`EncryptedXmlDecryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlDecryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements by using the :any:`System.Security.Cryptography.Xml.EncryptedXml` class.


    class :dn:cls:`EncryptedXmlInfo`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo

        
        Wraps an :any:`System.Xml.Linq.XElement` that contains a blob of encrypted XML
        and information about the class which can be used to decrypt it.


    class :dn:cls:`NullXmlDecryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlDecryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements with a null decryptor.


    class :dn:cls:`NullXmlEncryptor`
        .. object: type=class name=Microsoft.AspNetCore.DataProtection.XmlEncryption.NullXmlEncryptor

        
        An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML elements with a null encryptor.


    .. rubric:: Enumerations


    enum :dn:enum:`DpapiNGProtectionDescriptorFlags`
        .. object: type=enum name=Microsoft.AspNetCore.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags

        
        Flags used to control the creation of protection descriptors.


    .. rubric:: Interfaces


    interface :dn:iface:`ICertificateResolver`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver

        
        Provides services for locating :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instances.


    interface :dn:iface:`IXmlDecryptor`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlDecryptor

        
        The basic interface for decrypting an XML element.


    interface :dn:iface:`IXmlEncryptor`
        .. object: type=interface name=Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor

        
        The basic interface for encrypting XML elements.


