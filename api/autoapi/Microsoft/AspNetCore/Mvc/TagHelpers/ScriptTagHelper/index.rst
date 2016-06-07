

ScriptTagHelper Class
=====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <script> elements that supports fallback src paths.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("script", Attributes = "asp-src-include")]
    [HtmlTargetElement("script", Attributes = "asp-src-exclude")]
    [HtmlTargetElement("script", Attributes = "asp-fallback-src")]
    [HtmlTargetElement("script", Attributes = "asp-fallback-src-include")]
    [HtmlTargetElement("script", Attributes = "asp-fallback-src-exclude")]
    [HtmlTargetElement("script", Attributes = "asp-fallback-test")]
    [HtmlTargetElement("script", Attributes = "asp-append-version")]
    public class ScriptTagHelper : UrlResolutionTagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.AppendVersion
    
        
    
        
        Value indicating if file version should be appended to src urls.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-append-version")]
            public bool ? AppendVersion
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.Cache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            protected IMemoryCache Cache
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.FallbackSrc
    
        
    
        
        The URL of a Script tag to fallback to in the case the primary one fails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-src")]
            public string FallbackSrc
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.FallbackSrcExclude
    
        
    
        
        A comma separated list of globbed file patterns of JavaScript scripts to exclude from the fallback list, in
        the case the primary one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.FallbackSrcInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-src-exclude")]
            public string FallbackSrcExclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.FallbackSrcInclude
    
        
    
        
        A comma separated list of globbed file patterns of JavaScript scripts to fallback to in the case the
        primary one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-src-include")]
            public string FallbackSrcInclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.FallbackTestExpression
    
        
    
        
        The script method defined in the primary script to use for the fallback test.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-test")]
            public string FallbackTestExpression
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.GlobbingUrlBuilder
    
        
        :rtype: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    
        
        .. code-block:: csharp
    
            protected GlobbingUrlBuilder GlobbingUrlBuilder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            protected IHostingEnvironment HostingEnvironment
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.JavaScriptEncoder
    
        
        :rtype: System.Text.Encodings.Web.JavaScriptEncoder
    
        
        .. code-block:: csharp
    
            protected JavaScriptEncoder JavaScriptEncoder
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.Src
    
        
    
        
        Address of the external script to use.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("src")]
            public string Src
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.SrcExclude
    
        
    
        
        A comma separated list of globbed file patterns of JavaScript scripts to exclude from loading.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.SrcInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-src-exclude")]
            public string SrcExclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.SrcInclude
    
        
    
        
        A comma separated list of globbed file patterns of JavaScript scripts to load.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-src-include")]
            public string SrcInclude
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.ScriptTagHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment, Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Text.Encodings.Web.HtmlEncoder, System.Text.Encodings.Web.JavaScriptEncoder, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper`\.
    
        
    
        
        :param hostingEnvironment: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param cache: The :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache`\.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param javaScriptEncoder: The :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.JavaScriptEncoder`\.
        
        :type javaScriptEncoder: System.Text.Encodings.Web.JavaScriptEncoder
    
        
        :param urlHelperFactory: The :any:`Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory`\.
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            public ScriptTagHelper(IHostingEnvironment hostingEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, JavaScriptEncoder javaScriptEncoder, IUrlHelperFactory urlHelperFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

