

IFormatFilter Interface
=======================



.. contents:: 
   :local:



Summary
-------

A filter which produces a desired content type for the current request.











Syntax
------

.. code-block:: csharp

   public interface IFormatFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/IFormatFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.IFormatFilter

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.IFormatFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.IFormatFilter.ContentType
    
        
    
        :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` for the format value in the current request.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           MediaTypeHeaderValue ContentType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.IFormatFilter.Format
    
        
    
        format value in the current request. <c>null</c> if format not present in the current request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Format { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.IFormatFilter.IsActive
    
        
    
        <c>true</c> if the current :any:`Microsoft.AspNet.Mvc.Formatters.FormatFilter` is active and will execute.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsActive { get; }
    

