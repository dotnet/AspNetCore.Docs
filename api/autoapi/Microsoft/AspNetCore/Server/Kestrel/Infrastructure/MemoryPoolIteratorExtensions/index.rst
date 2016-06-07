

MemoryPoolIteratorExtensions Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolIteratorExtensions








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.GetArraySegment(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public static ArraySegment<byte> GetArraySegment(MemoryPoolIterator start, MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.GetAsciiString(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetAsciiString(MemoryPoolIterator start, MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.GetKnownMethod(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, ref Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, out System.String)
    
        
    
        
        Checks that up to 8 bytes from <em>begin</em> correspond to a known HTTP method.
    
        
    
        
        :param begin: The iterator from which to start the known string lookup.
        
        :type begin: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :param scan: If we found a valid method, then scan will be updated to new position
        
        :type scan: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :param knownMethod: A reference to a pre-allocated known string, if the input matches any.
        
        :type knownMethod: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the input matches a known string, <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public static bool GetKnownMethod(MemoryPoolIterator begin, ref MemoryPoolIterator scan, out string knownMethod)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.GetKnownVersion(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, ref Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, out System.String)
    
        
    
        
        Checks 9 bytes from <em>begin</em>  correspond to a known HTTP version.
    
        
    
        
        :param begin: The iterator from which to start the known string lookup.
        
        :type begin: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :param scan: If we found a valid method, then scan will be updated to new position
        
        :type scan: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :param knownVersion: A reference to a pre-allocated known string, if the input matches any.
        
        :type knownVersion: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the input matches a known string, <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public static bool GetKnownVersion(MemoryPoolIterator begin, ref MemoryPoolIterator scan, out string knownVersion)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.GetUtf8String(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetUtf8String(MemoryPoolIterator start, MemoryPoolIterator end)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.Http10Version
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string Http10Version = "HTTP/1.0"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.Http11Version
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string Http11Version = "HTTP/1.1"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpConnectMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpConnectMethod = "CONNECT"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpDeleteMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpDeleteMethod = "DELETE"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpGetMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpGetMethod = "GET"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpHeadMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpHeadMethod = "HEAD"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpOptionsMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpOptionsMethod = "OPTIONS"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpPatchMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpPatchMethod = "PATCH"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpPostMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpPostMethod = "POST"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpPutMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpPutMethod = "PUT"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIteratorExtensions.HttpTraceMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpTraceMethod = "TRACE"
    

