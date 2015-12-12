

ApplicationDeployerFactory Class
================================



.. contents:: 
   :local:



Summary
-------

Factory to create an appropriate deployer based on :any:`Microsoft.AspNet.Server.Testing.DeploymentParameters`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployerFactory`








Syntax
------

.. code-block:: csharp

   public class ApplicationDeployerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Server.Testing/Deployers/ApplicationDeployerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.ApplicationDeployerFactory

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.ApplicationDeployerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployerFactory.Create(Microsoft.AspNet.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        Creates a deployer instance based on settings in :any:`Microsoft.AspNet.Server.Testing.DeploymentParameters`\.
    
        
        
        
        :type deploymentParameters: Microsoft.AspNet.Server.Testing.DeploymentParameters
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        :rtype: Microsoft.AspNet.Server.Testing.IApplicationDeployer
    
        
        .. code-block:: csharp
    
           public static IApplicationDeployer Create(DeploymentParameters deploymentParameters, ILogger logger)
    

