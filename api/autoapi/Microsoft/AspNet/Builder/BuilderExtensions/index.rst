

BuilderExtensions Class
=======================



.. contents:: 
   :local:



Summary
-------

Identity extensions for :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.BuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class BuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/BuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.BuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.BuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.BuilderExtensions.UseIdentity(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enables ASP.NET identity for the current application.
    
        
        
        
        :param app: The  instance this method extends.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" /> instance this method extends.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseIdentity(IApplicationBuilder app)
    

