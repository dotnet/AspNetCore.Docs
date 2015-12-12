

RedirectToRouteResult Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.RedirectToRouteResult`








Syntax
------

.. code-block:: csharp

   public class RedirectToRouteResult : ActionResult, IKeepTempDataResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/RedirectToRouteResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RedirectToRouteResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectToRouteResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectToRouteResult.RedirectToRouteResult(System.Object)
    
        
        
        
        :type routeValues: System.Object
    
        
        .. code-block:: csharp
    
           public RedirectToRouteResult(object routeValues)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectToRouteResult.RedirectToRouteResult(System.String, System.Object)
    
        
        
        
        :type routeName: System.String
        
        
        :type routeValues: System.Object
    
        
        .. code-block:: csharp
    
           public RedirectToRouteResult(string routeName, object routeValues)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectToRouteResult.RedirectToRouteResult(System.String, System.Object, System.Boolean)
    
        
        
        
        :type routeName: System.String
        
        
        :type routeValues: System.Object
        
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
           public RedirectToRouteResult(string routeName, object routeValues, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectToRouteResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.RedirectToRouteResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectToRouteResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToRouteResult.Permanent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Permanent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToRouteResult.RouteName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToRouteResult.RouteValues
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToRouteResult.UrlHelper
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper UrlHelper { get; set; }
    

