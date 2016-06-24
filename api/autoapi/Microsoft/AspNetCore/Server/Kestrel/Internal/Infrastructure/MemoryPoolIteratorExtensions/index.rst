

MemoryPoolIteratorExtensions Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolIteratorExtensions








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.GetArraySegment(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
        :rtype: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public static ArraySegment<byte> GetArraySegment(this MemoryPoolIterator start, MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.GetAsciiString(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetAsciiString(this MemoryPoolIterator start, MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.GetKnownMethod(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, out System.String)
    
        
    
        
        Checks that up to 8 bytes from <em>begin</em> correspond to a known HTTP method.
    
        
    
        
        :param begin: The iterator from which to start the known string lookup.
        
        :type begin: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :param knownMethod: A reference to a pre-allocated known string, if the input matches any.
        
        :type knownMethod: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the input matches a known string, <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public static bool GetKnownMethod(this MemoryPoolIterator begin, out string knownMethod)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.GetKnownVersion(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, out System.String)
    
        
    
        
        Checks 9 bytes from <em>begin</em>  correspond to a known HTTP version.
    
        
    
        
        :param begin: The iterator from which to start the known string lookup.
        
        :type begin: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :param knownVersion: A reference to a pre-allocated known string, if the input matches any.
        
        :type knownVersion: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the input matches a known string, <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public static bool GetKnownVersion(this MemoryPoolIterator begin, out string knownVersion)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.GetUtf8String(Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIterator
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetUtf8String(this MemoryPoolIterator start, MemoryPoolIterator end)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.Http10Version
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string Http10Version = "HTTP/1.0"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.Http11Version
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string Http11Version = "HTTP/1.1"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpConnectMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpConnectMethod = "CONNECT"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpDeleteMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpDeleteMethod = "DELETE"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpGetMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpGetMethod = "GET"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpHeadMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpHeadMethod = "HEAD"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpOptionsMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpOptionsMethod = "OPTIONS"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpPatchMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpPatchMethod = "PATCH"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpPostMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpPostMethod = "POST"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpPutMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpPutMethod = "PUT"
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPoolIteratorExtensions.HttpTraceMethod
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string HttpTraceMethod = "TRACE"
    

