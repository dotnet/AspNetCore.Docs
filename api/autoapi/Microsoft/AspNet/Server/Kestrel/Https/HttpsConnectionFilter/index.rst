

HttpsConnectionFilter Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Https.HttpsConnectionFilter`








Syntax
------

.. code-block:: csharp

   public class HttpsConnectionFilter : IConnectionFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel.Https/HttpsConnectionFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Https.HttpsConnectionFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Https.HttpsConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Https.HttpsConnectionFilter.HttpsConnectionFilter(System.Security.Cryptography.X509Certificates.X509Certificate2, Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter)
    
        
        
        
        :type cert: System.Security.Cryptography.X509Certificates.X509Certificate2
        
        
        :type previous: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
           public HttpsConnectionFilter(X509Certificate2 cert, IConnectionFilter previous)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Https.HttpsConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Https.HttpsConnectionFilter.OnConnection(Microsoft.AspNet.Server.Kestrel.Filter.ConnectionFilterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Filter.ConnectionFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task OnConnection(ConnectionFilterContext context)
    

