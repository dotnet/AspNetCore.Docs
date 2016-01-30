

ViewResult Class
================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ActionResult` that renders a view to the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewResult`








Syntax
------

.. code-block:: csharp

   public class ViewResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewResult.ContentType
    
        
    
        Gets or sets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` representing the Content-Type header of the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewResult.StatusCode
    
        
    
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewResult.TempData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` for this result.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewResult.ViewData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` for this result.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewResult.ViewEngine
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine` used to locate views.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
           public IViewEngine ViewEngine { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewResult.ViewName
    
        
    
        Gets or sets the name of the view to render.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ViewName { get; set; }
    

