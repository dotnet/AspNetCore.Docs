

OutputFormatterWriteContext Class
=================================






A context object for :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`








Syntax
------

.. code-block:: csharp

    public class OutputFormatterWriteContext : OutputFormatterCanWriteContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext.HttpContext
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext.HttpContext` context associated with the current operation.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public virtual HttpContext HttpContext
            {
                get;
                protected set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext.WriterFactory
    
        
    
        
        Gets or sets a delegate used to create a :any:`System.IO.TextWriter` for writing the response.
    
        
        :rtype: System.Func<System.Func`3>{System.IO.Stream<System.IO.Stream>, System.Text.Encoding<System.Text.Encoding>, System.IO.TextWriter<System.IO.TextWriter>}
    
        
        .. code-block:: csharp
    
            public virtual Func<Stream, Encoding, TextWriter> WriterFactory
            {
                get;
                protected set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext.OutputFormatterWriteContext(Microsoft.AspNetCore.Http.HttpContext, System.Func<System.IO.Stream, System.Text.Encoding, System.IO.TextWriter>, System.Type, System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`\.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param writerFactory: The delegate used to create a :any:`System.IO.TextWriter` for writing the response.
        
        :type writerFactory: System.Func<System.Func`3>{System.IO.Stream<System.IO.Stream>, System.Text.Encoding<System.Text.Encoding>, System.IO.TextWriter<System.IO.TextWriter>}
    
        
        :param objectType: The :any:`System.Type` of the object to write to the response.
        
        :type objectType: System.Type
    
        
        :param object: The object to write to the response.
        
        :type object: System.Object
    
        
        .. code-block:: csharp
    
            public OutputFormatterWriteContext(HttpContext httpContext, Func<Stream, Encoding, TextWriter> writerFactory, Type objectType, object object)
    

