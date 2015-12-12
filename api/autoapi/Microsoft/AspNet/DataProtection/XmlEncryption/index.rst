

Microsoft.AspNet.DataProtection.XmlEncryption Namespace
=======================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/CertificateResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/CertificateXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/DpapiNGProtectionDescriptorFlags/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/DpapiNGXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/DpapiNGXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/DpapiXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/DpapiXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/EncryptedXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/EncryptedXmlInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/ICertificateResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/IXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/IXmlEncryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/NullXmlDecryptor/index
   
   
   
   /autoapi/Microsoft/AspNet/DataProtection/XmlEncryption/NullXmlEncryptor/index
   
   











.. dn:namespace:: Microsoft.AspNet.DataProtection.XmlEncryption


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateResolver`
        A default implementation of :any:`Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver` that looks in the current user
        and local machine certificate stores.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor` that can perform XML encryption by using an X.509 certificate.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlDecryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`\.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGXmlEncryptor`
        A class that can encrypt XML elements using Windows DPAPI:NG.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlDecryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements that were encrypted with :any:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor`\.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiXmlEncryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML by using Windows DPAPI.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlDecryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements by using the :any:`System.Security.Cryptography.Xml.EncryptedXml` class.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo`
        Wraps an :any:`System.Xml.Linq.XElement` that contains a blob of encrypted XML
        and information about the class which can be used to decrypt it.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlDecryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor` that decrypts XML elements with a null decryptor.


    class :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.NullXmlEncryptor`
        An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor` that encrypts XML elements with a null encryptor.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver`
        Provides services for locating :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instances.


    interface :dn:iface:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlDecryptor`
        The basic interface for decrypting an XML element.


    interface :dn:iface:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor`
        The basic interface for encrypting XML elements.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags`
        Flags used to control the creation of protection descriptors.


