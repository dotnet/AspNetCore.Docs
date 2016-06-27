

WebApiCompatShimRouteBuilderExtensions Class
============================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class WebApiCompatShimRouteBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String)
    
        
    
        
        :type routeCollectionBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :type name: System.String
    
        
        :type template: System.String
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapWebApiRoute(this IRouteBuilder routeCollectionBuilder, string name, string template)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Object)
    
        
    
        
        :type routeCollectionBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :type name: System.String
    
        
        :type template: System.String
    
        
        :type defaults: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapWebApiRoute(this IRouteBuilder routeCollectionBuilder, string name, string template, object defaults)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object)
    
        
    
        
        :type routeCollectionBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :type name: System.String
    
        
        :type template: System.String
    
        
        :type defaults: System.Object
    
        
        :type constraints: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapWebApiRoute(this IRouteBuilder routeCollectionBuilder, string name, string template, object defaults, object constraints)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNetCore.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object, System.Object)
    
        
    
        
        :type routeCollectionBuilder: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        :type name: System.String
    
        
        :type template: System.String
    
        
        :type defaults: System.Object
    
        
        :type constraints: System.Object
    
        
        :type dataTokens: System.Object
        :rtype: Microsoft.AspNetCore.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
            public static IRouteBuilder MapWebApiRoute(this IRouteBuilder routeCollectionBuilder, string name, string template, object defaults, object constraints, object dataTokens)
    

