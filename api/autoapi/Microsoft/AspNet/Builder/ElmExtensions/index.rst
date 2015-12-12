

ElmExtensions Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.ElmExtensions`








Syntax
------

.. code-block:: csharp

   public class ElmExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ElmExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.ElmExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.ElmExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.ElmExtensions.UseElmCapture(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enables the Elm logging service, which can be accessed via the :any:`Microsoft.AspNet.Diagnostics.Elm.ElmPageMiddleware`\.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseElmCapture(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.ElmExtensions.UseElmPage(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enables viewing logs captured by the :any:`Microsoft.AspNet.Diagnostics.Elm.ElmCaptureMiddleware`\.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseElmPage(IApplicationBuilder builder)
    

