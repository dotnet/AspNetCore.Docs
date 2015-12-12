

IServerLoader Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IServerLoader





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/Server/IServerLoader.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.Server.IServerLoader

Methods
-------

.. dn:interface:: Microsoft.AspNet.Hosting.Server.IServerLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Server.IServerLoader.LoadServerFactory(System.String)
    
        
        
        
        :type assemblyName: System.String
        :rtype: Microsoft.AspNet.Hosting.Server.IServerFactory
    
        
        .. code-block:: csharp
    
           IServerFactory LoadServerFactory(string assemblyName)
    

