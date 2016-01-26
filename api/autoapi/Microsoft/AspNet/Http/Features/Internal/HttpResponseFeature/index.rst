

HttpResponseFeature Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature`








Syntax
------

.. code-block:: csharp

   public class HttpResponseFeature : IHttpResponseFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/HttpResponseFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.HttpResponseFeature()
    
        
    
        
        .. code-block:: csharp
    
           public HttpResponseFeature()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
        
        
        :type callback: System.Func{System.Object,System.Threading.Tasks.Task}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void OnStarting(Func<object, Task> callback, object state)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ReasonPhrase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpResponseFeature.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int StatusCode { get; set; }
    

