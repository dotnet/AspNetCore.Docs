

RuntimeInfoExtensions Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Builder.RuntimeInfoExtensions`








Syntax
------

.. code-block:: csharp

    public class RuntimeInfoExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.RuntimeInfoExtensions.UseRuntimeInfoPage(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseRuntimeInfoPage(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.RuntimeInfoExtensions.UseRuntimeInfoPage(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseRuntimeInfoPage(IApplicationBuilder app, RuntimeInfoPageOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.RuntimeInfoExtensions.UseRuntimeInfoPage(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type path: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseRuntimeInfoPage(IApplicationBuilder app, string path)
    

