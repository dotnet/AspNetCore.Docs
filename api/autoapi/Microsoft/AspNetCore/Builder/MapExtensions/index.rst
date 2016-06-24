

MapExtensions Class
===================






Extension methods for the :any:`Microsoft.AspNetCore.Builder.Extensions.MapMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.MapExtensions`








Syntax
------

.. code-block:: csharp

    public class MapExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MapExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MapExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MapExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MapExtensions.Map(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Http.PathString, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Branches the request pipeline based on matches of the given request path. If the request path starts with
        the given path, the branch is executed.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param pathMatch: The request path to match.
        
        :type pathMatch: Microsoft.AspNetCore.Http.PathString
    
        
        :param configuration: The branch to take for positive path matches.
        
        :type configuration: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder Map(this IApplicationBuilder app, PathString pathMatch, Action<IApplicationBuilder> configuration)
    

