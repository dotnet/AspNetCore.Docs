

ImageTagHelper Class
====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;img&gt; elements that supports file versioning.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.TagHelpers.UrlResolutionTagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper`








Syntax
------

.. code-block:: csharp

   public class ImageTagHelper : UrlResolutionTagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/ImageTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.ImageTagHelper(Microsoft.AspNet.Hosting.IHostingEnvironment, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.Extensions.WebEncoders.IHtmlEncoder, Microsoft.AspNet.Mvc.IUrlHelper)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper`\.
    
        
        
        
        :param hostingEnvironment: The .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param cache: The .
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :param urlHelper: The .
        
        :type urlHelper: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public ImageTagHelper(IHostingEnvironment hostingEnvironment, IMemoryCache cache, IHtmlEncoder htmlEncoder, IUrlHelper urlHelper)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.AppendVersion
    
        
    
        Value indicating if file version should be appended to the src urls.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AppendVersion { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.Cache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           protected IMemoryCache Cache { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNet.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
           protected IHostingEnvironment HostingEnvironment { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.Src
    
        
    
        Source of the image.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Src { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ImageTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

