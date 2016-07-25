

ViewComponentResultExecutor Class
=================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor`








Syntax
------

.. code-block:: csharp

    public class ViewComponentResultExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor.ViewComponentResultExecutor(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>, Microsoft.AspNetCore.Mvc.IViewComponentHelper, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.HtmlEncoder, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory)
    
        
    
        
        :type mvcHelperOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcViewOptions<Microsoft.AspNetCore.Mvc.MvcViewOptions>}
    
        
        :type viewComponentHelper: Microsoft.AspNetCore.Mvc.IViewComponentHelper
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :type tempDataDictionaryFactory: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    
        
        .. code-block:: csharp
    
            public ViewComponentResultExecutor(IOptions<MvcViewOptions> mvcHelperOptions, IViewComponentHelper viewComponentHelper, ILoggerFactory loggerFactory, HtmlEncoder htmlEncoder, IModelMetadataProvider modelMetadataProvider, ITempDataDictionaryFactory tempDataDictionaryFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewComponentResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.ViewComponentResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type viewComponentResult: Microsoft.AspNetCore.Mvc.ViewComponentResult
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ActionContext context, ViewComponentResult viewComponentResult)
    

