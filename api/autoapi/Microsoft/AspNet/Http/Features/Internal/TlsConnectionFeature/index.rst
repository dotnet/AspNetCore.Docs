

TlsConnectionFeature Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature`








Syntax
------

.. code-block:: csharp

   public class TlsConnectionFeature : ITlsConnectionFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/TlsConnectionFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature.TlsConnectionFeature()
    
        
    
        
        .. code-block:: csharp
    
           public TlsConnectionFeature()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature.GetClientCertificateAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Security.Cryptography.X509Certificates.X509Certificate2}
    
        
        .. code-block:: csharp
    
           public Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.TlsConnectionFeature.ClientCertificate
    
        
        :rtype: System.Security.Cryptography.X509Certificates.X509Certificate2
    
        
        .. code-block:: csharp
    
           public X509Certificate2 ClientCertificate { get; set; }
    

