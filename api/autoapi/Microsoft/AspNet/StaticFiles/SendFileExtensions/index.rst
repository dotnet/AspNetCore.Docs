

SendFileExtensions Class
========================



.. contents:: 
   :local:



Summary
-------

Extension methods for the SendFileMiddleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.SendFileExtensions`








Syntax
------

.. code-block:: csharp

   public class SendFileExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/SendFileExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.SendFileExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.SendFileExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.SendFileExtensions.UseSendFileFallback(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Provide a SendFile fallback if another component does not.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseSendFileFallback(IApplicationBuilder builder)
    

