

CacheProfile Class
==================






Defines a set of settings which can be used for response caching.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.CacheProfile`








Syntax
------

.. code-block:: csharp

    public class CacheProfile








.. dn:class:: Microsoft.AspNetCore.Mvc.CacheProfile
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.CacheProfile

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.CacheProfile
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CacheProfile.Duration
    
        
    
        
        Gets or sets the duration in seconds for which the response is cached.
        If this property is set to a non null value,
        the "max-age" in "Cache-control" header is set in the 
        :dn:prop:`Microsoft.AspNetCore.Http.HttpContext.Response`\.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? Duration { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CacheProfile.Location
    
        
    
        
        Gets or sets the location where the data from a particular URL must be cached.
        If this property is set to a non null value,
        the "Cache-control" header is set in the :dn:prop:`Microsoft.AspNetCore.Http.HttpContext.Response`\.
    
        
        :rtype: System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Mvc.ResponseCacheLocation<Microsoft.AspNetCore.Mvc.ResponseCacheLocation>}
    
        
        .. code-block:: csharp
    
            public ResponseCacheLocation? Location { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CacheProfile.NoStore
    
        
    
        
        Gets or sets the value which determines whether the data should be stored or not.
        When set to <xref uid="langword_csharp_true" name="true" href=""></xref>, it sets "Cache-control" header in 
        :dn:prop:`Microsoft.AspNetCore.Http.HttpContext.Response` to "no-store".
        Ignores the "Location" parameter for values other than "None".
        Ignores the "Duration" parameter.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? NoStore { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CacheProfile.VaryByHeader
    
        
    
        
        Gets or sets the value for the Vary header in :dn:prop:`Microsoft.AspNetCore.Http.HttpContext.Response`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string VaryByHeader { get; set; }
    

