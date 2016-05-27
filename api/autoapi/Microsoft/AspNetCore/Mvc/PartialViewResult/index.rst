

PartialViewResult Class
=======================






Represents an :any:`Microsoft.AspNetCore.Mvc.ActionResult` that renders a partial view to the response.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.PartialViewResult`








Syntax
------

.. code-block:: csharp

    public class PartialViewResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.PartialViewResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.PartialViewResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.PartialViewResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PartialViewResult.ContentType
    
        
    
        
        Gets or sets the Content-Type header for the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PartialViewResult.StatusCode
    
        
    
        
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? StatusCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PartialViewResult.TempData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` used for rendering the view for this result.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary TempData
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PartialViewResult.ViewData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` used for rendering the view for this result.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PartialViewResult.ViewEngine
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine` used to locate views.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
            public IViewEngine ViewEngine
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.PartialViewResult.ViewName
    
        
    
        
        Gets or sets the name of the partial view to render.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ViewName
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.PartialViewResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.PartialViewResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

