

NginxDeployer Class
===================






Deployer for Kestrel on Nginx.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.ApplicationDeployer`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.SelfHostDeployer`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.NginxDeployer`








Syntax
------

.. code-block:: csharp

    public class NginxDeployer : SelfHostDeployer, IApplicationDeployer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Testing.NginxDeployer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.NginxDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.NginxDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.NginxDeployer.NginxDeployer(Microsoft.AspNetCore.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type deploymentParameters: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public NginxDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.NginxDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.NginxDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.NginxDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    

