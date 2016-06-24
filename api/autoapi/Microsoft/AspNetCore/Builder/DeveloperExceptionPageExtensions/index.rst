

DeveloperExceptionPageExtensions Class
======================================






:any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` extension methods for the :any:`Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions`








Syntax
------

.. code-block:: csharp

    public class DeveloperExceptionPageExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Captures synchronous and asynchronous :any:`System.Exception` instances from the pipeline and generates HTML error responses.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to the <em>app</em> after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDeveloperExceptionPage(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions)
    
        
    
        
        Captures synchronous and asynchronous :any:`System.Exception` instances from the pipeline and generates HTML error responses.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to the <em>app</em> after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDeveloperExceptionPage(this IApplicationBuilder app, DeveloperExceptionPageOptions options)
    

