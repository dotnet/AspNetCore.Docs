

NotFoundObjectResult Class
==========================






An :any:`Microsoft.AspNetCore.Mvc.ObjectResult` that when executed will produce a Not Found (404) response.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.NotFoundObjectResult`








Syntax
------

.. code-block:: csharp

    public class NotFoundObjectResult : ObjectResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.NotFoundObjectResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.NotFoundObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.NotFoundObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.NotFoundObjectResult.NotFoundObjectResult(System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.NotFoundObjectResult` instance.
    
        
    
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public NotFoundObjectResult(object value)
    

