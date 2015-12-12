

ViewResultExecutor Class
========================



.. contents:: 
   :local:



Summary
-------

Finds and executes an :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` for a :any:`Microsoft.AspNet.Mvc.ViewResult`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor`








Syntax
------

.. code-block:: csharp

   public class ViewResultExecutor : ViewExecutor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ViewResultExecutor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor.ViewResultExecutor(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcViewOptions>, Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory, Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor`\.
    
        
        
        
        :param viewOptions: The .
        
        :type viewOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcViewOptions}
        
        
        :param writerFactory: The .
        
        :type writerFactory: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory
        
        
        :param viewEngine: The .
        
        :type viewEngine: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine
        
        
        :param diagnosticSource: The .
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :param loggerFactory: The .
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public ViewResultExecutor(IOptions<MvcViewOptions> viewOptions, IHttpResponseStreamWriterFactory writerFactory, ICompositeViewEngine viewEngine, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor.ExecuteAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.ViewResult)
    
        
    
        Executes the :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` asynchronously.
    
        
        
        
        :param actionContext: The  associated with the current request.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param view: The .
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :param viewResult: The .
        
        :type viewResult: Microsoft.AspNet.Mvc.ViewResult
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which will complete when view execution is completed.
    
        
        .. code-block:: csharp
    
           public virtual Task ExecuteAsync(ActionContext actionContext, IView view, ViewResult viewResult)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor.FindView(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ViewResult)
    
        
    
        Attempts to find the :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` associated with ``viewResult``.
    
        
        
        
        :param actionContext: The  associated with the current request.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param viewResult: The .
        
        :type viewResult: Microsoft.AspNet.Mvc.ViewResult
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult" />.
    
        
        .. code-block:: csharp
    
           public virtual ViewEngineResult FindView(ActionContext actionContext, ViewResult viewResult)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewResultExecutor.Logger
    
        
    
        Gets the :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected ILogger Logger { get; }
    

