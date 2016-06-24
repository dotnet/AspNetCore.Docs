

IHttpRequestLifetimeFeature Interface
=====================================





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

    public interface IHttpRequestLifetimeFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature.Abort()
    
        
    
        
        Forcefully aborts the request if it has not already completed. This will result in
        RequestAborted being triggered.
    
        
    
        
        .. code-block:: csharp
    
            void Abort()
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature.RequestAborted
    
        
    
        
        A :any:`System.Threading.CancellationToken` that fires if the request is aborted and
        the application should cease processing. The token will not fire if the request
        completes successfully.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            CancellationToken RequestAborted { get; set; }
    

