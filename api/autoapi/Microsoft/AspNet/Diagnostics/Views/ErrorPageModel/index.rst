

ErrorPageModel Class
====================



.. contents:: 
   :local:



Summary
-------

Holds data to be displayed on the error page.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.ErrorPageModel`








Syntax
------

.. code-block:: csharp

   public class ErrorPageModel





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/DeveloperExceptionPage/Views/ErrorPageModel.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel.Cookies
    
        
    
        Request cookies.
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public IReadableStringCollection Cookies { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel.ErrorDetails
    
        
    
        Detailed information about each exception in the stack.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Diagnostics.Views.ErrorDetails}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ErrorDetails> ErrorDetails { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel.Headers
    
        
    
        Request headers.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, StringValues> Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel.Options
    
        
    
        Options for what output to display.
    
        
        :rtype: Microsoft.AspNet.Diagnostics.ErrorPageOptions
    
        
        .. code-block:: csharp
    
           public ErrorPageOptions Options { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel.Query
    
        
    
        Parsed query data.
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public IReadableStringCollection Query { get; set; }
    

