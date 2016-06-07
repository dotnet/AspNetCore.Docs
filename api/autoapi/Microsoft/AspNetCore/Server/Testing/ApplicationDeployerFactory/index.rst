

ApplicationDeployerFactory Class
================================






Factory to create an appropriate deployer based on :any:`Microsoft.AspNetCore.Server.Testing.DeploymentParameters`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Testing`
Assemblies
    * Microsoft.AspNetCore.Server.Testing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.ApplicationDeployerFactory`








Syntax
------

.. code-block:: csharp

    public class ApplicationDeployerFactory








.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployerFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployerFactory

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployerFactory.Create(Microsoft.AspNetCore.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        Creates a deployer instance based on settings in :any:`Microsoft.AspNetCore.Server.Testing.DeploymentParameters`\.
    
        
    
        
        :type deploymentParameters: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        :rtype: Microsoft.AspNetCore.Server.Testing.IApplicationDeployer
    
        
        .. code-block:: csharp
    
            public static IApplicationDeployer Create(DeploymentParameters deploymentParameters, ILogger logger)
    

