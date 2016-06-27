

ObjectResultExecutor Class
==========================






Executes an :any:`Microsoft.AspNetCore.Mvc.ObjectResult` to write to the response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor`








Syntax
------

.. code-block:: csharp

    public class ObjectResultExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.ObjectResultExecutor(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>, Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor`\.
    
        
    
        
        :param options: An accessor to :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        :param writerFactory: The :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory`\.
        
        :type writerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public ObjectResultExecutor(IOptions<MvcOptions> options, IHttpResponseStreamWriterFactory writerFactory, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ObjectResult)
    
        
    
        
        Executes the :any:`Microsoft.AspNetCore.Mvc.ObjectResult`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` for the current request.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param result: The :any:`Microsoft.AspNetCore.Mvc.ObjectResult`\.
        
        :type result: Microsoft.AspNetCore.Mvc.ObjectResult
        :rtype: System.Threading.Tasks.Task
        :return: 
            A :any:`System.Threading.Tasks.Task` which will complete once the :any:`Microsoft.AspNetCore.Mvc.ObjectResult` is written to the response.
    
        
        .. code-block:: csharp
    
            public virtual Task ExecuteAsync(ActionContext context, ObjectResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.SelectFormatter(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>)
    
        
    
        
        Selects the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` to write the response.
    
        
    
        
        :param formatterContext: The :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`\.
        
        :type formatterContext: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :param contentTypes: 
            The list of content types provided by :dn:prop:`Microsoft.AspNetCore.Mvc.ObjectResult.ContentTypes`\.
        
        :type contentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        :param formatters: 
            The list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` instances to consider.
        
        :type formatters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
        :return: 
            The selected :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` or <code>null</code> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
            protected virtual IOutputFormatter SelectFormatter(OutputFormatterWriteContext formatterContext, MediaTypeCollection contentTypes, IList<IOutputFormatter> formatters)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.SelectFormatterNotUsingContentType(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>)
    
        
    
        
        Selects the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` to write the response. The first formatter which
        can write the response should be chosen without any consideration for content type.
    
        
    
        
        :param formatterContext: The :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`\.
        
        :type formatterContext: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :param formatters: 
            The list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` instances to consider.
        
        :type formatters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
        :return: 
            The selected :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` or <code>null</code> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
            protected virtual IOutputFormatter SelectFormatterNotUsingContentType(OutputFormatterWriteContext formatterContext, IList<IOutputFormatter> formatters)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.SelectFormatterUsingAnyAcceptableContentType(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>, Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        Selects the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` to write the response based on the content type values
        present in <em>acceptableContentTypes</em>.
    
        
    
        
        :param formatterContext: The :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`\.
        
        :type formatterContext: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :param formatters: 
            The list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` instances to consider.
        
        :type formatters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
    
        
        :param acceptableContentTypes: 
            The ordered content types from :dn:prop:`Microsoft.AspNetCore.Mvc.ObjectResult.ContentTypes` in descending priority order.
        
        :type acceptableContentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
        :return: 
            The selected :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` or <code>null</code> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
            protected virtual IOutputFormatter SelectFormatterUsingAnyAcceptableContentType(OutputFormatterWriteContext formatterContext, IList<IOutputFormatter> formatters, MediaTypeCollection acceptableContentTypes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.SelectFormatterUsingSortedAcceptHeaders(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>)
    
        
    
        
        Selects the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` to write the response based on the content type values
        present in <em>sortedAcceptHeaders</em>.
    
        
    
        
        :param formatterContext: The :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`\.
        
        :type formatterContext: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :param formatters: 
            The list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` instances to consider.
        
        :type formatters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
    
        
        :param sortedAcceptHeaders: 
            The ordered content types from the <code>Accept</code> header, sorted by descending q-value.
        
        :type sortedAcceptHeaders: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>}
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
        :return: 
            The selected :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` or <code>null</code> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
            protected virtual IOutputFormatter SelectFormatterUsingSortedAcceptHeaders(OutputFormatterWriteContext formatterContext, IList<IOutputFormatter> formatters, IList<MediaTypeSegmentWithQuality> sortedAcceptHeaders)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.SelectFormatterUsingSortedAcceptHeadersAndContentTypes(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>, Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        Selects the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` to write the response based on the content type values
        present in <em>sortedAcceptableContentTypes</em> and <em>possibleOutputContentTypes</em>.
    
        
    
        
        :param formatterContext: The :any:`Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext`\.
        
        :type formatterContext: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
    
        
        :param formatters: 
            The list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` instances to consider.
        
        :type formatters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
    
        
        :param sortedAcceptableContentTypes: 
            The ordered content types from the <code>Accept</code> header, sorted by descending q-value.
        
        :type sortedAcceptableContentTypes: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>}
    
        
        :param possibleOutputContentTypes: 
            The ordered content types from :dn:prop:`Microsoft.AspNetCore.Mvc.ObjectResult.ContentTypes` in descending priority order.
        
        :type possibleOutputContentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
        :return: 
            The selected :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` or <code>null</code> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
            protected virtual IOutputFormatter SelectFormatterUsingSortedAcceptHeadersAndContentTypes(OutputFormatterWriteContext formatterContext, IList<IOutputFormatter> formatters, IList<MediaTypeSegmentWithQuality> sortedAcceptableContentTypes, MediaTypeCollection possibleOutputContentTypes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.Logger
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.OptionsFormatters
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` instances from :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
    
        
        .. code-block:: csharp
    
            protected FormatterCollection<IOutputFormatter> OptionsFormatters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.RespectBrowserAcceptHeader
    
        
    
        
        Gets the value of :dn:prop:`Microsoft.AspNetCore.Mvc.MvcOptions.RespectBrowserAcceptHeader`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool RespectBrowserAcceptHeader { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.ReturnHttpNotAcceptable
    
        
    
        
        Gets the value of :dn:prop:`Microsoft.AspNetCore.Mvc.MvcOptions.ReturnHttpNotAcceptable`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool ReturnHttpNotAcceptable { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectResultExecutor.WriterFactory
    
        
    
        
        Gets the writer factory delegate.
    
        
        :rtype: System.Func<System.Func`3>{System.IO.Stream<System.IO.Stream>, System.Text.Encoding<System.Text.Encoding>, System.IO.TextWriter<System.IO.TextWriter>}
    
        
        .. code-block:: csharp
    
            protected Func<Stream, Encoding, TextWriter> WriterFactory { get; }
    

