

TlsConnectionFeature Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.TlsConnectionFeature`








Syntax
------

.. code-block:: csharp

    public class TlsConnectionFeature : ITlsConnectionFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.TlsConnectionFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.TlsConnectionFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.TlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.TlsConnectionFeature.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
            public X509Certificate2 ClientCertificate { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.TlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.TlsConnectionFeature.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Cryptography.X509Certificates.X509Certificate2<System.Security.Cryptography.X509Certificates.X509Certificate2>}
    
        
        .. code-block:: csharp
    
            public Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken)
    

