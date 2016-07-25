

StatusCodeContext Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.StatusCodeContext`








Syntax
------

.. code-block:: csharp

    public class StatusCodeContext








.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext.StatusCodeContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.StatusCodePagesOptions, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.StatusCodePagesOptions
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public StatusCodeContext(HttpContext context, StatusCodePagesOptions options, RequestDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext.Next
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate Next { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.StatusCodeContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.StatusCodePagesOptions
    
        
        .. code-block:: csharp
    
            public StatusCodePagesOptions Options { get; }
    

