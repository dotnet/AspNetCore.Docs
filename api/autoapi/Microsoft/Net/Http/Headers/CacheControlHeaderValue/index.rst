

CacheControlHeaderValue Class
=============================





Namespace
    :dn:ns:`Microsoft.Net.Http.Headers`
Assemblies
    * Microsoft.Net.Http.Headers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.CacheControlHeaderValue`








Syntax
------

.. code-block:: csharp

    public class CacheControlHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.CacheControlHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.CacheControlHeaderValue()
    
        
    
        
        .. code-block:: csharp
    
            public CacheControlHeaderValue()
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    
        
        .. code-block:: csharp
    
            public static CacheControlHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.CacheControlHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.CacheControlHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out CacheControlHeaderValue parsedValue)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.CacheControlHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.Extensions
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.NameValueHeaderValue<Microsoft.Net.Http.Headers.NameValueHeaderValue>}
    
        
        .. code-block:: csharp
    
            public IList<NameValueHeaderValue> Extensions { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.MaxAge
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? MaxAge { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.MaxStale
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MaxStale { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.MaxStaleLimit
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? MaxStaleLimit { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.MinFresh
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? MinFresh { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.MustRevalidate
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MustRevalidate { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.NoCache
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoCache { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.NoCacheHeaders
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> NoCacheHeaders { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.NoStore
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoStore { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.NoTransform
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoTransform { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.OnlyIfCached
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool OnlyIfCached { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.Private
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Private { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.PrivateHeaders
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> PrivateHeaders { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.ProxyRevalidate
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ProxyRevalidate { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.Public
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Public { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.CacheControlHeaderValue.SharedMaxAge
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? SharedMaxAge { get; set; }
    

