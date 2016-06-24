

IMvcCoreBuilder Interface
=========================






An interface for configuring essential MVC services.


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

    public interface IMvcCoreBuilder








.. dn:interface:: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    :hidden:

.. dn:interface:: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder

Properties
----------

.. dn:interface:: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` where :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\s
        are configured.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            ApplicationPartManager PartManager { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.Services
    
        
    
        
        Gets the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` where essential MVC services are configured.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            IServiceCollection Services { get; }
    

