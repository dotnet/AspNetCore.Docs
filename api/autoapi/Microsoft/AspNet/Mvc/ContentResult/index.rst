

ContentResult Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ContentResult`








Syntax
------

.. code-block:: csharp

   public class ContentResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ContentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ContentResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ContentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ContentResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ContentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ContentResult.Content
    
        
    
        Gets or set the content representing the body of the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Content { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ContentResult.ContentType
    
        
    
        Gets or sets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` representing the Content-Type header of the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ContentResult.StatusCode
    
        
    
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? StatusCode { get; set; }
    

