

MessageBody Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.MessageBody`








Syntax
------

.. code-block:: csharp

   public abstract class MessageBody





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/MessageBody.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody.MessageBody(Microsoft.AspNet.Server.Kestrel.Http.FrameContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.FrameContext
    
        
        .. code-block:: csharp
    
           protected MessageBody(FrameContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody.For(System.String, System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>, Microsoft.AspNet.Server.Kestrel.Http.FrameContext)
    
        
        
        
        :type httpVersion: System.String
        
        
        :type headers: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.FrameContext
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.MessageBody
    
        
        .. code-block:: csharp
    
           public static MessageBody For(string httpVersion, IDictionary<string, StringValues> headers, FrameContext context)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody.ReadAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public Task<int> ReadAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody.ReadAsyncImplementation(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public abstract Task<int> ReadAsyncImplementation(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody.TryGet(System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>, System.String, out System.String)
    
        
        
        
        :type headers: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
        
        
        :type name: System.String
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryGet(IDictionary<string, StringValues> headers, string name, out string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.MessageBody.RequestKeepAlive
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequestKeepAlive { get; protected set; }
    

