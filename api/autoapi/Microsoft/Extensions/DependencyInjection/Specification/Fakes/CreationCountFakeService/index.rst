

CreationCountFakeService Class
==============================





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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService`








Syntax
------

.. code-block:: csharp

    public class CreationCountFakeService








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService.InstanceCount
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static int InstanceCount
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService.InstanceId
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int InstanceId
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService.CreationCountFakeService(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService)
    
        
    
        
        :type dependency: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        .. code-block:: csharp
    
            public CreationCountFakeService(IFakeService dependency)
    

Fields
------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.CreationCountFakeService.InstanceLock
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public static readonly object InstanceLock
    

