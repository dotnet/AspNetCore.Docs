

MapWhenExtensions Class
=======================



.. contents:: 
   :local:



Summary
-------

Extension methods for the :any:`Microsoft.AspNet.Builder.Extensions.MapWhenMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.MapWhenExtensions`








Syntax
------

.. code-block:: csharp

   public class MapWhenExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Extensions/MapWhenExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.MapWhenExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.MapWhenExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.MapWhenExtensions.MapWhen(Microsoft.AspNet.Builder.IApplicationBuilder, System.Func<Microsoft.AspNet.Http.HttpContext, System.Boolean>, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
    
        Branches the request pipeline based on the result of the given predicate.
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param predicate: Invoked with the request environment to determine if the branch should be taken
        
        :type predicate: System.Func{Microsoft.AspNet.Http.HttpContext,System.Boolean}
        
        
        :param configuration: Configures a branch to take
        
        :type configuration: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder MapWhen(IApplicationBuilder app, Func<HttpContext, bool> predicate, Action<IApplicationBuilder> configuration)
    

