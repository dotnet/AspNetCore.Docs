

MonoDeployer Class
==================



.. contents:: 
   :local:



Summary
-------

Deployer for Kestrel on Mono.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployer`
* :dn:cls:`Microsoft.AspNet.Server.Testing.MonoDeployer`








Syntax
------

.. code-block:: csharp

   public class MonoDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Deployers/MonoDeployer.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.MonoDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Testing.MonoDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Testing.MonoDeployer.MonoDeployer(Microsoft.AspNet.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type deploymentParameters: Microsoft.AspNet.Server.Testing.DeploymentParameters
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public MonoDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.MonoDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.MonoDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
           public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.MonoDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public override void Dispose()
    

