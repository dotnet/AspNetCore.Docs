

RequestBuilder Class
====================



.. contents:: 
   :local:



Summary
-------

Used to construct a HttpRequestMessage object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.TestHost.RequestBuilder`








Syntax
------

.. code-block:: csharp

   public class RequestBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.TestHost/RequestBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.TestHost.RequestBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.TestHost.RequestBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.TestHost.RequestBuilder.RequestBuilder(Microsoft.AspNet.TestHost.TestServer, System.String)
    
        
    
        Construct a new HttpRequestMessage with the given path.
    
        
        
        
        :type server: Microsoft.AspNet.TestHost.TestServer
        
        
        :type path: System.String
    
        
        .. code-block:: csharp
    
           public RequestBuilder(TestServer server, string path)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.TestHost.RequestBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.TestHost.RequestBuilder.AddHeader(System.String, System.String)
    
        
    
        Add the given header and value to the request or request content.
    
        
        
        
        :type name: System.String
        
        
        :type value: System.String
        :rtype: Microsoft.AspNet.TestHost.RequestBuilder
    
        
        .. code-block:: csharp
    
           public RequestBuilder AddHeader(string name, string value)
    
    .. dn:method:: Microsoft.AspNet.TestHost.RequestBuilder.And(System.Action<System.Net.Http.HttpRequestMessage>)
    
        
    
        Configure any HttpRequestMessage properties.
    
        
        
        
        :type configure: System.Action{System.Net.Http.HttpRequestMessage}
        :rtype: Microsoft.AspNet.TestHost.RequestBuilder
    
        
        .. code-block:: csharp
    
           public RequestBuilder And(Action<HttpRequestMessage> configure)
    
    .. dn:method:: Microsoft.AspNet.TestHost.RequestBuilder.GetAsync()
    
        
    
        Set the request method to GET and start processing the request.
    
        
        :rtype: System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}
    
        
        .. code-block:: csharp
    
           public Task<HttpResponseMessage> GetAsync()
    
    .. dn:method:: Microsoft.AspNet.TestHost.RequestBuilder.PostAsync()
    
        
    
        Set the request method to POST and start processing the request.
    
        
        :rtype: System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}
    
        
        .. code-block:: csharp
    
           public Task<HttpResponseMessage> PostAsync()
    
    .. dn:method:: Microsoft.AspNet.TestHost.RequestBuilder.SendAsync(System.String)
    
        
    
        Set the request method and start processing the request.
    
        
        
        
        :type method: System.String
        :rtype: System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}
    
        
        .. code-block:: csharp
    
           public Task<HttpResponseMessage> SendAsync(string method)
    

