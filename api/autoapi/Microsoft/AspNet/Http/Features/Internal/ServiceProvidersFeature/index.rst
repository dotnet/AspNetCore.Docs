

ServiceProvidersFeature Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.ServiceProvidersFeature`








Syntax
------

.. code-block:: csharp

   public class ServiceProvidersFeature : IServiceProvidersFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/ServiceProvidersFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.ServiceProvidersFeature

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.ServiceProvidersFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.ServiceProvidersFeature.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.ServiceProvidersFeature.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider RequestServices { get; set; }
    

