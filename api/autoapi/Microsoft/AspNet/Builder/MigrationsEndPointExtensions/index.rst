

MigrationsEndPointExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Builder.IApplicationBuilder` extension methods for the :any:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.MigrationsEndPointExtensions`








Syntax
------

.. code-block:: csharp

   public class MigrationsEndPointExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Entity/MigrationsEndPointExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.MigrationsEndPointExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.MigrationsEndPointExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.MigrationsEndPointExtensions.UseMigrationsEndPoint(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Processes requests to execute migrations operations. The middleware will listen for requests made to :dn:field:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions.DefaultPath`\.
    
        
        
        
        :param app: The  to register the middleware with.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The same <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMigrationsEndPoint(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNet.Builder.MigrationsEndPointExtensions.UseMigrationsEndPoint(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions>)
    
        
    
        Processes requests to execute migrations operations. The middleware will listen for requests to the path configured in ``optionsAction``.
    
        
        
        
        :param app: The  to register the middleware with.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param optionsAction: An action to set the options for the middleware.
        
        :type optionsAction: System.Action{Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The same <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMigrationsEndPoint(IApplicationBuilder app, Action<MigrationsEndPointOptions> optionsAction)
    

