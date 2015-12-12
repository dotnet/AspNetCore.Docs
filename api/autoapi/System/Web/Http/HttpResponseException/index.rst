

HttpResponseException Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`System.Web.Http.HttpResponseException`








Syntax
------

.. code-block:: csharp

   public class HttpResponseException : Exception, ISerializable, _Exception





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/HttpResponseException.cs>`_





.. dn:class:: System.Web.Http.HttpResponseException

Constructors
------------

.. dn:class:: System.Web.Http.HttpResponseException
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.HttpResponseException.HttpResponseException(System.Net.Http.HttpResponseMessage)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.HttpResponseException` class.
    
        
        
        
        :param response: The response message.
        
        :type response: System.Net.Http.HttpResponseMessage
    
        
        .. code-block:: csharp
    
           public HttpResponseException(HttpResponseMessage response)
    
    .. dn:constructor:: System.Web.Http.HttpResponseException.HttpResponseException(System.Net.HttpStatusCode)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.HttpResponseException` class.
    
        
        
        
        :param statusCode: The status code of the response.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        .. code-block:: csharp
    
           public HttpResponseException(HttpStatusCode statusCode)
    

Properties
----------

.. dn:class:: System.Web.Http.HttpResponseException
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.HttpResponseException.Response
    
        
    
        Gets the :any:`System.Net.Http.HttpResponseMessage` to return to the client.
    
        
        :rtype: System.Net.Http.HttpResponseMessage
    
        
        .. code-block:: csharp
    
           public HttpResponseMessage Response { get; }
    

