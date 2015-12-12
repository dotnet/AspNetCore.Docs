

HttpResponse Class
==================



.. contents:: 
   :local:



Summary
-------

Represents the outgoing side of an individual HTTP request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpResponse`








Syntax
------

.. code-block:: csharp

   public abstract class HttpResponse





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/HttpResponse.cs>`_





.. dn:class:: Microsoft.AspNet.Http.HttpResponse

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.HttpResponse
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        Adds a delegate to be invoked after the response has finished being sent to the client.
    
        
        
        
        :param callback: The delegate to invoke.
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :param state: A state object to capture and pass back to the delegate.
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public abstract void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.OnCompleted(System.Func<System.Threading.Tasks.Task>)
    
        
    
        Adds a delegate to be invoked after the response has finished being sent to the client.
    
        
        
        
        :param callback: The delegate to invoke.
        
        :type callback: System.Func{System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public virtual void OnCompleted(Func<Task> callback)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        Adds a delegate to be invoked just before response headers will be sent to the client.
    
        
        
        
        :param callback: The delegate to execute.
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :param state: A state object to capture and pass back to the delegate.
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public abstract void OnStarting(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.OnStarting(System.Func<System.Threading.Tasks.Task>)
    
        
    
        Adds a delegate to be invoked just before response headers will be sent to the client.
    
        
        
        
        :param callback: The delegate to execute.
        
        :type callback: System.Func{System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public virtual void OnStarting(Func<Task> callback)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.Redirect(System.String)
    
        
    
        Returns a temporary redirect response (HTTP 302) to the client.
    
        
        
        
        :param location: The URL to redirect the client to.
        
        :type location: System.String
    
        
        .. code-block:: csharp
    
           public virtual void Redirect(string location)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.Redirect(System.String, System.Boolean)
    
        
    
        Returns a redirect response (HTTP 301 or HTTP 302) to the client.
    
        
        
        
        :param location: The URL to redirect the client to.
        
        :type location: System.String
        
        
        :param permanent: True if the redirect is permanent (301), otherwise false (302).
        
        :type permanent: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract void Redirect(string location, bool permanent)
    
    .. dn:method:: Microsoft.AspNet.Http.HttpResponse.RegisterForDispose(System.IDisposable)
    
        
    
        Registers an object for disposal by the host once the request has finished processing.
    
        
        
        
        :param disposable: The object to be disposed.
        
        :type disposable: System.IDisposable
    
        
        .. code-block:: csharp
    
           public virtual void RegisterForDispose(IDisposable disposable)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.HttpResponse
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.Body
    
        
    
        Gets the response body :any:`System.IO.Stream`\.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public abstract Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.ContentLength
    
        
    
        Gets or sets the value for the <c>Content-Length</c> response header.
    
        
        :rtype: System.Nullable{System.Int64}
    
        
        .. code-block:: csharp
    
           public abstract long ? ContentLength { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.ContentType
    
        
    
        Gets or sets the value for the <c>Content-Type</c> response header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.Cookies
    
        
    
        Gets an object that can be used to manage cookies for this response.
    
        
        :rtype: Microsoft.AspNet.Http.IResponseCookies
    
        
        .. code-block:: csharp
    
           public abstract IResponseCookies Cookies { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.HasStarted
    
        
    
        Gets a value indicating whether response headers have been sent to the client.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.Headers
    
        
    
        Gets the response headers.
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public abstract IHeaderDictionary Headers { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.HttpContext
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.Http.HttpResponse.HttpContext` for this request.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public abstract HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpResponse.StatusCode
    
        
    
        Gets or sets the HTTP response code.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public abstract int StatusCode { get; set; }
    

