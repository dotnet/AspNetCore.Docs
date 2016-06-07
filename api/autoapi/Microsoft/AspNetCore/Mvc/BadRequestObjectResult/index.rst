

BadRequestObjectResult Class
============================






An :any:`Microsoft.AspNetCore.Mvc.ObjectResult` that when executed will produce a Bad Request (400) response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult`








Syntax
------

.. code-block:: csharp

    public class BadRequestObjectResult : ObjectResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.BadRequestObjectResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.BadRequestObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.BadRequestObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.BadRequestObjectResult.BadRequestObjectResult(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult` instance.
    
        
    
        
        :param modelState: :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` containing the validation errors.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public BadRequestObjectResult(ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.BadRequestObjectResult.BadRequestObjectResult(System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult` instance.
    
        
    
        
        :param error: Contains the errors to be returned to the client.
        
        :type error: System.Object
    
        
        .. code-block:: csharp
    
            public BadRequestObjectResult(object error)
    

