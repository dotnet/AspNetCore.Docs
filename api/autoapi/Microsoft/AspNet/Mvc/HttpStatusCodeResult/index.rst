

HttpStatusCodeResult Class
==========================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ActionResult` that when executed will
produce an HTTP response with the given response status code.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpStatusCodeResult`








Syntax
------

.. code-block:: csharp

   public class HttpStatusCodeResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpStatusCodeResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpStatusCodeResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpStatusCodeResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpStatusCodeResult.HttpStatusCodeResult(System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.HttpStatusCodeResult` class
        with the given ``statusCode``.
    
        
        
        
        :param statusCode: The HTTP status code of the response.
        
        :type statusCode: System.Int32
    
        
        .. code-block:: csharp
    
           public HttpStatusCodeResult(int statusCode)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.HttpStatusCodeResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpStatusCodeResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void ExecuteResult(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.HttpStatusCodeResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.HttpStatusCodeResult.StatusCode
    
        
    
        Gets the HTTP status code.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int StatusCode { get; }
    

