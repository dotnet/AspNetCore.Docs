

ImageTagHelper Class
====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <img> elements that supports file versioning.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("img", Attributes = "asp-append-version,src", TagStructure = TagStructure.WithoutEndTag)]
    public class ImageTagHelper : UrlResolutionTagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.AppendVersion
    
        
    
        
        Value indicating if file version should be appended to the src urls.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-append-version")]
            public bool AppendVersion
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.Cache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
            protected IMemoryCache Cache
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            protected IHostingEnvironment HostingEnvironment
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.Src
    
        
    
        
        Source of the image.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("src")]
            public string Src
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.ImageTagHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment, Microsoft.Extensions.Caching.Memory.IMemoryCache, System.Text.Encodings.Web.HtmlEncoder, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper`\.
    
        
    
        
        :param hostingEnvironment: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param cache: The :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache`\.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder` to use.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param urlHelperFactory: The :any:`Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory`\.
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            public ImageTagHelper(IHostingEnvironment hostingEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, IUrlHelperFactory urlHelperFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

