

ViewExecutor Class
==================



.. contents:: 
   :local:



Summary
-------

Executes an :any:`Microsoft.AspNet.Mvc.ViewEngines.IView`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor`








Syntax
------

.. code-block:: csharp

   public class ViewExecutor





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ViewExecutor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.ViewExecutor(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcViewOptions>, Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory, Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine, System.Diagnostics.DiagnosticSource)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor`\.
    
        
        
        
        :param viewOptions: The .
        
        :type viewOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcViewOptions}
        
        
        :param writerFactory: The .
        
        :type writerFactory: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory
        
        
        :param viewEngine: The .
        
        :type viewEngine: Microsoft.AspNet.Mvc.ViewEngines.ICompositeViewEngine
        
        
        :param diagnosticSource: The .
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
           public ViewExecutor(IOptions<MvcViewOptions> viewOptions, IHttpResponseStreamWriterFactory writerFactory, ICompositeViewEngine viewEngine, DiagnosticSource diagnosticSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.ExecuteAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary, Microsoft.Net.Http.Headers.MediaTypeHeaderValue, System.Nullable<System.Int32>)
    
        
    
        Executes a view asynchronously.
    
        
        
        
        :param actionContext: The  associated with the current request.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param view: The .
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :param viewData: The .
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param tempData: The .
        
        :type tempData: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
        
        
        :param contentType: The content-type header value to set in the response. If null,  will be used.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        
        
        :param statusCode: The HTTP status code to set in the response. May be null.
        
        :type statusCode: System.Nullable{System.Int32}
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which will complete when view execution is completed.
    
        
        .. code-block:: csharp
    
           public virtual Task ExecuteAsync(ActionContext actionContext, IView view, ViewDataDictionary viewData, ITempDataDictionary tempData, MediaTypeHeaderValue contentType, int ? statusCode)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.DefaultContentType
    
        
    
        The default content-type header value for views, <c>text/html; charset=utf8</c>.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly MediaTypeHeaderValue DefaultContentType
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.DiagnosticSource
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.DiagnosticSource`\.
    
        
        :rtype: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
           protected DiagnosticSource DiagnosticSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.ViewEngine
    
        
    
        Gets the default :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
           protected IViewEngine ViewEngine { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.ViewOptions
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.MvcViewOptions`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.MvcViewOptions
    
        
        .. code-block:: csharp
    
           protected MvcViewOptions ViewOptions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewExecutor.WriterFactory
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory
    
        
        .. code-block:: csharp
    
           protected IHttpResponseStreamWriterFactory WriterFactory { get; }
    

