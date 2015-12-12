

RedirectToActionResult Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.RedirectToActionResult`








Syntax
------

.. code-block:: csharp

   public class RedirectToActionResult : ActionResult, IKeepTempDataResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/RedirectToActionResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RedirectToActionResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectToActionResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectToActionResult.RedirectToActionResult(System.String, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type actionName: System.String
        
        
        :type controllerName: System.String
        
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public RedirectToActionResult(string actionName, string controllerName, IDictionary<string, object> routeValues)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RedirectToActionResult.RedirectToActionResult(System.String, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Boolean)
    
        
        
        
        :type actionName: System.String
        
        
        :type controllerName: System.String
        
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
           public RedirectToActionResult(string actionName, string controllerName, IDictionary<string, object> routeValues, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectToActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.RedirectToActionResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.RedirectToActionResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToActionResult.ActionName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ActionName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToActionResult.ControllerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToActionResult.Permanent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Permanent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToActionResult.RouteValues
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RedirectToActionResult.UrlHelper
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper UrlHelper { get; set; }
    

