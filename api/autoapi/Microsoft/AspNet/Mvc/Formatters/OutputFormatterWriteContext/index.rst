

OutputFormatterWriteContext Class
=================================



.. contents:: 
   :local:



Summary
-------

A context object for :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext`








Syntax
------

.. code-block:: csharp

   public class OutputFormatterWriteContext : OutputFormatterCanWriteContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Formatters/OutputFormatterWriteContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext.OutputFormatterWriteContext(Microsoft.AspNet.Http.HttpContext, System.Func<System.IO.Stream, System.Text.Encoding, System.IO.TextWriter>, System.Type, System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext`\.
    
        
        
        
        :param httpContext: The  for the current request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param writerFactory: The delegate used to create a  for writing the response.
        
        :type writerFactory: System.Func{System.IO.Stream,System.Text.Encoding,System.IO.TextWriter}
        
        
        :param objectType: The  of the object to write to the response.
        
        :type objectType: System.Type
        
        
        :param object: The object to write to the response.
        
        :type object: System.Object
    
        
        .. code-block:: csharp
    
           public OutputFormatterWriteContext(HttpContext httpContext, Func<Stream, Encoding, TextWriter> writerFactory, Type objectType, object object)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext.HttpContext
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext.HttpContext` context associated with the current operation.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public virtual HttpContext HttpContext { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext.WriterFactory
    
        
    
        Gets or sets a delegate used to create a :any:`System.IO.TextWriter` for writing the response.
    
        
        :rtype: System.Func{System.IO.Stream,System.Text.Encoding,System.IO.TextWriter}
    
        
        .. code-block:: csharp
    
           public virtual Func<Stream, Encoding, TextWriter> WriterFactory { get; protected set; }
    

