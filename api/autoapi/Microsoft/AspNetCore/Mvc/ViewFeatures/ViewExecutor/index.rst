

ViewExecutor Class
==================






Executes an :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor`








Syntax
------

.. code-block:: csharp

    public class ViewExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ViewEngines.IView, Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary, System.String, System.Nullable<System.Int32>)
    
        
    
        
        Executes a view asynchronously.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param view: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView`\.
        
        :type view: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    
        
        :param viewData: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param tempData: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary`\.
        
        :type tempData: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        :param contentType: 
            The content-type header value to set in the response. If <code>null</code>, 
            :dn:field:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.DefaultContentType` will be used.
        
        :type contentType: System.String
    
        
        :param statusCode: 
            The HTTP status code to set in the response. May be <code>null</code>.
        
        :type statusCode: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` which will complete when view execution is completed.
    
        
        .. code-block:: csharp
    
            public virtual Task ExecuteAsync(ActionContext actionContext, IView view, ViewDataDictionary viewData, ITempDataDictionary tempData, string contentType, int ? statusCode)
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.ViewExecutor(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>, Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory, Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory, System.Diagnostics.DiagnosticSource, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor`\.
    
        
    
        
        :param viewOptions: The :any:`Microsoft.Extensions.Options.IOptions\`1`\.
        
        :type viewOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
    
        
        :param writerFactory: The :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory`\.
        
        :type writerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    
        
        :param viewEngine: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine`\.
        
        :type viewEngine: Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine
    
        
        :param tempDataFactory: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory`\.
        
        :type tempDataFactory: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    
        
        :param diagnosticSource: The :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.DiagnosticSource`\.
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :param modelMetadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public ViewExecutor(IOptions<MvcViewOptions> viewOptions, IHttpResponseStreamWriterFactory writerFactory, ICompositeViewEngine viewEngine, ITempDataDictionaryFactory tempDataFactory, DiagnosticSource diagnosticSource, IModelMetadataProvider modelMetadataProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.DiagnosticSource
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.DiagnosticSource`\.
    
        
        :rtype: System.Diagnostics.DiagnosticSource
    
        
        .. code-block:: csharp
    
            protected DiagnosticSource DiagnosticSource { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.TempDataFactory
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    
        
        .. code-block:: csharp
    
            protected ITempDataDictionaryFactory TempDataFactory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.ViewEngine
    
        
    
        
        Gets the default :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    
        
        .. code-block:: csharp
    
            protected IViewEngine ViewEngine { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.ViewOptions
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.MvcViewOptions
    
        
        .. code-block:: csharp
    
            protected MvcViewOptions ViewOptions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.WriterFactory
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory
    
        
        .. code-block:: csharp
    
            protected IHttpResponseStreamWriterFactory WriterFactory { get; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewExecutor.DefaultContentType
    
        
    
        
        The default content-type header value for views, <code>text/html; charset=utf-8</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultContentType
    

