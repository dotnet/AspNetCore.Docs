

WebApiCompatShimRouteBuilderExtensions Class
============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class WebApiCompatShimRouteBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/Routing/WebApiCompatShimRouteBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String)
    
        
        
        
        :type routeCollectionBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :type name: System.String
        
        
        :type template: System.String
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapWebApiRoute(IRouteBuilder routeCollectionBuilder, string name, string template)
    
    .. dn:method:: Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String, System.Object)
    
        
        
        
        :type routeCollectionBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :type name: System.String
        
        
        :type template: System.String
        
        
        :type defaults: System.Object
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapWebApiRoute(IRouteBuilder routeCollectionBuilder, string name, string template, object defaults)
    
    .. dn:method:: Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object)
    
        
        
        
        :type routeCollectionBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :type name: System.String
        
        
        :type template: System.String
        
        
        :type defaults: System.Object
        
        
        :type constraints: System.Object
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapWebApiRoute(IRouteBuilder routeCollectionBuilder, string name, string template, object defaults, object constraints)
    
    .. dn:method:: Microsoft.AspNet.Builder.WebApiCompatShimRouteBuilderExtensions.MapWebApiRoute(Microsoft.AspNet.Routing.IRouteBuilder, System.String, System.String, System.Object, System.Object, System.Object)
    
        
        
        
        :type routeCollectionBuilder: Microsoft.AspNet.Routing.IRouteBuilder
        
        
        :type name: System.String
        
        
        :type template: System.String
        
        
        :type defaults: System.Object
        
        
        :type constraints: System.Object
        
        
        :type dataTokens: System.Object
        :rtype: Microsoft.AspNet.Routing.IRouteBuilder
    
        
        .. code-block:: csharp
    
           public static IRouteBuilder MapWebApiRoute(IRouteBuilder routeCollectionBuilder, string name, string template, object defaults, object constraints, object dataTokens)
    

