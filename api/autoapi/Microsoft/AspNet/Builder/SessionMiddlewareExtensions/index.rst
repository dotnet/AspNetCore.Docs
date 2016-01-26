

SessionMiddlewareExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding the :any:`Microsoft.AspNet.Session.SessionMiddleware` to an application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.SessionMiddlewareExtensions`








Syntax
------

.. code-block:: csharp

   public class SessionMiddlewareExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/session/blob/master/src/Microsoft.AspNet.Session/SessionMiddlewareExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.SessionMiddlewareExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.SessionMiddlewareExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.SessionMiddlewareExtensions.UseSession(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Adds the :any:`Microsoft.AspNet.Session.SessionMiddleware` to automatically enable session state for the application.
    
        
        
        
        :param app: The .
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: The <see cref="T:Microsoft.AspNet.Builder.IApplicationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseSession(IApplicationBuilder app)
    

