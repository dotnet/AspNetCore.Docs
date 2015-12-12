

NegotiatedContentResult<T> Class
================================



.. contents:: 
   :local:



Summary
-------

An action result that performs content negotiation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.NegotiatedContentResult\<T>`








Syntax
------

.. code-block:: csharp

   public class NegotiatedContentResult<T> : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/NegotiatedContentResult.cs>`_





.. dn:class:: System.Web.Http.NegotiatedContentResult<T>

Constructors
------------

.. dn:class:: System.Web.Http.NegotiatedContentResult<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Web.Http.NegotiatedContentResult<T>.NegotiatedContentResult(System.Net.HttpStatusCode, T)
    
        
    
        Initializes a new instance of the :any:`System.Web.Http.NegotiatedContentResult\`1` class with the values provided.
    
        
        
        
        :param statusCode: The HTTP status code for the response message.
        
        :type statusCode: System.Net.HttpStatusCode
        
        
        :param content: The content value to negotiate and format in the entity body.
        
        :type content: {T}
    
        
        .. code-block:: csharp
    
           public NegotiatedContentResult(HttpStatusCode statusCode, T content)
    

Methods
-------

.. dn:class:: System.Web.Http.NegotiatedContentResult<T>
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.NegotiatedContentResult<T>.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: System.Web.Http.NegotiatedContentResult<T>
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.NegotiatedContentResult<T>.Content
    
        
    
        Gets the content value to negotiate and format in the entity body.
    
        
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T Content { get; }
    

