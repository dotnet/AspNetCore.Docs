

RazorViewEngine Class
=====================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`








Syntax
------

.. code-block:: csharp

    public class RazorViewEngine : IRazorViewEngine, IViewEngine








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.AreaViewLocationFormats
    
        
    
        
        Gets the locations where this instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` will search for views within an
        area.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<string> AreaViewLocationFormats
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewLocationFormats
    
        
    
        
        Gets the locations where this instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` will search for views.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<string> ViewLocationFormats
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewLookupCache
    
        
    
        
        A cache for results of view lookups.
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            protected IMemoryCache ViewLookupCache
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.RazorViewEngine(Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider, Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator, System.Text.Encodings.Web.HtmlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.
    
        
    
        
        :type pageFactory: Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider
    
        
        :type pageActivator: Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator
    
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>}
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public RazorViewEngine(IRazorPageFactoryProvider pageFactory, IRazorPageActivator pageActivator, HtmlEncoder htmlEncoder, IOptions<RazorViewEngineOptions> optionsAccessor, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.FindPage(Microsoft.AspNetCore.Mvc.ActionContext, System.String)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type pageName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
    
        
        .. code-block:: csharp
    
            public RazorPageResult FindPage(ActionContext context, string pageName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.FindView(Microsoft.AspNetCore.Mvc.ActionContext, System.String, System.Boolean)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type viewName: System.String
    
        
        :type isMainPage: System.Boolean
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
            public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.GetAbsolutePath(System.String, System.String)
    
        
    
        
        :type executingFilePath: System.String
    
        
        :type pagePath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GetAbsolutePath(string executingFilePath, string pagePath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.GetNormalizedRouteValue(Microsoft.AspNetCore.Mvc.ActionContext, System.String)
    
        
    
        
        Gets the case-normalized route value for the specified route <em>key</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param key: The route key to lookup.
        
        :type key: System.String
        :rtype: System.String
        :return: The value corresponding to the key.
    
        
        .. code-block:: csharp
    
            public static string GetNormalizedRouteValue(ActionContext context, string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.GetPage(System.String, System.String)
    
        
    
        
        :type executingFilePath: System.String
    
        
        :type pagePath: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
    
        
        .. code-block:: csharp
    
            public RazorPageResult GetPage(string executingFilePath, string pagePath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.GetView(System.String, System.String, System.Boolean)
    
        
    
        
        :type executingFilePath: System.String
    
        
        :type viewPath: System.String
    
        
        :type isMainPage: System.Boolean
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
            public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
    

