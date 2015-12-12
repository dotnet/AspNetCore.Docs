

SaveTempDataFilter Class
========================



.. contents:: 
   :local:



Summary
-------

A filter which saves temp data.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter`








Syntax
------

.. code-block:: csharp

   public class SaveTempDataFilter : IResourceFilter, IResultFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/SaveTempDataFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter.SaveTempDataFilter(Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter`\.
    
        
        
        
        :param tempData: The  for the current request.
        
        :type tempData: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public SaveTempDataFilter(ITempDataDictionary tempData)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter.OnResourceExecuted(Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter.OnResourceExecuting(Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuting(ResourceExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter.OnResultExecuted(Microsoft.AspNet.Mvc.Filters.ResultExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.SaveTempDataFilter.OnResultExecuting(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnResultExecuting(ResultExecutingContext context)
    

