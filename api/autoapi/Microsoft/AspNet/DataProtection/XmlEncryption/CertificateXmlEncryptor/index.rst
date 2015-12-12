

CertificateXmlEncryptor Class
=============================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.XmlEncryption.IXmlEncryptor` that can perform XML encryption by using an X.509 certificate.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor`








Syntax
------

.. code-block:: csharp

   public sealed class CertificateXmlEncryptor : IInternalCertificateXmlEncryptor, IXmlEncryptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/XmlEncryption/CertificateXmlEncryptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor` given an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instance.
    
        
        
        
        :param certificate: The  with which to encrypt the key material.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
           public CertificateXmlEncryptor(X509Certificate2 certificate)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.Security.Cryptography.X509Certificates.X509Certificate2, System.IServiceProvider)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor` given an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instance
        and an :any:`System.IServiceProvider`\.
    
        
        
        
        :param certificate: The  with which to encrypt the key material.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public CertificateXmlEncryptor(X509Certificate2 certificate, IServiceProvider services)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.String, Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor` given a certificate's thumbprint and an 
        :any:`Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver` that can be used to resolve the certificate.
    
        
        
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate with which to
            encrypt the key material. The certificate must be locatable by .
        
        :type thumbprint: System.String
        
        
        :param certificateResolver: A resolver which can locate  objects.
        
        :type certificateResolver: Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver
    
        
        .. code-block:: csharp
    
           public CertificateXmlEncryptor(string thumbprint, ICertificateResolver certificateResolver)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.String, Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver, System.IServiceProvider)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor` given a certificate's thumbprint, an 
        :any:`Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver` that can be used to resolve the certificate, and
        an :any:`System.IServiceProvider`\.
    
        
        
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate with which to
            encrypt the key material. The certificate must be locatable by .
        
        :type thumbprint: System.String
        
        
        :param certificateResolver: A resolver which can locate  objects.
        
        :type certificateResolver: Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public CertificateXmlEncryptor(string thumbprint, ICertificateResolver certificateResolver, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        Encrypts the specified :any:`System.Xml.Linq.XElement` with an X.509 certificate.
    
        
        
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.XmlEncryption.EncryptedXmlInfo" /> that contains the encrypted value of
            <paramref name="plaintextElement" /> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
           public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    

