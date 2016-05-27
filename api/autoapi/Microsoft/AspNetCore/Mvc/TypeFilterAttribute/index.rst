

TypeFilterAttribute Class
=========================






A filter that creates another filter of type :dn:prop:`Microsoft.AspNetCore.Mvc.TypeFilterAttribute.ImplementationType`\, retrieving missing constructor
arguments from dependency injection if available there.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TypeFilterAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [DebuggerDisplay("TypeFilter: Type={ImplementationType} Order={Order}")]
    public class TypeFilterAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute.Arguments
    
        
    
        
        Gets or sets the non-service arguments to pass to the :dn:prop:`Microsoft.AspNetCore.Mvc.TypeFilterAttribute.ImplementationType` constructor.
    
        
        :rtype: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public object[] Arguments
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute.ImplementationType
    
        
    
        
        Gets the :any:`System.Type` of filter to create.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ImplementationType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute.TypeFilterAttribute(System.Type)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.TypeFilterAttribute` instance.
    
        
    
        
        :param type: The :any:`System.Type` of filter to create.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public TypeFilterAttribute(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TypeFilterAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

