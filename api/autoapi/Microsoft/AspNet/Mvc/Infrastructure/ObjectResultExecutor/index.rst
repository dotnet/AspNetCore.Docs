

ObjectResultExecutor Class
==========================



.. contents:: 
   :local:



Summary
-------

Executes an :any:`Microsoft.AspNet.Mvc.ObjectResult` to write to the response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor`








Syntax
------

.. code-block:: csharp

   public class ObjectResultExecutor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/ObjectResultExecutor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.ObjectResultExecutor(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcOptions>, Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor, Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor`\.
    
        
        
        
        :param options: An accessor to .
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcOptions}
        
        
        :param bindingContextAccessor: The .
        
        :type bindingContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionBindingContextAccessor
        
        
        :type writerFactory: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory
        
        
        :param loggerFactory: The .
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public ObjectResultExecutor(IOptions<MvcOptions> options, IActionBindingContextAccessor bindingContextAccessor, IHttpResponseStreamWriterFactory writerFactory, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.ExecuteAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ObjectResult)
    
        
    
        Executes the :any:`Microsoft.AspNet.Mvc.ObjectResult`\.
    
        
        
        
        :param context: The  for the current request.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param result: The .
        
        :type result: Microsoft.AspNet.Mvc.ObjectResult
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which will complete once the <see cref="T:Microsoft.AspNet.Mvc.ObjectResult" /> is written to the response.
    
        
        .. code-block:: csharp
    
           public virtual Task ExecuteAsync(ActionContext context, ObjectResult result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.SelectFormatter(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IList<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Formatters.IOutputFormatter>)
    
        
    
        Selects the :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` to write the response.
    
        
        
        
        :param formatterContext: The .
        
        :type formatterContext: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        
        
        :param contentTypes: The list of content types provided by .
        
        :type contentTypes: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
        
        
        :param formatters: The list of  instances to consider.
        
        :type formatters: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
        :rtype: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter
        :return: The selected <see cref="T:Microsoft.AspNet.Mvc.Formatters.IOutputFormatter" /> or <c>null</c> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
           protected virtual IOutputFormatter SelectFormatter(OutputFormatterWriteContext formatterContext, IList<MediaTypeHeaderValue> contentTypes, IEnumerable<IOutputFormatter> formatters)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.SelectFormatterNotUsingAcceptHeaders(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Formatters.IOutputFormatter>)
    
        
    
        Selects the :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` to write the response. The first formatter which
        can write the response should be chosen without any consideration for content type.
    
        
        
        
        :param formatterContext: The .
        
        :type formatterContext: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        
        
        :param formatters: The list of  instances to consider.
        
        :type formatters: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
        :rtype: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter
        :return: The selected <see cref="T:Microsoft.AspNet.Mvc.Formatters.IOutputFormatter" /> or <c>null</c> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
           protected virtual IOutputFormatter SelectFormatterNotUsingAcceptHeaders(OutputFormatterWriteContext formatterContext, IEnumerable<IOutputFormatter> formatters)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.SelectFormatterUsingAnyAcceptableContentType(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Formatters.IOutputFormatter>, System.Collections.Generic.IEnumerable<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>)
    
        
    
        Selects the :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` to write the response based on the content type values
        present in ``acceptableContentTypes``.
    
        
        
        
        :param formatterContext: The .
        
        :type formatterContext: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        
        
        :param formatters: The list of  instances to consider.
        
        :type formatters: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
        
        
        :param acceptableContentTypes: The ordered content types from  in descending priority order.
        
        :type acceptableContentTypes: System.Collections.Generic.IEnumerable{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
        :rtype: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter
        :return: The selected <see cref="T:Microsoft.AspNet.Mvc.Formatters.IOutputFormatter" /> or <c>null</c> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
           protected virtual IOutputFormatter SelectFormatterUsingAnyAcceptableContentType(OutputFormatterWriteContext formatterContext, IEnumerable<IOutputFormatter> formatters, IEnumerable<MediaTypeHeaderValue> acceptableContentTypes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.SelectFormatterUsingSortedAcceptHeaders(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Formatters.IOutputFormatter>, System.Collections.Generic.IEnumerable<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>)
    
        
    
        Selects the :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` to write the response based on the content type values
        present in ``sortedAcceptHeaders``.
    
        
        
        
        :param formatterContext: The .
        
        :type formatterContext: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        
        
        :param formatters: The list of  instances to consider.
        
        :type formatters: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
        
        
        :param sortedAcceptHeaders: The ordered content types from the Accept header, sorted by descending q-value.
        
        :type sortedAcceptHeaders: System.Collections.Generic.IEnumerable{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
        :rtype: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter
        :return: The selected <see cref="T:Microsoft.AspNet.Mvc.Formatters.IOutputFormatter" /> or <c>null</c> if no formatter can write the response.
    
        
        .. code-block:: csharp
    
           protected virtual IOutputFormatter SelectFormatterUsingSortedAcceptHeaders(OutputFormatterWriteContext formatterContext, IEnumerable<IOutputFormatter> formatters, IEnumerable<MediaTypeHeaderValue> sortedAcceptHeaders)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.BindingContext
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ActionBindingContext` for the current request.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionBindingContext
    
        
        .. code-block:: csharp
    
           protected ActionBindingContext BindingContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.Logger
    
        
    
        Gets the :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected ILogger Logger { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.OptionsFormatters
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` instances from :any:`Microsoft.AspNet.Mvc.MvcOptions`\.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
    
        
        .. code-block:: csharp
    
           protected IList<IOutputFormatter> OptionsFormatters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.RespectBrowserAcceptHeader
    
        
    
        Gets the value of :dn:prop:`Microsoft.AspNet.Mvc.MvcOptions.RespectBrowserAcceptHeader`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool RespectBrowserAcceptHeader { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.ObjectResultExecutor.WriterFactory
    
        
    
        Gets the writer factory delegate.
    
        
        :rtype: System.Func{System.IO.Stream,System.Text.Encoding,System.IO.TextWriter}
    
        
        .. code-block:: csharp
    
           protected Func<Stream, Encoding, TextWriter> WriterFactory { get; }
    

