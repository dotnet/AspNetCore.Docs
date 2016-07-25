

RunExtensions Class
===================






Extension methods for adding terminal middleware.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.RunExtensions`








Syntax
------

.. code-block:: csharp

    public class RunExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.RunExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RunExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.RunExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.RunExtensions.Run(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        Adds a terminal middleware delegate to the application's request pipeline.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param handler: A delegate that handles the request.
        
        :type handler: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public static void Run(this IApplicationBuilder app, RequestDelegate handler)
    

