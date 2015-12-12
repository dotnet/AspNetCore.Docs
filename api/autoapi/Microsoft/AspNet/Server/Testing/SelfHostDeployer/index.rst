

SelfHostDeployer Class
======================



.. contents:: 
   :local:



Summary
-------

Deployer for WebListener and Kestrel.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployer`
* :dn:cls:`Microsoft.AspNet.Server.Testing.SelfHostDeployer`








Syntax
------

.. code-block:: csharp

   public class SelfHostDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Deployers/SelfHostDeployer.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.SelfHostDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Testing.SelfHostDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Testing.SelfHostDeployer.SelfHostDeployer(Microsoft.AspNet.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type deploymentParameters: Microsoft.AspNet.Server.Testing.DeploymentParameters
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public SelfHostDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.SelfHostDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.SelfHostDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
           public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.SelfHostDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public override void Dispose()
    

