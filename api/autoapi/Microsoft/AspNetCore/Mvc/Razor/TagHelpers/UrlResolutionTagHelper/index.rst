

UrlResolutionTagHelper Class
============================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting elements containing attributes with URL expected values.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("*", Attributes = "[itemid^='~/']")]
    [HtmlTargetElement("a", Attributes = "[href^='~/']")]
    [HtmlTargetElement("applet", Attributes = "[archive^='~/']")]
    [HtmlTargetElement("area", Attributes = "[href^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("audio", Attributes = "[src^='~/']")]
    [HtmlTargetElement("base", Attributes = "[href^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("blockquote", Attributes = "[cite^='~/']")]
    [HtmlTargetElement("button", Attributes = "[formaction^='~/']")]
    [HtmlTargetElement("del", Attributes = "[cite^='~/']")]
    [HtmlTargetElement("embed", Attributes = "[src^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("form", Attributes = "[action^='~/']")]
    [HtmlTargetElement("html", Attributes = "[manifest^='~/']")]
    [HtmlTargetElement("iframe", Attributes = "[src^='~/']")]
    [HtmlTargetElement("img", Attributes = "[src^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("img", Attributes = "[srcset^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("input", Attributes = "[src^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("input", Attributes = "[formaction^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("ins", Attributes = "[cite^='~/']")]
    [HtmlTargetElement("link", Attributes = "[href^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("menuitem", Attributes = "[icon^='~/']")]
    [HtmlTargetElement("object", Attributes = "[archive^='~/']")]
    [HtmlTargetElement("object", Attributes = "[data^='~/']")]
    [HtmlTargetElement("q", Attributes = "[cite^='~/']")]
    [HtmlTargetElement("script", Attributes = "[src^='~/']")]
    [HtmlTargetElement("source", Attributes = "[src^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("source", Attributes = "[srcset^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("track", Attributes = "[src^='~/']", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("video", Attributes = "[src^='~/']")]
    [HtmlTargetElement("video", Attributes = "[poster^='~/']")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class UrlResolutionTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.UrlResolutionTagHelper(Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`\.
    
        
    
        
        :param urlHelperFactory: The :any:`Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory`\.
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        :param htmlEncoder: The :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public UrlResolutionTagHelper(IUrlHelperFactory urlHelperFactory, HtmlEncoder htmlEncoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.HtmlEncoder
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            protected HtmlEncoder HtmlEncoder { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.UrlHelperFactory
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            protected IUrlHelperFactory UrlHelperFactory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.ProcessUrlAttribute(System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        Resolves and updates URL values starting with '~/' (relative to the application's 'webroot' setting) for
        <em>output</em>'s :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Attributes` whose 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute.Name` is <em>attributeName</em>.
    
        
    
        
        :param attributeName: The attribute name used to lookup values to resolve.
        
        :type attributeName: System.String
    
        
        :param output: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput`\.
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            protected void ProcessUrlAttribute(string attributeName, TagHelperOutput output)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.TryResolveUrl(System.String, out Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Tries to resolve the given <em>url</em> value relative to the application's 'webroot' setting.
    
        
    
        
        :param url: The URL to resolve.
        
        :type url: System.String
    
        
        :param resolvedUrl: 
            Absolute URL beginning with the application's virtual root. <code>null</code> if <em>url</em> could
            not be resolved.
        
        :type resolvedUrl: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: System.Boolean
        :return: <code>true</code> if the <em>url</em> could be resolved; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            protected bool TryResolveUrl(string url, out IHtmlContent resolvedUrl)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.TryResolveUrl(System.String, out System.String)
    
        
    
        
        Tries to resolve the given <em>url</em> value relative to the application's 'webroot' setting.
    
        
    
        
        :param url: The URL to resolve.
        
        :type url: System.String
    
        
        :param resolvedUrl: Absolute URL beginning with the application's virtual root. <code>null</code> if
            <em>url</em> could not be resolved.
        
        :type resolvedUrl: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the <em>url</em> could be resolved; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            protected bool TryResolveUrl(string url, out string resolvedUrl)
    

