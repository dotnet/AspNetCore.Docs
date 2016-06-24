

ElmExtensions Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.ElmExtensions`








Syntax
------

.. code-block:: csharp

    public class ElmExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.ElmExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.ElmExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.ElmExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.ElmExtensions.UseElmCapture(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enables the Elm logging service, which can be accessed via the :any:`Microsoft.AspNetCore.Diagnostics.Elm.ElmPageMiddleware`\.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseElmCapture(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.ElmExtensions.UseElmPage(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enables viewing logs captured by the :any:`Microsoft.AspNetCore.Diagnostics.Elm.ElmCaptureMiddleware`\.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseElmPage(this IApplicationBuilder app)
    

