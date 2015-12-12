

ViewComponentResult Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.IActionResult` which renders a view component to the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponentResult`








Syntax
------

.. code-block:: csharp

   public class ViewComponentResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponentResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponentResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.Arguments
    
        
    
        Gets or sets the arguments provided to the view component.
    
        
        :rtype: System.Object[]
    
        
        .. code-block:: csharp
    
           public object[] Arguments { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.ContentType
    
        
    
        Gets or sets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` representing the Content-Type header of the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.StatusCode
    
        
    
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.TempData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` for this result.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.ViewComponentName
    
        
    
        Gets or sets the name of the view component to invoke. Will be ignored if :dn:prop:`Microsoft.AspNet.Mvc.ViewComponentResult.ViewComponentType`
        is set to a non-<c>null</c> value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ViewComponentName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.ViewComponentType
    
        
    
        Gets or sets the type of the view component to invoke.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ViewComponentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.ViewData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` for this result.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponentResult.ViewEngine
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine` used to locate views.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
           public IViewEngine ViewEngine { get; set; }
    

