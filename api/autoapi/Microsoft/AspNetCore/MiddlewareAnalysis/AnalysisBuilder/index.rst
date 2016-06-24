

AnalysisBuilder Class
=====================





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
* :dn:cls:`Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder`








Syntax
------

.. code-block:: csharp

    public class AnalysisBuilder : IApplicationBuilder








.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.AnalysisBuilder(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type inner: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public AnalysisBuilder(IApplicationBuilder inner)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.ServerFeatures
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public IFeatureCollection ServerFeatures { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate Build()
    
    .. dn:method:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.New()
    
        
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public IApplicationBuilder New()
    
    .. dn:method:: Microsoft.AspNetCore.MiddlewareAnalysis.AnalysisBuilder.Use(System.Func<Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Http.RequestDelegate>)
    
        
    
        
        :type middleware: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.RequestDelegate<Microsoft.AspNetCore.Http.RequestDelegate>, Microsoft.AspNetCore.Http.RequestDelegate<Microsoft.AspNetCore.Http.RequestDelegate>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    

