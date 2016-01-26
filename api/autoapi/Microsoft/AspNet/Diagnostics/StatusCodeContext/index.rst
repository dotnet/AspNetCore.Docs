

StatusCodeContext Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.StatusCodeContext`








Syntax
------

.. code-block:: csharp

   public class StatusCodeContext





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/StatusCodePage/StatusCodeContext.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodeContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodeContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.StatusCodeContext.StatusCodeContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Diagnostics.StatusCodePagesOptions, Microsoft.AspNet.Builder.RequestDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public StatusCodeContext(HttpContext context, StatusCodePagesOptions options, RequestDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.StatusCodeContext.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.StatusCodeContext.Next
    
        
        :rtype: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public RequestDelegate Next { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.StatusCodeContext.Options
    
        
        :rtype: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions
    
        
        .. code-block:: csharp
    
           public StatusCodePagesOptions Options { get; }
    

