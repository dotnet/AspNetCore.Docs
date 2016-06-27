

FakeOuterService Class
======================





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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService`








Syntax
------

.. code-block:: csharp

    public class FakeOuterService : IFakeOuterService








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService

Constructors
------------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService.FakeOuterService(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService>)
    
        
    
        
        :type singleService: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type multipleServices: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService<Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService>}
    
        
        .. code-block:: csharp
    
            public FakeOuterService(IFakeService singleService, IEnumerable<IFakeMultipleService> multipleServices)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService.MultipleServices
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService<Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IFakeMultipleService> MultipleServices { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.FakeOuterService.SingleService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        .. code-block:: csharp
    
            public IFakeService SingleService { get; }
    

