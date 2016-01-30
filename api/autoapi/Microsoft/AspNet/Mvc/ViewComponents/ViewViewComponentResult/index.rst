

ViewViewComponentResult Class
=============================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.IViewComponentResult` that renders a partial view when executed.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult`








Syntax
------

.. code-block:: csharp

   public class ViewViewComponentResult : IViewComponentResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/ViewViewComponentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.Execute(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Locates and renders a view specified by :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewName`\. If :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewName` is <c>null</c>,
        then the view name searched for is<c>"Default"</c>.
    
        
        
        
        :param context: The  for the current component execution.
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           public void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ExecuteAsync(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Locates and renders a view specified by :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewName`\. If :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewName` is <c>null</c>,
        then the view name searched for is<c>"Default"</c>.
    
        
        
        
        :param context: The  for the current component execution.
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which will complete when view rendering is completed.
    
        
        .. code-block:: csharp
    
           public Task ExecuteAsync(ViewComponentContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.TempData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewEngine
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewEngine`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
           public IViewEngine ViewEngine { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewViewComponentResult.ViewName
    
        
    
        Gets or sets the view name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ViewName { get; set; }
    

