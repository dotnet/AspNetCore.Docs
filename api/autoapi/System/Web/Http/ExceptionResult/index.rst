

ExceptionResult Class
=====================



.. contents:: 
   :local:



Summary
-------

An action result that returns a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status500InternalServerError` response and
performs content negotiation on an :any:`System.Web.Http.HttpError` based on an :dn:prop:`System.Web.Http.ExceptionResult.Exception`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.ExceptionResult`








Syntax
------

.. code-block:: csharp

   public class ExceptionResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/ExceptionResult.cs>`_





.. dn:class:: System.Web.Http.ExceptionResult

Constructors
------------

.. dn:class:: System.Web.Http.ExceptionResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.ExceptionResult.ExceptionResult(System.Exception, System.Boolean)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.ExceptionResult` class.
    
        
        
        
        :param exception: The exception to include in the error.
        
        :type exception: System.Exception
        
        
        :param includeErrorDetail: if the error should include exception messages; otherwise, .
        
        :type includeErrorDetail: System.Boolean
    
        
        .. code-block:: csharp
    
           public ExceptionResult(Exception exception, bool includeErrorDetail)
    

Methods
-------

.. dn:class:: System.Web.Http.ExceptionResult
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.ExceptionResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: System.Web.Http.ExceptionResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.ExceptionResult.Exception
    
        
    
        Gets the exception to include in the error.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Exception { get; }
    
    .. dn:property:: System.Web.Http.ExceptionResult.IncludeErrorDetail
    
        
    
        Gets a value indicating whether the error should include exception messages.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IncludeErrorDetail { get; }
    

