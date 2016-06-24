

HttpsConnectionFilterOptions Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Https`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel.Https

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions`








Syntax
------

.. code-block:: csharp

    public class HttpsConnectionFilterOptions








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions.HttpsConnectionFilterOptions()
    
        
    
        
        .. code-block:: csharp
    
            public HttpsConnectionFilterOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions.CheckCertificateRevocation
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CheckCertificateRevocation { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions.ClientCertificateMode
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode
    
        
        .. code-block:: csharp
    
            public ClientCertificateMode ClientCertificateMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions.ClientCertificateValidation
    
        
        :rtype: System.Func<System.Func`4>{System.Security.Cryptography.X509Certificates.X509Certificate2<System.Security.Cryptography.X509Certificates.X509Certificate2>, System.Security.Cryptography.X509Certificates.X509Chain<System.Security.Cryptography.X509Certificates.X509Chain>, System.Net.Security.SslPolicyErrors<System.Net.Security.SslPolicyErrors>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<X509Certificate2, X509Chain, SslPolicyErrors, bool> ClientCertificateValidation { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions.ServerCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
            public X509Certificate2 ServerCertificate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionFilterOptions.SslProtocols
    
        
        :rtype: System.Security.Authentication.SslProtocols
    
        
        .. code-block:: csharp
    
            public SslProtocols SslProtocols { get; set; }
    

