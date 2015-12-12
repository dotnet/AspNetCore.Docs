

AcceptVerbsAttribute Class
==========================



.. contents:: 
   :local:



Summary
-------

Specifies what HTTP methods an action supports.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.AcceptVerbsAttribute`








Syntax
------

.. code-block:: csharp

   public sealed class AcceptVerbsAttribute : Attribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/AcceptVerbsAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.AcceptVerbsAttribute(System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.AcceptVerbsAttribute` class.
    
        
        
        
        :param method: The HTTP method the action supports.
        
        :type method: System.String
    
        
        .. code-block:: csharp
    
           public AcceptVerbsAttribute(string method)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.AcceptVerbsAttribute(System.String[])
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.AcceptVerbsAttribute` class.
    
        
        
        
        :param methods: The HTTP methods the action supports.
        
        :type methods: System.String[]
    
        
        .. code-block:: csharp
    
           public AcceptVerbsAttribute(params string[] methods)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.HttpMethods
    
        
    
        Gets the HTTP methods the action supports.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> HttpMethods { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Order
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           int ? IRouteTemplateProvider.Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IRouteTemplateProvider.Template { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.Order
    
        
    
        Gets the route order. The order determines the order of route execution. Routes with a lower
        order value are tried first. When a route doesn't specify a value, it gets the value of the 
        :dn:prop:`Microsoft.AspNet.Mvc.RouteAttribute.Order` or a default value of 0 if the :any:`Microsoft.AspNet.Mvc.RouteAttribute`
        doesn't define a value on the controller.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.AcceptVerbsAttribute.Route
    
        
    
        The route template. May be null.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Route { get; set; }
    

