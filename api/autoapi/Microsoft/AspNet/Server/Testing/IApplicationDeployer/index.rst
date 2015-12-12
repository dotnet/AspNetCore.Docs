

IApplicationDeployer Interface
==============================



.. contents:: 
   :local:



Summary
-------

Common operations on an application deployer.











Syntax
------

.. code-block:: csharp

   public interface IApplicationDeployer : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Deployers/IApplicationDeployer.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Testing.IApplicationDeployer

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Testing.IApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.IApplicationDeployer.Deploy()
    
        
    
        Deploys the application to the target with specified :any:`Microsoft.AspNet.Server.Testing.DeploymentParameters`\.
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
           DeploymentResult Deploy()
    

