

TypeFilterAttribute Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.TypeFilterAttribute`








Syntax
------

.. code-block:: csharp

   public class TypeFilterAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/TypeFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TypeFilterAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TypeFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TypeFilterAttribute.TypeFilterAttribute(System.Type)
    
        
        
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
           public TypeFilterAttribute(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TypeFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TypeFilterAttribute.CreateInstance(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TypeFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TypeFilterAttribute.Arguments
    
        
        :rtype: System.Object[]
    
        
        .. code-block:: csharp
    
           public object[] Arguments { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TypeFilterAttribute.ImplementationType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ImplementationType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TypeFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

