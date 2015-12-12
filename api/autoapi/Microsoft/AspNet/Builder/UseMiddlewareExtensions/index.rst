

UseMiddlewareExtensions Class
=============================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding typed middlware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.UseMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

   public class UseMiddlewareExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/Extensions/UseMiddlewareExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.UseMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.UseMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.UseMiddlewareExtensions.UseMiddleware(Microsoft.AspNet.Builder.IApplicationBuilder, System.Type, System.Object[])
    
        
    
        Adds a middleware type to the application's request pipeline.
    
        
        
        
        :param app: The  instance.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param middleware: The middleware type.
        
        :type middleware: System.Type
        
        
        :param args: The arguments to pass to the middleware type instance's constructor.
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMiddleware(IApplicationBuilder app, Type middleware, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Builder.UseMiddlewareExtensions.UseMiddleware<TMiddleware>(Microsoft.AspNet.Builder.IApplicationBuilder, System.Object[])
    
        
    
        Adds a middleware type to the application's request pipeline.
    
        
        
        
        :param app: The  instance.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param args: The arguments to pass to the middleware type instance's constructor.
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMiddleware<TMiddleware>(IApplicationBuilder app, params object[] args)
    

