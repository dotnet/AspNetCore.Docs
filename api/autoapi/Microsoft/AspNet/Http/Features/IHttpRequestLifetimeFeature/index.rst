

IHttpRequestLifetimeFeature Interface
=====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpRequestLifetimeFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/IHttpRequestLifetimeFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature.Abort()
    
        
    
        
        .. code-block:: csharp
    
           void Abort()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestLifetimeFeature.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           CancellationToken RequestAborted { get; set; }
    

