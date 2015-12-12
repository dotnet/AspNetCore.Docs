

HttpsApplicationBuilderExtensions Class
=======================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Https.HttpsApplicationBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class HttpsApplicationBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel.Https/HttpsApplicationBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Https.HttpsApplicationBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Https.HttpsApplicationBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Https.HttpsApplicationBuilderExtensions.UseKestrelHttps(Microsoft.AspNet.Builder.IApplicationBuilder, System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
        
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type cert: System.Security.Cryptography.X509Certificates.X509Certificate2
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseKestrelHttps(IApplicationBuilder app, X509Certificate2 cert)
    

