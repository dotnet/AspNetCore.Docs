

IHttpUpgradeFeature Interface
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpUpgradeFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/IHttpUpgradeFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpUpgradeFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpUpgradeFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.IHttpUpgradeFeature.UpgradeAsync()
    
        
        :rtype: System.Threading.Tasks.Task{System.IO.Stream}
    
        
        .. code-block:: csharp
    
           Task<Stream> UpgradeAsync()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpUpgradeFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpUpgradeFeature.IsUpgradableRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsUpgradableRequest { get; }
    

