

CreatedAtRouteResult Class
==========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ActionResult` that returns a Created (201) response with a Location header.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNet.Mvc.CreatedAtRouteResult`








Syntax
------

.. code-block:: csharp

   public class CreatedAtRouteResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/CreatedAtRouteResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtRouteResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtRouteResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.CreatedAtRouteResult.CreatedAtRouteResult(System.Object, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.CreatedAtRouteResult` class with the values
        provided.
    
        
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public CreatedAtRouteResult(object routeValues, object value)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.CreatedAtRouteResult.CreatedAtRouteResult(System.String, System.Object, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.CreatedAtRouteResult` class with the values
        provided.
    
        
        
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public CreatedAtRouteResult(string routeName, object routeValues, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtRouteResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.CreatedAtRouteResult.OnFormatting(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void OnFormatting(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtRouteResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtRouteResult.RouteName
    
        
    
        Gets or sets the name of the route to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtRouteResult.RouteValues
    
        
    
        Gets or sets the route data to use for generating the URL.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtRouteResult.UrlHelper
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.IUrlHelper` used to generate URLs.
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper UrlHelper { get; set; }
    

