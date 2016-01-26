

RunExtensions Class
===================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding terminal middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.RunExtensions`








Syntax
------

.. code-block:: csharp

   public class RunExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Extensions/RunExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.RunExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.RunExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.RunExtensions.Run(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Builder.RequestDelegate)
    
        
    
        Adds a terminal middleware delagate to the application's request pipeline.
    
        
        
        
        :param app: The  instance.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param handler: A delegate that handles the request.
        
        :type handler: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public static void Run(IApplicationBuilder app, RequestDelegate handler)
    

