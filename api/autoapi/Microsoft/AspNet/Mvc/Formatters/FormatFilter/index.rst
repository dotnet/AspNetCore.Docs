

FormatFilter Class
==================



.. contents:: 
   :local:



Summary
-------

A filter which will use the format value in the route data or query string to set the content type on an 
:any:`Microsoft.AspNet.Mvc.ObjectResult` returned from an action.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.FormatFilter`








Syntax
------

.. code-block:: csharp

   public class FormatFilter : IFormatFilter, IResourceFilter, IResultFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Formatters/FormatFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.FormatFilter(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcOptions>, Microsoft.AspNet.Mvc.Infrastructure.IActionContextAccessor)
    
        
    
        Initializes an instance of :any:`Microsoft.AspNet.Mvc.Formatters.FormatFilter`\.
    
        
        
        
        :param options: The
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcOptions}
        
        
        :param actionContextAccessor: The
        
        :type actionContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionContextAccessor
    
        
        .. code-block:: csharp
    
           public FormatFilter(IOptions<MvcOptions> options, IActionContextAccessor actionContextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.OnResourceExecuted(Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.OnResourceExecuting(Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext)
    
        
    
        As a :any:`Microsoft.AspNet.Mvc.Filters.IResourceFilter`\, this filter looks at the request and rejects it before going ahead if
        1. The format in the request does not match any format in the map.
        2. If there is a conflicting producesFilter.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuting(ResourceExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.OnResultExecuted(Microsoft.AspNet.Mvc.Filters.ResultExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.OnResultExecuting(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext)
    
        
    
        Sets a Content Type on an  :any:`Microsoft.AspNet.Mvc.ObjectResult`  using a format value from the request.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnResultExecuting(ResultExecutingContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.ContentType
    
        
    
        :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` for the format value in the current request.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.Format
    
        
    
        Format value in the current request. <c>null</c> if format not present in the current request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Format { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.FormatFilter.IsActive
    
        
    
        <c>true</c> if the current :any:`Microsoft.AspNet.Mvc.Formatters.FormatFilter` is active and will execute.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsActive { get; }
    

