

NegotiatedContentResult<T> Class
================================






An action result that performs content negotiation.


Namespace
    :dn:ns:`System.Web.Http`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ObjectResult`
* :dn:cls:`System.Web.Http.NegotiatedContentResult\<T>`








Syntax
------

.. code-block:: csharp

    public class NegotiatedContentResult<T> : ObjectResult, IActionResult








.. dn:class:: System.Web.Http.NegotiatedContentResult`1
    :hidden:

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
        
        :type content: T
    
        
        .. code-block:: csharp
    
            public NegotiatedContentResult(HttpStatusCode statusCode, T content)
    

Properties
----------

.. dn:class:: System.Web.Http.NegotiatedContentResult<T>
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.NegotiatedContentResult<T>.Content
    
        
    
        
        Gets the content value to negotiate and format in the entity body.
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T Content { get; }
    

Methods
-------

.. dn:class:: System.Web.Http.NegotiatedContentResult<T>
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.NegotiatedContentResult<T>.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

