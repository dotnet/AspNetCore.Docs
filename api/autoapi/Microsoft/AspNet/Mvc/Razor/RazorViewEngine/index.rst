

RazorViewEngine Class
=====================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.Razor.IRazorViewEngine`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine`








Syntax
------

.. code-block:: csharp

   public class RazorViewEngine : IRazorViewEngine, IViewEngine





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorViewEngine.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.RazorViewEngine(Microsoft.AspNet.Mvc.Razor.IRazorPageFactory, Microsoft.AspNet.Mvc.Razor.IRazorViewFactory, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>, Microsoft.AspNet.Mvc.Razor.IViewLocationCache)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` class.
    
        
        
        
        :param pageFactory: The page factory used for creating  instances.
        
        :type pageFactory: Microsoft.AspNet.Mvc.Razor.IRazorPageFactory
        
        
        :type viewFactory: Microsoft.AspNet.Mvc.Razor.IRazorViewFactory
        
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
        
        
        :type viewLocationCache: Microsoft.AspNet.Mvc.Razor.IViewLocationCache
    
        
        .. code-block:: csharp
    
           public RazorViewEngine(IRazorPageFactory pageFactory, IRazorViewFactory viewFactory, IOptions<RazorViewEngineOptions> optionsAccessor, IViewLocationCache viewLocationCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.FindPage(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type pageName: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.RazorPageResult
    
        
        .. code-block:: csharp
    
           public RazorPageResult FindPage(ActionContext context, string pageName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.FindPartialView(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type partialViewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public ViewEngineResult FindPartialView(ActionContext context, string partialViewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.FindView(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type viewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public ViewEngineResult FindView(ActionContext context, string viewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.GetNormalizedRouteValue(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
    
        Gets the case-normalized route value for the specified route ``key``.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param key: The route key to lookup.
        
        :type key: System.String
        :rtype: System.String
        :return: The value corresponding to the key.
    
        
        .. code-block:: csharp
    
           public static string GetNormalizedRouteValue(ActionContext context, string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.AreaViewLocationFormats
    
        
    
        Gets the locations where this instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` will search for views within an
        area.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<string> AreaViewLocationFormats { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorViewEngine.ViewLocationFormats
    
        
    
        Gets the locations where this instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` will search for views.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<string> ViewLocationFormats { get; }
    

