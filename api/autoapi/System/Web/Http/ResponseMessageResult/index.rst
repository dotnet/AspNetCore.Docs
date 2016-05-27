

ResponseMessageResult Class
===========================






An action result that returns a specified response message.


Namespace
    :dn:ns:`System.Web.Http`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.ResponseMessageResult`








Syntax
------

.. code-block:: csharp

    public class ResponseMessageResult : ObjectResult, IActionResult








.. dn:class:: System.Web.Http.ResponseMessageResult
    :hidden:

.. dn:class:: System.Web.Http.ResponseMessageResult

Properties
----------

.. dn:class:: System.Web.Http.ResponseMessageResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.ResponseMessageResult.Response
    
        
    
        
        Gets the response message.
    
        
        :rtype: System.Net.Http.HttpResponseMessage
    
        
        .. code-block:: csharp
    
            public HttpResponseMessage Response
            {
                get;
            }
    

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
    

