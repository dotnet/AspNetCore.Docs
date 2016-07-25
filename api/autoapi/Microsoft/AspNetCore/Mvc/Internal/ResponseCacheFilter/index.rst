

ResponseCacheFilter Class
=========================






An :any:`Microsoft.AspNetCore.Mvc.Filters.IActionFilter` which sets the appropriate headers related to response caching.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter`








Syntax
------

.. code-block:: csharp

    public class ResponseCacheFilter : IResponseCacheFilter, IActionFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.ResponseCacheFilter(Microsoft.AspNetCore.Mvc.CacheProfile)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter`
    
        
    
        
        :param cacheProfile: The profile which contains the settings for 
            :any:`Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter`\.
        
        :type cacheProfile: Microsoft.AspNetCore.Mvc.CacheProfile
    
        
        .. code-block:: csharp
    
            public ResponseCacheFilter(CacheProfile cacheProfile)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.Duration
    
        
    
        
        Gets or sets the duration in seconds for which the response is cached.
        This is a required parameter.
        This sets "max-age" in "Cache-control" header.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Duration { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.Location
    
        
    
        
        Gets or sets the location where the data from a particular URL must be cached.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
            public ResponseCacheLocation Location { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.NoStore
    
        
    
        
        Gets or sets the value which determines whether the data should be stored or not.
        When set to <xref uid="langword_csharp_true" name="true" href=""></xref>, it sets "Cache-control" header to "no-store".
        Ignores the "Location" parameter for values other than "None".
        Ignores the "duration" parameter.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoStore { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.VaryByHeader
    
        
    
        
        Gets or sets the value for the Vary response header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string VaryByHeader { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ResponseCacheFilter.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnActionExecuting(ActionExecutingContext context)
    

