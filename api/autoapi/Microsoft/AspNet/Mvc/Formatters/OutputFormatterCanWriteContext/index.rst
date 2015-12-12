

OutputFormatterCanWriteContext Class
====================================



.. contents:: 
   :local:



Summary
-------

A context object for :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext`








Syntax
------

.. code-block:: csharp

   public abstract class OutputFormatterCanWriteContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Formatters/OutputFormatterCanWriteContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext.ContentType
    
        
    
        Gets or sets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` of the content type to write to the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public virtual MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext.FailedContentNegotiation
    
        
    
        Gets or sets a value indicating that content-negotiation could not find a formatter based on the
        information on the :any:`Microsoft.AspNet.Http.HttpRequest`\.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public virtual bool ? FailedContentNegotiation { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext.Object
    
        
    
        Gets or sets the object to write to the response.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object Object { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext.ObjectType
    
        
    
        Gets or sets the :any:`System.Type` of the object to write to the response.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public virtual Type ObjectType { get; protected set; }
    

