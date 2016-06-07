

FormatFilter Class
==================






A filter that will use the format value in the route data or query string to set the content type on an
:any:`Microsoft.AspNetCore.Mvc.ObjectResult` returned from an action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.FormatFilter`








Syntax
------

.. code-block:: csharp

    public class FormatFilter : IFormatFilter, IResourceFilter, IResultFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.FormatFilter(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        Initializes an instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.FormatFilter`\.
    
        
    
        
        :param options: The :any:`Microsoft.Extensions.Options.IOptions\`1`
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        .. code-block:: csharp
    
            public FormatFilter(IOptions<MvcOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.GetFormat(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GetFormat(ActionContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)
    
        
    
        
        As a :any:`Microsoft.AspNetCore.Mvc.Filters.IResourceFilter`\, this filter looks at the request and rejects it before going ahead if
        1. The format in the request does not match any format in the map.
        2. If there is a conflicting producesFilter.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuting(ResourceExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
    
        
    
        
        Sets a Content Type on an  :any:`Microsoft.AspNetCore.Mvc.ObjectResult`  using a format value from the request.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnResultExecuting(ResultExecutingContext context)
    

