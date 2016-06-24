

StatusCodeResult Class
======================






Represents an :any:`Microsoft.AspNetCore.Mvc.ActionResult` that when executed will
produce an HTTP response with the given response status code.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.StatusCodeResult`








Syntax
------

.. code-block:: csharp

    public class StatusCodeResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.StatusCodeResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.StatusCodeResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.StatusCodeResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.StatusCodeResult.StatusCodeResult(System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.StatusCodeResult` class
        with the given <em>statusCode</em>.
    
        
    
        
        :param statusCode: The HTTP status code of the response.
        
        :type statusCode: System.Int32
    
        
        .. code-block:: csharp
    
            public StatusCodeResult(int statusCode)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.StatusCodeResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.StatusCodeResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.StatusCodeResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.StatusCodeResult.StatusCode
    
        
    
        
        Gets the HTTP status code.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode { get; }
    

