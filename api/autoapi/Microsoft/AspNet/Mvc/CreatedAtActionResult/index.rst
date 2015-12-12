

CreatedAtActionResult Class
===========================



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
* :dn:cls:`Microsoft.AspNet.Mvc.CreatedAtActionResult`








Syntax
------

.. code-block:: csharp

   public class CreatedAtActionResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/CreatedAtActionResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtActionResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtActionResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.CreatedAtActionResult.CreatedAtActionResult(System.String, System.String, System.Object, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.CreatedAtActionResult` with the values
        provided.
    
        
        
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller to use for generating the URL.
        
        :type controllerName: System.String
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public CreatedAtActionResult(string actionName, string controllerName, object routeValues, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.CreatedAtActionResult.OnFormatting(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void OnFormatting(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedAtActionResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtActionResult.ActionName
    
        
    
        Gets or sets the name of the action to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ActionName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtActionResult.ControllerName
    
        
    
        Gets or sets the name of the controller to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtActionResult.RouteValues
    
        
    
        Gets or sets the route data to use for generating the URL.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedAtActionResult.UrlHelper
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.IUrlHelper` used to generate URLs.
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper UrlHelper { get; set; }
    

