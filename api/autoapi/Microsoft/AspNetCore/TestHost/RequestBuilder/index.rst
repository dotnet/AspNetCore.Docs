

RequestBuilder Class
====================






Used to construct a HttpRequestMessage object.


Namespace
    :dn:ns:`Microsoft.AspNetCore.TestHost`
Assemblies
    * Microsoft.AspNetCore.TestHost

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.TestHost.RequestBuilder`








Syntax
------

.. code-block:: csharp

    public class RequestBuilder








.. dn:class:: Microsoft.AspNetCore.TestHost.RequestBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.TestHost.RequestBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.TestHost.RequestBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.TestHost.RequestBuilder.RequestBuilder(Microsoft.AspNetCore.TestHost.TestServer, System.String)
    
        
    
        
        Construct a new HttpRequestMessage with the given path.
    
        
    
        
        :type server: Microsoft.AspNetCore.TestHost.TestServer
    
        
        :type path: System.String
    
        
        .. code-block:: csharp
    
            public RequestBuilder(TestServer server, string path)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.TestHost.RequestBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.TestHost.RequestBuilder.AddHeader(System.String, System.String)
    
        
    
        
        Add the given header and value to the request or request content.
    
        
    
        
        :type name: System.String
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.TestHost.RequestBuilder
    
        
        .. code-block:: csharp
    
            public RequestBuilder AddHeader(string name, string value)
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.RequestBuilder.And(System.Action<System.Net.Http.HttpRequestMessage>)
    
        
    
        
        Configure any HttpRequestMessage properties.
    
        
    
        
        :type configure: System.Action<System.Action`1>{System.Net.Http.HttpRequestMessage<System.Net.Http.HttpRequestMessage>}
        :rtype: Microsoft.AspNetCore.TestHost.RequestBuilder
    
        
        .. code-block:: csharp
    
            public RequestBuilder And(Action<HttpRequestMessage> configure)
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.RequestBuilder.GetAsync()
    
        
    
        
        Set the request method to GET and start processing the request.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.Http.HttpResponseMessage<System.Net.Http.HttpResponseMessage>}
    
        
        .. code-block:: csharp
    
            public Task<HttpResponseMessage> GetAsync()
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.RequestBuilder.PostAsync()
    
        
    
        
        Set the request method to POST and start processing the request.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.Http.HttpResponseMessage<System.Net.Http.HttpResponseMessage>}
    
        
        .. code-block:: csharp
    
            public Task<HttpResponseMessage> PostAsync()
    
    .. dn:method:: Microsoft.AspNetCore.TestHost.RequestBuilder.SendAsync(System.String)
    
        
    
        
        Set the request method and start processing the request.
    
        
    
        
        :type method: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.Http.HttpResponseMessage<System.Net.Http.HttpResponseMessage>}
    
        
        .. code-block:: csharp
    
            public Task<HttpResponseMessage> SendAsync(string method)
    

