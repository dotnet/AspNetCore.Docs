

ITlsConnectionFeature Interface
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITlsConnectionFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature.ClientCertificate
    
        
    
        
        Synchronously retrieves the client certificate, if any.
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
            X509Certificate2 ClientCertificate { get; set; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
    
        
        Asynchronously retrieves the client certificate, if any.
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Cryptography.X509Certificates.X509Certificate2<System.Security.Cryptography.X509Certificates.X509Certificate2>}
    
        
        .. code-block:: csharp
    
            Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken)
    

