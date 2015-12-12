

ServerLoader Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Server.ServerLoader`








Syntax
------

.. code-block:: csharp

   public class ServerLoader : IServerLoader





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/Server/ServerLoader.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Server.ServerLoader

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Server.ServerLoader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Server.ServerLoader.ServerLoader(System.IServiceProvider)
    
        
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public ServerLoader(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Server.ServerLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Server.ServerLoader.LoadServerFactory(System.String)
    
        
        
        
        :type assemblyName: System.String
        :rtype: Microsoft.AspNet.Hosting.Server.IServerFactory
    
        
        .. code-block:: csharp
    
           public IServerFactory LoadServerFactory(string assemblyName)
    

