

LinkTagHelper Class
===================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;link&gt; elements that supports fallback href paths.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper`








Syntax
------

.. code-block:: csharp

   public class LinkTagHelper : UrlResolutionTagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/LinkTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.LinkTagHelper(Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper>, Microsoft.AspNet.Hosting.IHostingEnvironment, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.Extensions.WebEncoders.IHtmlEncoder, Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder, Microsoft.AspNet.Mvc.IUrlHelper)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper`\.
    
        
        
        
        :param logger: The .
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper}
        
        
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
    
           public LinkTagHelper(ILogger<LinkTagHelper> logger, IHostingEnvironment hostingEnvironment, IMemoryCache cache, IHtmlEncoder htmlEncoder, IJavaScriptStringEncoder javaScriptEncoder, IUrlHelper urlHelper)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.AppendVersion
    
        
    
        Value indicating if file version should be appended to the href urls.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? AppendVersion { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.Cache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           protected IMemoryCache Cache { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHref
    
        
    
        The URL of a CSS stylesheet to fallback to in the case the primary one fails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackHref { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHrefExclude
    
        
    
        A comma separated list of globbed file patterns of CSS stylesheets to exclude from the fallback list, in
        the case the primary one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackHrefExclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude
    
        
    
        A comma separated list of globbed file patterns of CSS stylesheets to fallback to in the case the primary
        one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackHrefInclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass
    
        
    
        The class name defined in the stylesheet to use for the fallback test.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty` and :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue`\,
        and either :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHref` or :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackTestClass { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty
    
        
    
        The CSS property name to use for the fallback test.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass` and :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue`\,
        and either :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHref` or :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackTestProperty { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue
    
        
    
        The CSS property value to use for the fallback test.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass` and :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty`\,
        and either :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHref` or :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FallbackTestValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.GlobbingUrlBuilder
    
        
        :rtype: Microsoft.AspNet.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    
        
        .. code-block:: csharp
    
           protected GlobbingUrlBuilder GlobbingUrlBuilder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNet.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
           protected IHostingEnvironment HostingEnvironment { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.Href
    
        
    
        Address of the linked resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Href { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.HrefExclude
    
        
    
        A comma separated list of globbed file patterns of CSS stylesheets to exclude from loading.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.HrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HrefExclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.HrefInclude
    
        
    
        A comma separated list of globbed file patterns of CSS stylesheets to load.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HrefInclude { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.JavaScriptEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           protected IJavaScriptStringEncoder JavaScriptEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper}
    
        
        .. code-block:: csharp
    
           protected ILogger<LinkTagHelper> Logger { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LinkTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

