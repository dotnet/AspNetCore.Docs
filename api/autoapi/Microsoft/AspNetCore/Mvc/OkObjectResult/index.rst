

OkObjectResult Class
====================






An :any:`Microsoft.AspNetCore.Mvc.ObjectResult` that when executed performs content negotiation, formats the entity body, and
will produce a :dn:field:`Microsoft.AspNetCore.Http.StatusCodes.Status200OK` response if negotiation and formatting succeed.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.OkObjectResult`








Syntax
------

.. code-block:: csharp

    public class OkObjectResult : ObjectResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.OkObjectResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.OkObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.OkObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.OkObjectResult.OkObjectResult(System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.OkObjectResult` class.
    
        
    
        
        :param value: The content to format into the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public OkObjectResult(object value)
    

