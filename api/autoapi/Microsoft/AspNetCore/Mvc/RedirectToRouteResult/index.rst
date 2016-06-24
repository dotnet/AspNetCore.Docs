

RedirectToRouteResult Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult`








Syntax
------

.. code-block:: csharp

    public class RedirectToRouteResult : ActionResult, IKeepTempDataResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.RedirectToRouteResult(System.Object)
    
        
    
        
        :type routeValues: System.Object
    
        
        .. code-block:: csharp
    
            public RedirectToRouteResult(object routeValues)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.RedirectToRouteResult(System.String, System.Object)
    
        
    
        
        :type routeName: System.String
    
        
        :type routeValues: System.Object
    
        
        .. code-block:: csharp
    
            public RedirectToRouteResult(string routeName, object routeValues)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.RedirectToRouteResult(System.String, System.Object, System.Boolean)
    
        
    
        
        :type routeName: System.String
    
        
        :type routeValues: System.Object
    
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
            public RedirectToRouteResult(string routeName, object routeValues, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.Permanent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Permanent { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.RouteName
    
        
    
        
        Gets or sets the name of the route to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.RouteValues
    
        
    
        
        Gets or sets the route data to use for generating the URL.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToRouteResult.UrlHelper
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` used to generate URLs.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper UrlHelper { get; set; }
    

