

OutputFormatter Class
=====================



.. contents:: 
   :local:



Summary
-------

Writes an object to the output stream.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`








Syntax
------

.. code-block:: csharp

   public abstract class OutputFormatter : IOutputFormatter, IApiResponseFormatMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Formatters/OutputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.OutputFormatter()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter` class.
    
        
    
        
        .. code-block:: csharp
    
           protected OutputFormatter()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.CanWriteType(System.Type)
    
        
    
        Returns a value indicating whether or not the given type can be written by this serializer.
    
        
        
        
        :param type: The object type.
        
        :type type: System.Type
        :rtype: System.Boolean
        :return: <c>true</c> if the type can be written, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool CanWriteType(Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.GetSupportedContentTypes(Microsoft.Net.Http.Headers.MediaTypeHeaderValue, System.Type)
    
        
        
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        
        
        :type objectType: System.Type
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public virtual IReadOnlyList<MediaTypeHeaderValue> GetSupportedContentTypes(MediaTypeHeaderValue contentType, Type objectType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.SelectCharacterEncoding(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        Determines the best :any:`System.Text.Encoding` amongst the supported encodings
        for reading or writing an HTTP entity body based on the provided ``contentTypeHeader``.
    
        
        
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Text.Encoding
        :return: The <see cref="T:System.Text.Encoding" /> to use when reading the request or writing the response.
    
        
        .. code-block:: csharp
    
           public virtual Encoding SelectCharacterEncoding(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task WriteAsync(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.WriteResponseBodyAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        Writes the response body.
    
        
        
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
        :return: A task which can write the response body.
    
        
        .. code-block:: csharp
    
           public abstract Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.WriteResponseHeaders(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        Sets the headers on :any:`Microsoft.AspNet.Http.HttpResponse` object.
    
        
        
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
    
        
        .. code-block:: csharp
    
           public virtual void WriteResponseHeaders(OutputFormatterWriteContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.SupportedEncodings
    
        
    
        Gets the mutable collection of character encodings supported by
        this :any:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`\. The encodings are
        used when writing the data.
    
        
        :rtype: System.Collections.Generic.IList{System.Text.Encoding}
    
        
        .. code-block:: csharp
    
           public IList<Encoding> SupportedEncodings { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.OutputFormatter.SupportedMediaTypes
    
        
    
        Gets the mutable collection of :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` elements supported by
        this :any:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`\.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<MediaTypeHeaderValue> SupportedMediaTypes { get; }
    

