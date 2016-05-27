

InvalidModelStateResult Class
=============================






An action result that returns a :dn:field:`Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest` response and performs
content negotiation on an :any:`System.Web.Http.HttpError` based on a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.


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
* :dn:cls:`System.Web.Http.InvalidModelStateResult`








Syntax
------

.. code-block:: csharp

    public class InvalidModelStateResult : ObjectResult, IActionResult








.. dn:class:: System.Web.Http.InvalidModelStateResult
    :hidden:

.. dn:class:: System.Web.Http.InvalidModelStateResult

Properties
----------

.. dn:class:: System.Web.Http.InvalidModelStateResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.InvalidModelStateResult.IncludeErrorDetail
    
        
    
        
        Gets a value indicating whether the error should include exception messages.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IncludeErrorDetail
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.InvalidModelStateResult.ModelState
    
        
    
        
        Gets the model state to include in the error.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState
            {
                get;
            }
    

Constructors
------------

.. dn:class:: System.Web.Http.InvalidModelStateResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.InvalidModelStateResult.InvalidModelStateResult(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Boolean)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.InvalidModelStateResult` class.
    
        
    
        
        :param modelState: The model state to include in the error.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param includeErrorDetail: 
            <xref uid="langword_csharp_true" name="true" href=""></xref> if the error should include exception messages; otherwise, <xref uid="langword_csharp_false" name="false" href=""></xref>.
        
        :type includeErrorDetail: System.Boolean
    
        
        .. code-block:: csharp
    
            public InvalidModelStateResult(ModelStateDictionary modelState, bool includeErrorDetail)
    

Methods
-------

.. dn:class:: System.Web.Http.InvalidModelStateResult
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.InvalidModelStateResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

