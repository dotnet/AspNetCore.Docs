

FakeService Class
=================





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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService`








Syntax
------

.. code-block:: csharp

    public class FakeService : IFakeEveryService, IFakeMultipleService, IFakeScopedService, IFakeServiceInstance, IFakeSingletonService, IFakeService, IFakeOpenGenericService<PocoClass>, IDisposable








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService.Disposed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Disposed { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeService.Value
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.PocoClass
    
        
        .. code-block:: csharp
    
            public PocoClass Value { get; set; }
    

