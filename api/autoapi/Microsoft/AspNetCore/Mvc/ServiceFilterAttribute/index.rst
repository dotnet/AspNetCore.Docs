

ServiceFilterAttribute Class
============================






A filter that finds another filter in an :any:`System.IServiceProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ServiceFilterAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [DebuggerDisplay("ServiceFilter: Type={ServiceType} Order={Order}")]
    public class ServiceFilterAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.ServiceFilterAttribute(System.Type)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.ServiceFilterAttribute` instance.
    
        
    
        
        :param type: The :any:`System.Type` of filter to find.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public ServiceFilterAttribute(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.ServiceType
    
        
    
        
        Gets the :any:`System.Type` of filter to find.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ServiceType { get; }
    

