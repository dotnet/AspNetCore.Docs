

ExceptionResult Class
=====================






An action result that returns a :dn:field:`Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError` response and
performs content negotiation on an :any:`System.Web.Http.HttpError` based on an :dn:prop:`System.Web.Http.ExceptionResult.Exception`\.


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
* :dn:cls:`System.Web.Http.ExceptionResult`








Syntax
------

.. code-block:: csharp

    public class ExceptionResult : ObjectResult, IActionResult








.. dn:class:: System.Web.Http.ExceptionResult
    :hidden:

.. dn:class:: System.Web.Http.ExceptionResult

Properties
----------

.. dn:class:: System.Web.Http.ExceptionResult
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.ExceptionResult.Exception
    
        
    
        
        Gets the exception to include in the error.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Exception
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.ExceptionResult.IncludeErrorDetail
    
        
    
        
        Gets a value indicating whether the error should include exception messages.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IncludeErrorDetail
            {
                get;
            }
    

Constructors
------------

.. dn:class:: System.Web.Http.ExceptionResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.ExceptionResult.ExceptionResult(System.Exception, System.Boolean)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.ExceptionResult` class.
    
        
    
        
        :param exception: The exception to include in the error.
        
        :type exception: System.Exception
    
        
        :param includeErrorDetail: 
            <xref uid="langword_csharp_true" name="true" href=""></xref> if the error should include exception messages; otherwise, <xref uid="langword_csharp_false" name="false" href=""></xref>.
        
        :type includeErrorDetail: System.Boolean
    
        
        .. code-block:: csharp
    
            public ExceptionResult(Exception exception, bool includeErrorDetail)
    

Methods
-------

.. dn:class:: System.Web.Http.ExceptionResult
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.ExceptionResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

