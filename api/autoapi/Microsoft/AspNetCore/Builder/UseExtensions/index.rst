

UseExtensions Class
===================






Extension methods for adding middleware.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.UseExtensions`








Syntax
------

.. code-block:: csharp

    public class UseExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.UseExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.UseExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.UseExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.UseExtensions.Use(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Func<Microsoft.AspNetCore.Http.HttpContext, System.Func<System.Threading.Tasks.Task>, System.Threading.Tasks.Task>)
    
        
    
        
        Adds a middleware delagate defined in-line to the application's request pipeline.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param middleware: A function that handles the request or calls the given next function.
        
        :type middleware: System.Func<System.Func`3>{Microsoft.AspNetCore.Http.HttpContext<Microsoft.AspNetCore.Http.HttpContext>, System.Func<System.Func`1>{System.Threading.Tasks.Task<System.Threading.Tasks.Task>}, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder Use(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware)
    

