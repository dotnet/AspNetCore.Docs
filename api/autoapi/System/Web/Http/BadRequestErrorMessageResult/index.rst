

BadRequestErrorMessageResult Class
==================================






An action result that returns a :dn:field:`Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest` response and performs
content negotiation on an :any:`System.Web.Http.HttpError` with a :dn:prop:`System.Web.Http.HttpError.Message`\.


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
* :dn:cls:`System.Web.Http.BadRequestErrorMessageResult`








Syntax
------

.. code-block:: csharp

    public class BadRequestErrorMessageResult : ObjectResult, IActionResult








.. dn:class:: System.Web.Http.BadRequestErrorMessageResult
    :hidden:

.. dn:class:: System.Web.Http.BadRequestErrorMessageResult

Properties
----------

.. dn:class:: System.Web.Http.BadRequestErrorMessageResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.BadRequestErrorMessageResult.Message
    
        
    
        
        Gets the error message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Message
            {
                get;
            }
    

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

    
    .. dn:method:: System.Web.Http.BadRequestErrorMessageResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

