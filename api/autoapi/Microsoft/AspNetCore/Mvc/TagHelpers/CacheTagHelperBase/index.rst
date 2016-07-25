

CacheTagHelperBase Class
========================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper` base implementation for caching elements.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase`








Syntax
------

.. code-block:: csharp

    public abstract class CacheTagHelperBase : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.CacheTagHelperBase(System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase`\.
    
        
    
        
        :param htmlEncoder: The :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.HtmlEncoder` to use.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public CacheTagHelperBase(HtmlEncoder htmlEncoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.Enabled
    
        
    
        
        Gets or sets the value which determines if the tag helper is enabled or not.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("enabled")]
            public bool Enabled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.ExpiresAfter
    
        
    
        
        Gets or sets the duration, from the time the cache entry was added, when it should be evicted.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("expires-after")]
            public TimeSpan? ExpiresAfter { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.ExpiresOn
    
        
    
        
        Gets or sets the exact :any:`System.DateTimeOffset` the cache entry should be evicted.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("expires-on")]
            public DateTimeOffset? ExpiresOn { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.ExpiresSliding
    
        
    
        
        Gets or sets the duration from last access that the cache entry should be evicted.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("expires-sliding")]
            public TimeSpan? ExpiresSliding { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.HtmlEncoder
    
        
    
        
        Gets the :any:`System.Text.Encodings.Web.HtmlEncoder` which encodes the content to be cached.
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            protected HtmlEncoder HtmlEncoder { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.VaryBy
    
        
    
        
        Gets or sets a :any:`System.String` to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("vary-by")]
            public string VaryBy { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.VaryByCookie
    
        
    
        
        Gets or sets a comma-delimited set of cookie names to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("vary-by-cookie")]
            public string VaryByCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.VaryByHeader
    
        
    
        
        Gets or sets a comma-delimited set of HTTP request headers to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("vary-by-header")]
            public string VaryByHeader { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.VaryByQuery
    
        
    
        
        Gets or sets a comma-delimited set of query parameters to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("vary-by-query")]
            public string VaryByQuery { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.VaryByRoute
    
        
    
        
        Gets or sets a comma-delimited set of route data parameters to vary the cached result by.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("vary-by-route")]
            public string VaryByRoute { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.VaryByUser
    
        
    
        
        Gets or sets a value that determines if the cached result is to be varied by the Identity for the logged in 
        :dn:prop:`Microsoft.AspNetCore.Http.HttpContext.User`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("vary-by-user")]
            public bool VaryByUser { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.ViewContext
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelperBase.ViewContext` for the current executing View.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

