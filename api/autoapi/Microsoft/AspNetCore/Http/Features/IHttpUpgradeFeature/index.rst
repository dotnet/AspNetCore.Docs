

IHttpUpgradeFeature Interface
=============================





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

    public interface IHttpUpgradeFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature.IsUpgradableRequest
    
        
    
        
        Indicates if the server can upgrade this request to an opaque, bidirectional stream.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsUpgradableRequest { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature.UpgradeAsync()
    
        
    
        
        Attempt to upgrade the request to an opaque, bidirectional stream. The response status code
        and headers need to be set before this is invoked. Check :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature.IsUpgradableRequest`
        before invoking.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.IO.Stream<System.IO.Stream>}
    
        
        .. code-block:: csharp
    
            Task<Stream> UpgradeAsync()
    

