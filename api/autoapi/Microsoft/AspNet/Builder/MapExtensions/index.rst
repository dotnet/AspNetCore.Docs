

MapExtensions Class
===================



.. contents:: 
   :local:



Summary
-------

Extension methods for the :any:`Microsoft.AspNet.Builder.Extensions.MapMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.MapExtensions`








Syntax
------

.. code-block:: csharp

   public class MapExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/Extensions/MapExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.MapExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.MapExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.MapExtensions.Map(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Http.PathString, System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
    
        Branches the request pipeline based on matches of the given request path. If the request path starts with
        the given path, the branch is executed.
    
        
        
        
        :param app: The  instance.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param pathMatch: The request path to match.
        
        :type pathMatch: Microsoft.AspNet.Http.PathString
        
        
        :param configuration: The branch to take for positive path matches.
        
        :type configuration: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder Map(IApplicationBuilder app, PathString pathMatch, Action<IApplicationBuilder> configuration)
    

