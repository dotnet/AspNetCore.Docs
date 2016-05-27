

ViewResultExecutor Class
========================






Finds and executes an :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` for a :any:`Microsoft.AspNetCore.Mvc.ViewResult`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor`








Syntax
------

.. code-block:: csharp

    public class ViewResultExecutor : ViewExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor.Logger
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor.ViewResultExecutor(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>, Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory, Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory, System.Diagnostics.DiagnosticSource, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor`\.
    
        
    
        
        :param viewOptions: The :any:`Microsoft.Extensions.Options.IOptions\`1`\.
        
        :type viewOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
    
        
        :param writerFactory: The :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory`\.
        
        :type writerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    
        
        :param viewEngine: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine`\.
        
        :type viewEngine: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine
    
        
        :param tempDataFactory: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory`\.
        
        :type tempDataFactory: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    
        
        :param diagnosticSource: The :any:`System.Diagnostics.DiagnosticSource`\.
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public ViewResultExecutor(IOptions<MvcViewOptions> viewOptions, IHttpResponseStreamWriterFactory writerFactory, ICompositeViewEngine viewEngine, ITempDataDictionaryFactory tempDataFactory, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ViewEngines.IView, Microsoft.AspNetCore.Mvc.ViewResult)
    
        
    
        
        Executes the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` asynchronously.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param view: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView`\.
        
        :type view: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    
        
        :param viewResult: The :any:`Microsoft.AspNetCore.Mvc.ViewResult`\.
        
        :type viewResult: Microsoft.AspNetCore.Mvc.ViewResult
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` which will complete when view execution is completed.
    
        
        .. code-block:: csharp
    
            public virtual Task ExecuteAsync(ActionContext actionContext, IView view, ViewResult viewResult)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewResultExecutor.FindView(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ViewResult)
    
        
    
        
        Attempts to find the :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` associated with <em>viewResult</em>.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param viewResult: The :any:`Microsoft.AspNetCore.Mvc.ViewResult`\.
        
        :type viewResult: Microsoft.AspNetCore.Mvc.ViewResult
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult`\.
    
        
        .. code-block:: csharp
    
            public virtual ViewEngineResult FindView(ActionContext actionContext, ViewResult viewResult)
    

