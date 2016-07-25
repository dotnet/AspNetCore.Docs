

UseMiddlewareExtensions Class
=============================






Extension methods for adding typed middlware.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.UseMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

    public class UseMiddlewareExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.UseMiddlewareExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.UseMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.UseMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Type, System.Object[])
    
        
    
        
        Adds a middleware type to the application's request pipeline.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param middleware: The middleware type.
        
        :type middleware: System.Type
    
        
        :param args: The arguments to pass to the middleware type instance's constructor.
        
        :type args: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Type middleware, params object[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.UseMiddleware<TMiddleware>(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Object[])
    
        
    
        
        Adds a middleware type to the application's request pipeline.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param args: The arguments to pass to the middleware type instance's constructor.
        
        :type args: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMiddleware<TMiddleware>(this IApplicationBuilder app, params object[] args)
    

