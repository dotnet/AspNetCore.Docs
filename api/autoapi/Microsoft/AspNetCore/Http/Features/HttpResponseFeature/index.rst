

HttpResponseFeature Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.HttpResponseFeature`








Syntax
------

.. code-block:: csharp

    public class HttpResponseFeature : IHttpResponseFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.HasStarted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool HasStarted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.ReasonPhrase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ReasonPhrase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.HttpResponseFeature()
    
        
    
        
        .. code-block:: csharp
    
            public HttpResponseFeature()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.OnCompleted(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void OnCompleted(Func<object, Task> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.HttpResponseFeature.OnStarting(System.Func<System.Object, System.Threading.Tasks.Task>, System.Object)
    
        
    
        
        :type callback: System.Func<System.Func`2>{System.Object<System.Object>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void OnStarting(Func<object, Task> callback, object state)
    

