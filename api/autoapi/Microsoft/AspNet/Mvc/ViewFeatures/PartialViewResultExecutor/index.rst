

PartialViewResultExecutor Class
===============================



.. contents:: 
   :local:



Summary
-------

Finds and executes an :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` for a :any:`Microsoft.AspNet.Mvc.PartialViewResult`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor`








Syntax
------

.. code-block:: csharp

   public class PartialViewResultExecutor : ViewExecutor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/PartialViewResultExecutor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor.PartialViewResultExecutor(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcViewOptions>, Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory, Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor`\.
    
        
        
        
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
    
           public PartialViewResultExecutor(IOptions<MvcViewOptions> viewOptions, IHttpResponseStreamWriterFactory writerFactory, ICompositeViewEngine viewEngine, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor.ExecuteAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.PartialViewResult)
    
        
    
        Executes the :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` asynchronously.
    
        
        
        
        :param actionContext: The  associated with the current request.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param view: The .
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :param viewResult: The .
        
        :type viewResult: Microsoft.AspNet.Mvc.PartialViewResult
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which will complete when view execution is completed.
    
        
        .. code-block:: csharp
    
           public virtual Task ExecuteAsync(ActionContext actionContext, IView view, PartialViewResult viewResult)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor.FindView(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.PartialViewResult)
    
        
    
        Attempts to find the :any:`Microsoft.AspNet.Mvc.ViewEngines.IView` associated with ``viewResult``.
    
        
        
        
        :param actionContext: The  associated with the current request.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param viewResult: The .
        
        :type viewResult: Microsoft.AspNet.Mvc.PartialViewResult
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult" />.
    
        
        .. code-block:: csharp
    
           public virtual ViewEngineResult FindView(ActionContext actionContext, PartialViewResult viewResult)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.PartialViewResultExecutor.Logger
    
        
    
        Gets the :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected ILogger Logger { get; }
    

