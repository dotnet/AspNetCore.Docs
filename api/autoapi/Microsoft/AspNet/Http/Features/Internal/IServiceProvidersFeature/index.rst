

IServiceProvidersFeature Interface
==================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IServiceProvidersFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/IServiceProvidersFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.Internal.IServiceProvidersFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.Internal.IServiceProvidersFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.IServiceProvidersFeature.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.IServiceProvidersFeature.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           IServiceProvider RequestServices { get; set; }
    

