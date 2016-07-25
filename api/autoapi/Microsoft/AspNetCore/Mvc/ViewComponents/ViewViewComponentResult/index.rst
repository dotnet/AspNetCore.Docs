

ViewViewComponentResult Class
=============================






A :any:`Microsoft.AspNetCore.Mvc.IViewComponentResult` that renders a partial view when executed.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult`








Syntax
------

.. code-block:: csharp

    public class ViewViewComponentResult : IViewComponentResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.Execute(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Locates and renders a view specified by :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewName`\. If :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewName` is <code>null</code>,
        then the view name searched for is<code>"Default"</code>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the current component execution.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
            public void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ExecuteAsync(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        Locates and renders a view specified by :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewName`\. If :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewName` is <code>null</code>,
        then the view name searched for is<code>"Default"</code>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext` for the current component execution.
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` which will complete when view rendering is completed.
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ViewComponentContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.TempData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` instance.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewEngine
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewEngine`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
            public IViewEngine ViewEngine { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult.ViewName
    
        
    
        
        Gets or sets the view name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ViewName { get; set; }
    

