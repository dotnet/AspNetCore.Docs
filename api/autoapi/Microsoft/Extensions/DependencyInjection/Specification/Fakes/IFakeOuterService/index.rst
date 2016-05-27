

IFakeOuterService Interface
===========================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection.Specification.Fakes`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Specification.Tests

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFakeOuterService








.. dn:interface:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeOuterService
    :hidden:

.. dn:interface:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeOuterService

Properties
----------

.. dn:interface:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeOuterService
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeOuterService.MultipleServices
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService<Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeMultipleService>}
    
        
        .. code-block:: csharp
    
            IEnumerable<IFakeMultipleService> MultipleServices
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeOuterService.SingleService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        .. code-block:: csharp
    
            IFakeService SingleService
            {
                get;
            }
    

