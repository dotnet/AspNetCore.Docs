

LinkTagHelper Class
===================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <link> elements that supports fallback href paths.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("link", Attributes = "asp-href-include", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-href-exclude", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-fallback-href", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-fallback-href-include", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-fallback-href-exclude", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-fallback-test-class", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-fallback-test-property", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-fallback-test-value", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("link", Attributes = "asp-append-version", TagStructure = TagStructure.WithoutEndTag)]
    public class LinkTagHelper : UrlResolutionTagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.AppendVersion
    
        
    
        
        Value indicating if file version should be appended to the href urls.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-append-version")]
            public bool ? AppendVersion
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.Cache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            protected IMemoryCache Cache
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHref
    
        
    
        
        The URL of a CSS stylesheet to fallback to in the case the primary one fails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-href")]
            public string FallbackHref
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHrefExclude
    
        
    
        
        A comma separated list of globbed file patterns of CSS stylesheets to exclude from the fallback list, in
        the case the primary one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-href-exclude")]
            public string FallbackHrefExclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude
    
        
    
        
        A comma separated list of globbed file patterns of CSS stylesheets to fallback to in the case the primary
        one fails.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-href-include")]
            public string FallbackHrefInclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass
    
        
    
        
        The class name defined in the stylesheet to use for the fallback test.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty` and :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue`\,
        and either :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHref` or :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-test-class")]
            public string FallbackTestClass
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty
    
        
    
        
        The CSS property name to use for the fallback test.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass` and :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue`\,
        and either :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHref` or :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-test-property")]
            public string FallbackTestProperty
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestValue
    
        
    
        
        The CSS property value to use for the fallback test.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestClass` and :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackTestProperty`\,
        and either :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHref` or :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.FallbackHrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fallback-test-value")]
            public string FallbackTestValue
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.GlobbingUrlBuilder
    
        
        :rtype: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.GlobbingUrlBuilder
    
        
        .. code-block:: csharp
    
            protected GlobbingUrlBuilder GlobbingUrlBuilder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            protected IHostingEnvironment HostingEnvironment
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.Href
    
        
    
        
        Address of the linked resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("href")]
            public string Href
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.HrefExclude
    
        
    
        
        A comma separated list of globbed file patterns of CSS stylesheets to exclude from loading.
        The glob patterns are assessed relative to the application's 'webroot' setting.
        Must be used in conjunction with :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.HrefInclude`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-href-exclude")]
            public string HrefExclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.HrefInclude
    
        
    
        
        A comma separated list of globbed file patterns of CSS stylesheets to load.
        The glob patterns are assessed relative to the application's 'webroot' setting.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-href-include")]
            public string HrefInclude
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.JavaScriptEncoder
    
        
        :rtype: System.Text.Encodings.Web.JavaScriptEncoder
    
        
        .. code-block:: csharp
    
            protected JavaScriptEncoder JavaScriptEncoder
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.LinkTagHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment, Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Text.Encodings.Web.HtmlEncoder, System.Text.Encodings.Web.JavaScriptEncoder, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper`\.
    
        
    
        
        :param hostingEnvironment: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param cache: The :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache`\.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param javaScriptEncoder: The :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.JavaScriptEncoder`\.
        
        :type javaScriptEncoder: System.Text.Encodings.Web.JavaScriptEncoder
    
        
        :param urlHelperFactory: The :any:`Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory`\.
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            public LinkTagHelper(IHostingEnvironment hostingEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, JavaScriptEncoder javaScriptEncoder, IUrlHelperFactory urlHelperFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

