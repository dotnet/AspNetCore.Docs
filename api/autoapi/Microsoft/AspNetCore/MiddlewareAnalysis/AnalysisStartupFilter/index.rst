

AnalysisStartupFilter Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisStartupFilter`








Syntax
------

.. code-block:: csharp

    public class AnalysisStartupFilter : IStartupFilter








.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisStartupFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisStartupFilter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisStartupFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisStartupFilter.Configure(System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        :type next: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
    
        
        .. code-block:: csharp
    
            public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    

