

ServiceFilterAttribute Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ServiceFilterAttribute`








Syntax
------

.. code-block:: csharp

   public class ServiceFilterAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ServiceFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ServiceFilterAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ServiceFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ServiceFilterAttribute.ServiceFilterAttribute(System.Type)
    
        
        
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
           public ServiceFilterAttribute(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ServiceFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ServiceFilterAttribute.CreateInstance(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNet.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
           public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ServiceFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ServiceFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ServiceFilterAttribute.ServiceType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ServiceType { get; }
    

