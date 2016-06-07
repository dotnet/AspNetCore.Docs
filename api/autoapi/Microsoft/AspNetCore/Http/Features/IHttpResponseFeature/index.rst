

IHttpResponseFeature Interface
==============================






Represents the fields and state of an HTTP response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpResponseFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Body
    
        
    
        
        The :any:`System.IO.Stream` for writing the response body.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            Stream Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.HasStarted
    
        
    
        
        Indicates if the response has started. If true, the :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.StatusCode`\,
        :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.ReasonPhrase`\, and :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Headers` are now immutable, and
        OnStarting should no longer be called.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HasStarted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Headers
    
        
    
        
        The response headers to send. Headers with multiple values will be emitted as multiple headers.
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            IHeaderDictionary Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.ReasonPhrase
    
        
    
        
        The reason-phrase as defined in RFC 7230. Note this field is no longer supported by HTTP/2.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ReasonPhrase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.StatusCode
    
        
    
        
        The status-code as defined in RFC 7230. The default value is 200.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int StatusCode
            {
                get;
                set;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        Registers a callback to be invoked after a response has fully completed. This is
        intended for resource cleanup.
    
        
    
        
        :param callback: The callback to invoke after the response has completed.
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :param state: The state to pass into the callback.
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        Registers a callback to be invoked just before the response starts. This is the
        last chance to modify the :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Headers`\, :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.StatusCode`\, or
        :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.ReasonPhrase`\.
    
        
    
        
        :param callback: The callback to invoke when starting the response.
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :param state: The state to pass into the callback.
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            void OnStarting(Func<object, Task> callback, object state)
    

