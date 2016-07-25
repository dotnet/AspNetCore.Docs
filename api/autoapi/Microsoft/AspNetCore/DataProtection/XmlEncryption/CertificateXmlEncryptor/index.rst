

CertificateXmlEncryptor Class
=============================






An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` that can perform XML encryption by using an X.509 certificate.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.XmlEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor`








Syntax
------

.. code-block:: csharp

    public sealed class CertificateXmlEncryptor : IInternalCertificateXmlEncryptor, IXmlEncryptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor` given an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instance.
    
        
    
        
        :param certificate: The :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` with which to encrypt the key material.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
            public CertificateXmlEncryptor(X509Certificate2 certificate)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.Security.Cryptography.X509Certificates.X509Certificate2, System.IServiceProvider)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor` given an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instance
        and an :any:`System.IServiceProvider`\.
    
        
    
        
        :param certificate: The :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` with which to encrypt the key material.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public CertificateXmlEncryptor(X509Certificate2 certificate, IServiceProvider services)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.String, Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor` given a certificate's thumbprint and an 
        :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver` that can be used to resolve the certificate.
    
        
    
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate with which to
            encrypt the key material. The certificate must be locatable by <em>certificateResolver</em>.
        
        :type thumbprint: System.String
    
        
        :param certificateResolver: A resolver which can locate :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` objects.
        
        :type certificateResolver: Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver
    
        
        .. code-block:: csharp
    
            public CertificateXmlEncryptor(string thumbprint, ICertificateResolver certificateResolver)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor.CertificateXmlEncryptor(System.String, Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver, System.IServiceProvider)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor` given a certificate's thumbprint, an 
        :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver` that can be used to resolve the certificate, and
        an :any:`System.IServiceProvider`\.
    
        
    
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate with which to
            encrypt the key material. The certificate must be locatable by <em>certificateResolver</em>.
        
        :type thumbprint: System.String
    
        
        :param certificateResolver: A resolver which can locate :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` objects.
        
        :type certificateResolver: Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public CertificateXmlEncryptor(string thumbprint, ICertificateResolver certificateResolver, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateXmlEncryptor.Encrypt(System.Xml.Linq.XElement)
    
        
    
        
        Encrypts the specified :any:`System.Xml.Linq.XElement` with an X.509 certificate.
    
        
    
        
        :param plaintextElement: The plaintext to encrypt.
        
        :type plaintextElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo
        :return: 
            An :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.EncryptedXmlInfo` that contains the encrypted value of
            <em>plaintextElement</em> along with information about how to
            decrypt it.
    
        
        .. code-block:: csharp
    
            public EncryptedXmlInfo Encrypt(XElement plaintextElement)
    

