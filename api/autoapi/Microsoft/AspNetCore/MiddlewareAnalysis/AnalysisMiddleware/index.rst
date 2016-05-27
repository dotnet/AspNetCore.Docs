

AnalysisMiddleware Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.MiddlewareAnalysis`
Assemblies
    * Microsoft.AspNetCore.MiddlewareAnalysis

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware`








Syntax
------

.. code-block:: csharp

    public class AnalysisMiddleware








.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware.AnalysisMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, System.Diagnostics.DiagnosticSource, System.String)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
    
        
        :type middlewareName: System.String
    
        
        .. code-block:: csharp
    
            public AnalysisMiddleware(RequestDelegate next, DiagnosticSource diagnosticSource, string middlewareName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext httpContext)
    

