

MapWhenExtensions Class
=======================






Extension methods for the :any:`Microsoft.AspNetCore.Builder.Extensions.MapWhenMiddleware`\.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.MapWhenExtensions`








Syntax
------

.. code-block:: csharp

    public class MapWhenExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MapWhenExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MapWhenExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MapWhenExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Func<Microsoft.AspNetCore.Http.HttpContext, System.Boolean>, System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        Branches the request pipeline based on the result of the given predicate.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param predicate: Invoked with the request environment to determine if the branch should be taken
        
        :type predicate: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.HttpContext<Microsoft.AspNetCore.Http.HttpContext>, System.Boolean<System.Boolean>}
    
        
        :param configuration: Configures a branch to take
        
        :type configuration: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder MapWhen(IApplicationBuilder app, Func<HttpContext, bool> predicate, Action<IApplicationBuilder> configuration)
    

