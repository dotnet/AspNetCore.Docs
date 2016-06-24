

CreatedAtActionResult Class
===========================






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
* :dn:cls:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult`








Syntax
------

.. code-block:: csharp

    public class CreatedAtActionResult : ObjectResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult.CreatedAtActionResult(System.String, System.String, System.Object, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` with the values
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
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult.ActionName
    
        
    
        
        Gets or sets the name of the action to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ActionName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult.ControllerName
    
        
    
        
        Gets or sets the name of the controller to use for generating the URL.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ControllerName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult.RouteValues
    
        
    
        
        Gets or sets the route data to use for generating the URL.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult.UrlHelper
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` used to generate URLs.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper UrlHelper { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.CreatedAtActionResult.OnFormatting(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void OnFormatting(ActionContext context)
    

