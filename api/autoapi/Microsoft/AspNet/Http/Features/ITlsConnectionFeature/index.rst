

ITlsConnectionFeature Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ITlsConnectionFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/ITlsConnectionFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.ITlsConnectionFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.ITlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.ITlsConnectionFeature.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
    
        Asynchronously retrieves the client certificate, if any.
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Security.Cryptography.X509Certificates.X509Certificate2}
    
        
        .. code-block:: csharp
    
           Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.ITlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.ITlsConnectionFeature.ClientCertificate
    
        
    
        Synchronously retrieves the client certificate, if any.
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
           X509Certificate2 ClientCertificate { get; set; }
    

