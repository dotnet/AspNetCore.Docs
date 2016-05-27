

ICertificateResolver Interface
==============================






Provides services for locating :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.XmlEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICertificateResolver








.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.XmlEncryption.ICertificateResolver.ResolveCertificate(System.String)
    
        
    
        
        Locates an :any:`System.Security.Cryptography.X509Certificates.X509Certificate2` given its thumbprint.
    
        
    
        
        :param thumbprint: The thumbprint (as a hex string) of the certificate to resolve.
        
        :type thumbprint: System.String
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
        :return: The resolved :any:`System.Security.Cryptography.X509Certificates.X509Certificate2`\, or null if the certificate cannot be found.
    
        
        .. code-block:: csharp
    
            X509Certificate2 ResolveCertificate(string thumbprint)
    

