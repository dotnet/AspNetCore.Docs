

AnalysisServiceCollectionExtensions Class
=========================================






Extension methods for setting up diagnostic services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.MiddlewareAnalysis

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.AnalysisServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class AnalysisServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.AnalysisServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.AnalysisServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.AnalysisServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AnalysisServiceCollectionExtensions.AddMiddlewareAnalysis(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds diagnostic services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddMiddlewareAnalysis(IServiceCollection services)
    

