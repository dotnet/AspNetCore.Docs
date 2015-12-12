

ICertificateResolver Interface
==============================



.. contents:: 
   :local:



Summary
-------

Provides services for locating :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instances.











Syntax
------

.. code-block:: csharp

   public interface ICertificateResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/XmlEncryption/ICertificateResolver.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.XmlEncryption.ICertificateResolver.ResolveCertificate(System.String)
    
        
    
        Locates an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` given its thumbprint.
    
        
        
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate to resolve.
        
        :type thumbprint: System.String
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
        :return: The resolved <see cref="T:System.Security.Cryptography.X509Certificates.X509Certificate2" />, or null if the certificate cannot be found.
    
        
        .. code-block:: csharp
    
           X509Certificate2 ResolveCertificate(string thumbprint)
    

