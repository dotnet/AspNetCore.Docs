

UseExtensions Class
===================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.UseExtensions`








Syntax
------

.. code-block:: csharp

   public class UseExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Extensions/UseExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.UseExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.UseExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.UseExtensions.Use(Microsoft.AspNet.Builder.IApplicationBuilder, System.Func<Microsoft.AspNet.Http.HttpContext, System.Func<System.Threading.Tasks.Task>, System.Threading.Tasks.Task>)
    
        
    
        Adds a middleware delagate defined in-line to the application's request pipeline.
    
        
        
        
        :param app: The  instance.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param middleware: A function that handles the request or calls the given next function.
        
        :type middleware: System.Func{Microsoft.AspNet.Http.HttpContext,System.Func{System.Threading.Tasks.Task},System.Threading.Tasks.Task}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder Use(IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware)
    

