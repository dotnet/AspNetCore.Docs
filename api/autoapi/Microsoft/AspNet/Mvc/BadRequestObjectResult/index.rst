

BadRequestObjectResult Class
============================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ObjectResult` that when executed will produce a Bad Request (400) response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNet.Mvc.BadRequestObjectResult`








Syntax
------

.. code-block:: csharp

   public class BadRequestObjectResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/BadRequestObjectResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.BadRequestObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.BadRequestObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.BadRequestObjectResult.BadRequestObjectResult(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.BadRequestObjectResult` instance.
    
        
        
        
        :param modelState: containing the validation errors.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public BadRequestObjectResult(ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.BadRequestObjectResult.BadRequestObjectResult(System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.BadRequestObjectResult` instance.
    
        
        
        
        :param error: Contains the errors to be returned to the client.
        
        :type error: System.Object
    
        
        .. code-block:: csharp
    
           public BadRequestObjectResult(object error)
    

