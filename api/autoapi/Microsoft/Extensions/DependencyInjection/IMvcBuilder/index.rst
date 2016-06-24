

IMvcBuilder Interface
=====================






An interface for configuring MVC services.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IMvcBuilder








.. dn:interface:: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    :hidden:

.. dn:interface:: Microsoft.Extensions.DependencyInjection.IMvcBuilder

Properties
----------

.. dn:interface:: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` where :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\s
        are configured.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            ApplicationPartManager PartManager { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.IMvcBuilder.Services
    
        
    
        
        Gets the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` where MVC services are configured.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            IServiceCollection Services { get; }
    

