

JsonResultExecutor Class
========================






Executes a :any:`Microsoft.AspNetCore.Mvc.JsonResult` to write to the response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor`








Syntax
------

.. code-block:: csharp

    public class JsonResultExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor.JsonResultExecutor(Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcJsonOptions>, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor`\.
    
        
    
        
        :param writerFactory: The :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory`\.
        
        :type writerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger\`1`\.
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor<Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor>}
    
        
        :param options: The :any:`Microsoft.Extensions.Options.IOptions\`1`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcJsonOptions<Microsoft.AspNetCore.Mvc.MvcJsonOptions>}
    
        
        :param charPool: The :any:`System.Buffers.ArrayPool\`1` for creating :any:`char[]` buffers.
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public JsonResultExecutor(IHttpResponseStreamWriterFactory writerFactory, ILogger<JsonResultExecutor> logger, IOptions<MvcJsonOptions> options, ArrayPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.JsonResult)
    
        
    
        
        Executes the :any:`Microsoft.AspNetCore.Mvc.JsonResult` and writes the response.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param result: The :any:`Microsoft.AspNetCore.Mvc.JsonResult`\.
        
        :type result: Microsoft.AspNetCore.Mvc.JsonResult
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` which will complete when writing has completed.
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ActionContext context, JsonResult result)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor.Logger
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor.Options
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.MvcJsonOptions`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.MvcJsonOptions
    
        
        .. code-block:: csharp
    
            protected MvcJsonOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonResultExecutor.WriterFactory
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    
        
        .. code-block:: csharp
    
            protected IHttpResponseStreamWriterFactory WriterFactory { get; }
    

