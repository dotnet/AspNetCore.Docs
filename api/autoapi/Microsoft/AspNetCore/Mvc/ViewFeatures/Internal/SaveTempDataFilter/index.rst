

SaveTempDataFilter Class
========================






A filter that saves temp data.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter`








Syntax
------

.. code-block:: csharp

    public class SaveTempDataFilter : IResourceFilter, IResultFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter.SaveTempDataFilter(Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter`\.
    
        
    
        
        :param factory: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory`\.
        
        :type factory: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    
        
        .. code-block:: csharp
    
            public SaveTempDataFilter(ITempDataDictionaryFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuting(ResourceExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.SaveTempDataFilter.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnResultExecuting(ResultExecutingContext context)
    

