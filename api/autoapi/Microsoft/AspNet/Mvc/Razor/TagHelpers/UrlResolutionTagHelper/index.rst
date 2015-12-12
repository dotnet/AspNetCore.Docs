

UrlResolutionTagHelper Class
============================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting elements containing attributes with URL expected values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`








Syntax
------

.. code-block:: csharp

   public class UrlResolutionTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/TagHelpers/UrlResolutionTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.UrlResolutionTagHelper(Microsoft.AspNet.Mvc.IUrlHelper, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`\.
    
        
        
        
        :param urlHelper: The .
        
        :type urlHelper: Microsoft.AspNet.Mvc.IUrlHelper
        
        
        :param htmlEncoder: The .
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public UrlResolutionTagHelper(IUrlHelper urlHelper, IHtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.ProcessUrlAttribute(System.String, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
    
        Resolves and updates URL values starting with '~/' (relative to the application's 'webroot' setting) for
        ``output``'s :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.Attributes` whose 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute.Name` is ``attributeName``.
    
        
        
        
        :param attributeName: The attribute name used to lookup values to resolve.
        
        :type attributeName: System.String
        
        
        :param output: The .
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           protected void ProcessUrlAttribute(string attributeName, TagHelperOutput output)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.TryResolveUrl(System.String, System.Boolean, out System.String)
    
        
    
        Tries to resolve the given ``url`` value relative to the application's 'webroot' setting.
    
        
        
        
        :param url: The URL to resolve.
        
        :type url: System.String
        
        
        :param encodeWebRoot: If true, will HTML encode the expansion of '~/'.
        
        :type encodeWebRoot: System.Boolean
        
        
        :param resolvedUrl: Absolute URL beginning with the application's virtual root. null if
            could not be resolved.
        
        :type resolvedUrl: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if the <paramref name="url" /> could be resolved; <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           protected bool TryResolveUrl(string url, bool encodeWebRoot, out string resolvedUrl)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.HtmlEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           protected IHtmlEncoder HtmlEncoder { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper.UrlHelper
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           protected IUrlHelper UrlHelper { get; }
    

