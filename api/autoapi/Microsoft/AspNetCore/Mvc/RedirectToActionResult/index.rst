

RedirectToActionResult Class
============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.RedirectToActionResult`








Syntax
------

.. code-block:: csharp

    public class RedirectToActionResult : ActionResult, IKeepTempDataResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToActionResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToActionResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToActionResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.ActionName
    
        
    
        
        Gets or sets the name of the action to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ActionName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.ControllerName
    
        
    
        
        Gets or sets the name of the controller to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ControllerName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.Permanent
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Permanent
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.RouteValues
    
        
    
        
        Gets or sets the route data to use for generating the URL.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary RouteValues
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.UrlHelper
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToActionResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.RedirectToActionResult(System.String, System.String, System.Object)
    
        
    
        
        :type actionName: System.String
    
        
        :type controllerName: System.String
    
        
        :type routeValues: System.Object
    
        
        .. code-block:: csharp
    
            public RedirectToActionResult(string actionName, string controllerName, object routeValues)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.RedirectToActionResult(System.String, System.String, System.Object, System.Boolean)
    
        
    
        
        :type actionName: System.String
    
        
        :type controllerName: System.String
    
        
        :type routeValues: System.Object
    
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
            public RedirectToActionResult(string actionName, string controllerName, object routeValues, bool permanent)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.RedirectToActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RedirectToActionResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void ExecuteResult(ActionContext context)
    

