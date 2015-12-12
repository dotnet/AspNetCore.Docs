

HttpOkObjectResult Class
========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ObjectResult` that when executed performs content negotiation, formats the entity body, and
will produce a :dn:field:`Microsoft.AspNet.Http.StatusCodes.Status200OK` response if negotiation and formatting succeed.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpOkObjectResult`








Syntax
------

.. code-block:: csharp

   public class HttpOkObjectResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/HttpOkObjectResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpOkObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpOkObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpOkObjectResult.HttpOkObjectResult(System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.HttpOkObjectResult` class.
    
        
        
        
        :param value: The content to format into the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public HttpOkObjectResult(object value)
    

