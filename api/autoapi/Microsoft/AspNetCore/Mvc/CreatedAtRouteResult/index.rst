

CreatedAtRouteResult Class
==========================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that returns a Created (201) response with a Location header.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult`








Syntax
------

.. code-block:: csharp

    public class CreatedAtRouteResult : ObjectResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.RouteName
    
        
    
        
        Gets or sets the name of the route to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.RouteValues
    
        
    
        
        Gets or sets the route data to use for generating the URL.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary RouteValues
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.UrlHelper
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` used to generate URLs.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper UrlHelper
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.CreatedAtRouteResult(System.Object, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` class with the values
        provided.
    
        
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
    
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public CreatedAtRouteResult(object routeValues, object value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.CreatedAtRouteResult(System.String, System.Object, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` class with the values
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

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.OnFormatting(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void OnFormatting(ActionContext context)
    

