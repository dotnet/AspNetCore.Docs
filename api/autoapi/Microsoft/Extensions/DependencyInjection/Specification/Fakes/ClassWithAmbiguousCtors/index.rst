

ClassWithAmbiguousCtors Class
=============================





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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors`








Syntax
------

.. code-block:: csharp

    public class ClassWithAmbiguousCtors








.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.Data1
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Data1
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.Data2
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Data2
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.FakeService
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        .. code-block:: csharp
    
            public IFakeService FakeService
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.ClassWithAmbiguousCtors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, System.Int32)
    
        
    
        
        :type service: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type data: System.Int32
    
        
        .. code-block:: csharp
    
            public ClassWithAmbiguousCtors(IFakeService service, int data)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.ClassWithAmbiguousCtors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, System.String)
    
        
    
        
        :type service: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
            public ClassWithAmbiguousCtors(IFakeService service, string data)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.ClassWithAmbiguousCtors(Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService, System.String, System.Int32)
    
        
    
        
        :type service: Microsoft.Extensions.DependencyInjection.Specification.Fakes.IFakeService
    
        
        :type data1: System.String
    
        
        :type data2: System.Int32
    
        
        .. code-block:: csharp
    
            public ClassWithAmbiguousCtors(IFakeService service, string data1, int data2)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.Specification.Fakes.ClassWithAmbiguousCtors.ClassWithAmbiguousCtors(System.String)
    
        
    
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
            public ClassWithAmbiguousCtors(string data)
    

