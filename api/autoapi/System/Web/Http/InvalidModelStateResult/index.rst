

InvalidModelStateResult Class
=============================



.. contents:: 
   :local:



Summary
-------

An action result that returns a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status400BadRequest` response and performs
content negotiation on an :any:`System.Web.Http.HttpError` based on a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.InvalidModelStateResult`








Syntax
------

.. code-block:: csharp

   public class InvalidModelStateResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/InvalidModelStateResult.cs>`_





.. dn:class:: System.Web.Http.InvalidModelStateResult

Constructors
------------

.. dn:class:: System.Web.Http.InvalidModelStateResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.InvalidModelStateResult.InvalidModelStateResult(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.Boolean)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.InvalidModelStateResult` class.
    
        
        
        
        :param modelState: The model state to include in the error.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param includeErrorDetail: if the error should include exception messages; otherwise, .
        
        :type includeErrorDetail: System.Boolean
    
        
        .. code-block:: csharp
    
           public InvalidModelStateResult(ModelStateDictionary modelState, bool includeErrorDetail)
    

Methods
-------

.. dn:class:: System.Web.Http.InvalidModelStateResult
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.InvalidModelStateResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: System.Web.Http.InvalidModelStateResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.InvalidModelStateResult.IncludeErrorDetail
    
        
    
        Gets a value indicating whether the error should include exception messages.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IncludeErrorDetail { get; }
    
    .. dn:property:: System.Web.Http.InvalidModelStateResult.ModelState
    
        
    
        Gets the model state to include in the error.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; }
    

