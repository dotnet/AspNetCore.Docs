

DeveloperExceptionPageExtensions Class
======================================



.. contents:: 
   :local:



Summary
-------

IApplicationBuilder extension methods for the ErrorPageMiddleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.DeveloperExceptionPageExtensions`








Syntax
------

.. code-block:: csharp

   public class DeveloperExceptionPageExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/DeveloperExceptionPage/DeveloperExceptionPageExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.DeveloperExceptionPageExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.DeveloperExceptionPageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.
        Full error details are only displayed by default if 'host.AppMode' is set to 'development' in the IApplicationBuilder.Properties.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDeveloperExceptionPage(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Diagnostics.ErrorPageOptions)
    
        
    
        Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.
        Full error details are only displayed by default if 'host.AppMode' is set to 'development' in the IApplicationBuilder.Properties.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.Diagnostics.ErrorPageOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDeveloperExceptionPage(IApplicationBuilder builder, ErrorPageOptions options)
    

