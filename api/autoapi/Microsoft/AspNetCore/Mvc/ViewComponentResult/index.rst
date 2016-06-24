

ViewComponentResult Class
=========================






An :any:`Microsoft.AspNetCore.Mvc.IActionResult` which renders a view component to the response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponentResult`








Syntax
------

.. code-block:: csharp

    public class ViewComponentResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.Arguments
    
        
    
        
        Gets or sets the arguments provided to the view component.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Arguments { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.ContentType
    
        
    
        
        Gets or sets the Content-Type header for the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.StatusCode
    
        
    
        
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.TempData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` for this result.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.ViewComponentName
    
        
    
        
        Gets or sets the name of the view component to invoke. Will be ignored if :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponentResult.ViewComponentType`
        is set to a non-<code>null</code> value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ViewComponentName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.ViewComponentType
    
        
    
        
        Gets or sets the type of the view component to invoke.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ViewComponentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.ViewData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` for this result.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentResult.ViewEngine
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine` used to locate views.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
            public IViewEngine ViewEngine { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponentResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

