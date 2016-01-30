

HttpNotFoundObjectResult Class
==============================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ObjectResult` that when executed will produce a Not Found (404) response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpNotFoundObjectResult`








Syntax
------

.. code-block:: csharp

   public class HttpNotFoundObjectResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpNotFoundObjectResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpNotFoundObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpNotFoundObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpNotFoundObjectResult.HttpNotFoundObjectResult(System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.HttpNotFoundObjectResult` instance.
    
        
        
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public HttpNotFoundObjectResult(object value)
    

