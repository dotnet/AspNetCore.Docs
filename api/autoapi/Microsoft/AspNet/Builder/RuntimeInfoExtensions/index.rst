

RuntimeInfoExtensions Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.RuntimeInfoExtensions`








Syntax
------

.. code-block:: csharp

   public class RuntimeInfoExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/RuntimeInfo/RuntimeInfoExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.RuntimeInfoExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.RuntimeInfoExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.RuntimeInfoExtensions.UseRuntimeInfoPage(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseRuntimeInfoPage(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.RuntimeInfoExtensions.UseRuntimeInfoPage(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions)
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseRuntimeInfoPage(IApplicationBuilder builder, RuntimeInfoPageOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.RuntimeInfoExtensions.UseRuntimeInfoPage(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type path: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseRuntimeInfoPage(IApplicationBuilder builder, string path)
    

