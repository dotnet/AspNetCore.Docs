

ObjectResult Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`








Syntax
------

.. code-block:: csharp

   public class ObjectResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ObjectResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ObjectResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ObjectResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ObjectResult.ObjectResult(System.Object)
    
        
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public ObjectResult(object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ObjectResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ObjectResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ObjectResult.OnFormatting(Microsoft.AspNet.Mvc.ActionContext)
    
        
    
        This method is called before the formatter writes to the output stream.
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public virtual void OnFormatting(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ObjectResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ObjectResult.ContentTypes
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<MediaTypeHeaderValue> ContentTypes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ObjectResult.DeclaredType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type DeclaredType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ObjectResult.Formatters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
    
        
        .. code-block:: csharp
    
           public IList<IOutputFormatter> Formatters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ObjectResult.StatusCode
    
        
    
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ObjectResult.Value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Value { get; set; }
    

