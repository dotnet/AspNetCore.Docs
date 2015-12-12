

ResponseMessageResult Class
===========================



.. contents:: 
   :local:



Summary
-------

An action result that returns a specified response message.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.ResponseMessageResult`








Syntax
------

.. code-block:: csharp

   public class ResponseMessageResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/ResponseMessageResult.cs>`_





.. dn:class:: System.Web.Http.ResponseMessageResult

Constructors
------------

.. dn:class:: System.Web.Http.ResponseMessageResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.ResponseMessageResult.ResponseMessageResult(System.Net.Http.HttpResponseMessage)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.ResponseMessageResult` class.
    
        
        
        
        :param response: The response message.
        
        :type response: System.Net.Http.HttpResponseMessage
    
        
        .. code-block:: csharp
    
           public ResponseMessageResult(HttpResponseMessage response)
    

Properties
----------

.. dn:class:: System.Web.Http.ResponseMessageResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.ResponseMessageResult.Response
    
        
    
        Gets the response message.
    
        
        :rtype: System.Net.Http.HttpResponseMessage
    
        
        .. code-block:: csharp
    
           public HttpResponseMessage Response { get; }
    

