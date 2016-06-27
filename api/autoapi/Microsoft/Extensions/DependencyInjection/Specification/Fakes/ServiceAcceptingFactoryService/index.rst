

ServiceAcceptingFactoryService Class
====================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection.Specification.Fakes`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Specification.Tests

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService`








Syntax
------

.. code-block:: csharp

    public class ServiceAcceptingFactoryService








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService

Constructors
------------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService.ServiceAcceptingFactoryService(Microsoft.Extensions.DependencyInjection.Specification.Fakes.ScopedFactoryService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService)
    
        
    
        
        :type scopedService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ScopedFactoryService
    
        
        :type transientService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        .. code-block:: csharp
    
            public ServiceAcceptingFactoryService(ScopedFactoryService scopedService, IFactoryService transientService)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService.ScopedService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ScopedFactoryService
    
        
        .. code-block:: csharp
    
            public ScopedFactoryService ScopedService { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ServiceAcceptingFactoryService.TransientService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        .. code-block:: csharp
    
            public IFactoryService TransientService { get; }
    

