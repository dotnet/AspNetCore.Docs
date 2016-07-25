

TextOutputFormatter Class
=========================






Writes an object in a given text format to the output stream.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter`








Syntax
------

.. code-block:: csharp

    public abstract class TextOutputFormatter : OutputFormatter, IOutputFormatter, IApiResponseTypeMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.TextOutputFormatter()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter` class.
    
        
    
        
        .. code-block:: csharp
    
            protected TextOutputFormatter()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.SelectCharacterEncoding(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        Determines the best :any:`System.Text.Encoding` amongst the supported encodings
        for reading or writing an HTTP entity body based on the provided content type.
    
        
    
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Text.Encoding
        :return: The :any:`System.Text.Encoding` to use when reading the request or writing the response.
    
        
        .. code-block:: csharp
    
            public virtual Encoding SelectCharacterEncoding(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override sealed Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.WriteResponseBodyAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Text.Encoding)
    
        
    
        
        Writes the response body.
    
        
    
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :param selectedEncoding: The :any:`System.Text.Encoding` that should be used to write the response.
        
        :type selectedEncoding: System.Text.Encoding
        :rtype: System.Threading.Tasks.Task
        :return: A task which can write the response body.
    
        
        .. code-block:: csharp
    
            public abstract Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.SupportedEncodings
    
        
    
        
        Gets the mutable collection of character encodings supported by
        this :any:`Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter`\. The encodings are
        used when writing the data.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Text.Encoding<System.Text.Encoding>}
    
        
        .. code-block:: csharp
    
            public IList<Encoding> SupportedEncodings { get; }
    

