

CertificateResolver Class
=========================






A default implementation of :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver` that looks in the current user
and local machine certificate stores.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateResolver`








Syntax
------

.. code-block:: csharp

    public class CertificateResolver : ICertificateResolver








.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateResolver
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateResolver

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.CertificateResolver.ResolveCertificate(System.String)
    
        
    
        
        Locates an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` given its thumbprint.
    
        
    
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate to resolve.
        
        :type thumbprint: System.String
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
        :return: The resolved :any:`System.Security.Cryptography.X509Certificates.X509Certificate2`\, or null if the certificate cannot be found.
    
        
        .. code-block:: csharp
    
            public virtual X509Certificate2 ResolveCertificate(string thumbprint)
    

