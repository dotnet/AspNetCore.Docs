

UnsupportedContentTypeFilter Class
==================================






A filter that scans for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException` in the 
:dn:prop:`Microsoft.AspNetCore.Mvc.ActionContext.ModelState` and short-circuits the pipeline
with an Unsupported Media Type (415) response.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter`








Syntax
------

.. code-block:: csharp

    public class UnsupportedContentTypeFilter : IActionFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnActionExecuting(ActionExecutingContext context)
    

