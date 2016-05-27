

CacheTagKey Class
=================






An instance of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey` represents the state of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`
or :any:`Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper` keys.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey`








Syntax
------

.. code-block:: csharp

    public class CacheTagKey : IEquatable<CacheTagKey>








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.CacheTagKey(Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey` for a specific :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`\.
    
        
    
        
        :param tagHelper: The :any:`Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper`\.
        
        :type tagHelper: Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper
    
        
        :param context: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext`\.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
            public CacheTagKey(CacheTagHelper tagHelper, TagHelperContext context)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.CacheTagKey(Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey` for a specific :any:`Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper`\.
    
        
    
        
        :param tagHelper: The :any:`Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper`\.
        
        :type tagHelper: Microsoft.AspNetCore.Mvc.TagHelpers.DistributedCacheTagHelper
    
        
        .. code-block:: csharp
    
            public CacheTagKey(DistributedCacheTagHelper tagHelper)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.Equals(Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(CacheTagKey other)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.GenerateHashedKey()
    
        
    
        
        Creates a hashed value of the key.
    
        
        :rtype: System.String
        :return: A cryptographic hash of the key.
    
        
        .. code-block:: csharp
    
            public string GenerateHashedKey()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.GenerateKey()
    
        
    
        
        Creates a :any:`System.String` representation of the key.
    
        
        :rtype: System.String
        :return: A :any:`System.String` uniquely representing the key.
    
        
        .. code-block:: csharp
    
            public string GenerateKey()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.CacheTagKey.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

