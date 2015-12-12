

BadRequestErrorMessageResult Class
==================================



.. contents:: 
   :local:



Summary
-------

An action result that returns a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status400BadRequest` response and performs
content negotiation on an :any:`System.Web.Http.HttpError` with a :dn:prop:`System.Web.Http.HttpError.Message`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.BadRequestErrorMessageResult`








Syntax
------

.. code-block:: csharp

   public class BadRequestErrorMessageResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/BadRequestErrorMessageResult.cs>`_





.. dn:class:: System.Web.Http.BadRequestErrorMessageResult

Constructors
------------

.. dn:class:: System.Web.Http.BadRequestErrorMessageResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.BadRequestErrorMessageResult.BadRequestErrorMessageResult(System.String)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.BadRequestErrorMessageResult` class.
    
        
        
        
        :param message: The user-visible error message.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public BadRequestErrorMessageResult(string message)
    

Methods
-------

.. dn:class:: System.Web.Http.BadRequestErrorMessageResult
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.BadRequestErrorMessageResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: System.Web.Http.BadRequestErrorMessageResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.BadRequestErrorMessageResult.Message
    
        
    
        Gets the error message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Message { get; }
    

