

IHttpResponseFeature Interface
==============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpResponseFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/IHttpResponseFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpResponseFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           void OnStarting(Func<object, Task> callback, object state)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ReasonPhrase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpResponseFeature.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int StatusCode { get; set; }
    

