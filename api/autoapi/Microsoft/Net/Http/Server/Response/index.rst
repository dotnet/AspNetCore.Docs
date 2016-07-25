

Response Class
==============





Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.Response`








Syntax
------

.. code-block:: csharp

    public sealed class Response








.. dn:class:: Microsoft.Net.Http.Server.Response
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.Response

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.Response
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.Response.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream Body { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.CacheTtl
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? CacheTtl { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.ContentLength
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        .. code-block:: csharp
    
            public long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasStarted { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.HasStartedSending
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasStartedSending { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.Headers
    
        
        :rtype: Microsoft.Net.Http.Server.HeaderCollection
    
        
        .. code-block:: csharp
    
            public HeaderCollection Headers { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ReasonPhrase { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.ShouldBuffer
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ShouldBuffer { get; set; }
    
    .. dn:property:: Microsoft.Net.Http.Server.Response.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.Response
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.Response.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.Net.Http.Server.Response.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.Net.Http.Server.Response.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    
    .. dn:method:: Microsoft.Net.Http.Server.Response.SendFileAsync(System.String, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        :type path: System.String
    
        
        :type offset: System.Int64
    
        
        :type count: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type cancel: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task SendFileAsync(string path, long offset, long ? count, CancellationToken cancel)
    

