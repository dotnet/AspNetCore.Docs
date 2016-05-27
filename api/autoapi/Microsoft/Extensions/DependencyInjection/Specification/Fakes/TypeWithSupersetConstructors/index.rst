

TypeWithSupersetConstructors Class
==================================





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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors`








Syntax
------

.. code-block:: csharp

    public class TypeWithSupersetConstructors








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.FactoryService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        .. code-block:: csharp
    
            public IFactoryService FactoryService
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.MultipleService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService
    
        
        .. code-block:: csharp
    
            public IFakeMultipleService MultipleService
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.ScopedService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeScopedService
    
        
        .. code-block:: csharp
    
            public IFakeScopedService ScopedService
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.Service
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        .. code-block:: csharp
    
            public IFakeService Service
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.TypeWithSupersetConstructors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService)
    
        
    
        
        :type factoryService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        .. code-block:: csharp
    
            public TypeWithSupersetConstructors(IFactoryService factoryService)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.TypeWithSupersetConstructors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeScopedService)
    
        
    
        
        :type multipleService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService
    
        
        :type factoryService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        :type fakeService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type scopedService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeScopedService
    
        
        .. code-block:: csharp
    
            public TypeWithSupersetConstructors(IFakeMultipleService multipleService, IFactoryService factoryService, IFakeService fakeService, IFakeScopedService scopedService)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.TypeWithSupersetConstructors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService)
    
        
    
        
        :type fakeService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        .. code-block:: csharp
    
            public TypeWithSupersetConstructors(IFakeService fakeService)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.TypeWithSupersetConstructors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService)
    
        
    
        
        :type fakeService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type factoryService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        .. code-block:: csharp
    
            public TypeWithSupersetConstructors(IFakeService fakeService, IFactoryService factoryService)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.TypeWithSupersetConstructors.TypeWithSupersetConstructors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService, Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService)
    
        
    
        
        :type fakeService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type multipleService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService
    
        
        :type factoryService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFactoryService
    
        
        .. code-block:: csharp
    
            public TypeWithSupersetConstructors(IFakeService fakeService, IFakeMultipleService multipleService, IFactoryService factoryService)
    

