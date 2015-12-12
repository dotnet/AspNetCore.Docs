

IISExpressDeployer Class
========================



.. contents:: 
   :local:



Summary
-------

Deployment helper for IISExpress.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployer`
* :dn:cls:`Microsoft.AspNet.Server.Testing.IISExpressDeployer`








Syntax
------

.. code-block:: csharp

   public class IISExpressDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Deployers/IISExpressDeployer.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.IISExpressDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Testing.IISExpressDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Testing.IISExpressDeployer.IISExpressDeployer(Microsoft.AspNet.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type deploymentParameters: Microsoft.AspNet.Server.Testing.DeploymentParameters
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public IISExpressDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.IISExpressDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.IISExpressDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
           public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.IISExpressDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public override void Dispose()
    

