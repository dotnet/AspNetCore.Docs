

HttpMethodAttribute Class
=========================



.. contents:: 
   :local:



Summary
-------

Identifies an action that only supports a given set of HTTP methods.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class HttpMethodAttribute : Attribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/HttpMethodAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.HttpMethodAttribute(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute` with the given
        set of HTTP methods.
        <param name="httpMethods">The set of supported HTTP methods.</param>
    
        
        
        
        :type httpMethods: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public HttpMethodAttribute(IEnumerable<string> httpMethods)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.HttpMethodAttribute(System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute` with the given
        set of HTTP methods an the given route template.
    
        
        
        
        :param httpMethods: The set of supported methods.
        
        :type httpMethods: System.Collections.Generic.IEnumerable{System.String}
        
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
           public HttpMethodAttribute(IEnumerable<string> httpMethods, string template)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.HttpMethods
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> HttpMethods { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider.Order
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           int ? IRouteTemplateProvider.Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.Order
    
        
    
        Gets the route order. The order determines the order of route execution. Routes with a lower
        order value are tried first. When a route doesn't specify a value, it gets the value of the 
        :dn:prop:`Microsoft.AspNet.Mvc.RouteAttribute.Order` or a default value of 0 if the :any:`Microsoft.AspNet.Mvc.RouteAttribute`
        doesn't define a value on the controller.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.HttpMethodAttribute.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Template { get; }
    

