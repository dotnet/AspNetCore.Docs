

DatabaseErrorPageExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Builder.IApplicationBuilder` extension methods for the :any:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.DatabaseErrorPageExtensions`








Syntax
------

.. code-block:: csharp

   public class DatabaseErrorPageExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Entity/DatabaseErrorPageExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.DatabaseErrorPageExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.DatabaseErrorPageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.DatabaseErrorPageExtensions.EnableAll(Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions)
    
        
    
        Sets the options to display the maximum amount of information available.
    
        
        
        
        :param options: The options to be configured.
        
        :type options: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions
    
        
        .. code-block:: csharp
    
           public static void EnableAll(DatabaseErrorPageOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated. The
        options for the middleware are set to display the maximum amount of information available.
    
        
        
        
        :param app: The  to register the middleware with.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The same <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDatabaseErrorPage(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNet.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions>)
    
        
    
        Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.
    
        
        
        
        :param app: The  to register the middleware with.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param optionsAction: An action to set the options for the middleware. All options are disabled by default.
        
        :type optionsAction: System.Action{Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The same <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDatabaseErrorPage(IApplicationBuilder app, Action<DatabaseErrorPageOptions> optionsAction)
    

