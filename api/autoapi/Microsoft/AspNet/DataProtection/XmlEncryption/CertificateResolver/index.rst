

CertificateResolver Class
=========================



.. contents:: 
   :local:



Summary
-------

A default implementation of :any:`Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver` that looks in the current user
and local machine certificate stores.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.XmlEncryption.CertificateResolver`








Syntax
------

.. code-block:: csharp

   public class CertificateResolver : ICertificateResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/XmlEncryption/CertificateResolver.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateResolver

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.CertificateResolver.ResolveCertificate(System.String)
    
        
    
        Locates an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` given its thumbprint.
    
        
        
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate to resolve.
        
        :type thumbprint: System.String
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
        :return: The resolved <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate2" />, or null if the certificate cannot be found.
    
        
        .. code-block:: csharp
    
           public virtual X509Certificate2 ResolveCertificate(string thumbprint)
    

