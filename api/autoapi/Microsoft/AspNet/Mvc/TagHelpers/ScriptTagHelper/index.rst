

ScriptTagHelper Class
=====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;script&gt; elements that supports fallback src paths.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper`








Syntax
------

.. code-block:: csharp

   public class ScriptTagHelper : UrlResolutionTagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/ScriptTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.ScriptTagHelper(Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper>, Microsoft.AspNet.Hosting.IHostingEnvironment, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.Extensions.WebEncoders.IHtmlEncoder, Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder, Microsoft.AspNet.Mvc.IUrlHelper)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper`\.
    
        
        
        
        :param logger: The .
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper}
        
        
        :param hostingEnvironment: The .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param cache: The .
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :param htmlEncoder: The .
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :param javaScriptEncoder: The .
        
        :type javaScriptEncoder: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
        
        
        :param urlHelper: The .
        
        :type urlHelper: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public ScriptTagHelper(ILogger<ScriptTagHelper> logger, IHostingEnvironment hostingEnvironment, IMemoryCache cache, IHtmlEncoder htmlEncoder, IJavaScriptStringEncoder javaScriptEncoder, IUrlHelper urlHelper)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.AppendVersion
    
        
    
        Value indicating if file version should be appended to src urls.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? AppendVersion { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.Cache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           protected IMemoryCache Cache { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.FallbackSrc
    
        
    
        The URL of a Script tag to fallback to in the case the primary one fails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackSrc { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.FallbackSrcExclude
    
        
    
        A comma separated list of globbed file patterns of JavaScript scripts to exclude from the fallback list, in
        the case the primary one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.FallbackSrcInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackSrcExclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.FallbackSrcInclude
    
        
    
        A comma separated list of globbed file patterns of JavaScript scripts to fallback to in the case the
        primary one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackSrcInclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.FallbackTestExpression
    
        
    
        The script method defined in the primary script to use for the fallback test.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackTestExpression { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.GlobbingUrlBuilder
    
        
        :rtype: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    
        
        .. code-block:: csharp
    
           protected GlobbingUrlBuilder GlobbingUrlBuilder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNet.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
           protected IHostingEnvironment HostingEnvironment { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.JavaScriptEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           protected IJavaScriptStringEncoder JavaScriptEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper}
    
        
        .. code-block:: csharp
    
           protected ILogger<ScriptTagHelper> Logger { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.Src
    
        
    
        Address of the external script to use.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Src { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.SrcExclude
    
        
    
        A comma separated list of globbed file patterns of JavaScript scripts to exclude from loading.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.SrcInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SrcExclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.SrcInclude
    
        
    
        A comma separated list of globbed file patterns of JavaScript scripts to load.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SrcInclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ScriptTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

